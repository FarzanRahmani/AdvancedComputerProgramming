using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;
using System.IO;

namespace Logger.Tests
{
    [TestClass()]
    public class LogWriterPerfTests
    {
        [TestMethod()]
        public void LockedLogWriterPerfTest()
        {
            var time = PerfTest<LockedLogWriter>(threadCount:25, linePerThread:1000);
            System.Console.WriteLine(time);

            // Number Of Threads  |     1     |     2     |     5     |    10     |    20     |    50     |    100    |
            //    Elapsed Time    | 0.1400995 | 0.1527706 | 0.2056998 | 0.3058244 | 0.7234481 | 1.7206451 | 4.1178504 |
        }

        // LockedLogWriter dar zaman neveshtan dar file as lock estefade mikonad va fahgat be yek thread ejaze neveshtan midahad
        // vali  ConcurrentLogWriter safi(queue) az string ha baraye neveshte shodan misazad ke be soorat first in
        // first out hastand sepas ba estefade az AutoResetEvent Thread ha ra be soorat hamahang seda mizanad
        // dar thread haye ba tedad paeen amalkard LockedLogWriter behtar ast hamantor ke mibinim vali dar Thread haye ziaz
        // va bad az yek tedadi thread karaii ConcurrentLogWriter behtar mishavad

        [TestMethod()]
        public void ConcurrentLogWriterPerfTest()
        {
            var time = PerfTest<ConcurrentLogWriter>(threadCount:25, linePerThread: 1000);
            System.Console.WriteLine(time);

            // Number Of Threads  |     1     |     2     |     5     |    10     |    20     |    50     |    100    |
            //    Elapsed Time    | 0.1360752 | 0.1625309 | 0.2178929 | 0.5155752 | 0.6905952 | 1.9415532 | 4.6091267 |
        }

        // LockedQueueLogWriter
        // dar queue va dequeue string ha az lock estefade mikonad be jaye ConcurrentQueue
        // va LockedQueueLogWriter dar 1 ya 2 halat behtar az do kelas ghabli ast be khosoos 
        // dar Theard haye kam ke az har 2 behtar shode ast
        // vali dar kol nesbat be anha zaman bishtari sarf mikonad 
        // ke dar thread haye ziad ghabel moshahede ast
        [TestMethod()]
        public void LockedQueueLogWriterTest()
        {
            var time = PerfTest<LockedQueueLogWriter>(threadCount:100, linePerThread:1000);
            System.Console.WriteLine(time);

            // Number Of Threads  |     1     |     2     |     5     |    10     |    20     |    50     |    100    |
            //    Elapsed Time    | 0.1384434 | 0.1440235 | 0.2099505 | 0.4524222 | 0.5714846 | 1.7617599 | 4.7018418 |
        }

        // [TestMethod()]
        // public void NoLockPerfTest()
        // {
        //     var time = PerfTest<NoLockLogWriter>(threadCount: 25, linePerThread: 1000);
        //     // chon Thread ha hamzaman mikhan toye ye file benevisdan 
        //     // va thread haye motafavet mikhahand ba yek object dar yek zaman kar konand
        //     // بیش از یک نخ داریم، اگر بیش از یک نخ در آن واحد بخواهند
        //     // توی فایل ثبت وقایع بنویسند  
        //     // باید با هم هماهنگ شوند در حالی که در این کلاس 
        //     // NoLockLogWriter
        //     // هماهنگ نشده اند
        //     // va chon hamahang(sync) nistand ya lock nashode and hengam neveshtan exception midahand
        //     // An exception of type 'System.IndexOutOfRangeException' occurred in System.Private.CoreLib.dll but was not handled in user code: 'Index was outside the bounds of the array.'
        //     // An exception of type 'System.OverflowException' occurred in System.Private.CoreLib.dll but was not handled in user code: 'Arithmetic operation resulted in an overflow.'
        // }

        private string PerfTest<_LogWriter>(int threadCount, int linePerThread)
            where _LogWriter: GuardedLogWriter, new()
        {
            string logDir = Path.GetTempFileName();
            File.Delete(logDir);
            string logPrefix = "sauleh_all";
            string time = string.Empty;
            using (FileLogger<_LogWriter> logger = new FileLogger<_LogWriter>(
                    XmlLogFormatter.Instance,
                    new PrivacyScrubber(PhoneNumberScrubber.Instance, IDScrubber.Instance, FullNameScrubber.Instance),
                    new TimeBasedLogFileName(logDir, logPrefix, XmlLogFormatter.Instance.FileExtention),
                    LogLevels.All,
                    LogSources.All,
                    false))
            {
                var threads = Enumerable.Range(0, threadCount)
                                        .Select(n => new Thread(
                                            new ThreadStart(() => LogRandomMessages(linePerThread, logger))))
                                        .ToList();

                Stopwatch sw = Stopwatch.StartNew();
                threads.ForEach(t => t.Start());
                threads.ForEach(t => t.Join()); // An exception of type 'System.OverflowException' occurred in System.Private.CoreLib.dll but was not handled in user code: 'Arithmetic operation resulted in an overflow.'
                sw.Stop();

                time = sw.Elapsed.TotalSeconds.ToString();
                
            }

            int actualLogLines = CountLogLines(logDir, pattern: $"{logPrefix}*.{XmlLogFormatter.Instance.FileExtention}");

            Assert.AreEqual(linePerThread * threadCount + 2, actualLogLines); // plus 2 for header and footer

            return time;
        }

        private int CountLogLines(string logDir, string pattern)
        {
            return Directory.GetFiles(logDir, pattern).Sum(f => File.ReadAllLines(f).Length);
        }

        private void LogRandomMessages(int count, ILogger logger)
        {
            for (int i=0; i<count; i++)
            {
                LogEntry logEntry = new LogEntry(LogSource.Client, LogLevel.Debug,
                    $"student {i} created", ("FirstName", $"Pegah_{i}"), ("LastName", $"Ayati_{i}"));
                logger.Log(logEntry);
            }
        }
    }
}