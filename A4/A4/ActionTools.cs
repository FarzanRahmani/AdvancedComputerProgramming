using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace A4
{
    public static class ActionTools
    {
        public static long CallSequential(params Action[] actions)
        {
            #region TODO
            Stopwatch sw = Stopwatch.StartNew();
            for (int i = 0; i < actions.Length; i++)
                actions[i]();
            long result = sw.ElapsedMilliseconds;
            return result;
            #endregion
        }

        public static long CallParallel(params Action[] actions)
        {
            #region TODO
            Stopwatch stopwatch = Stopwatch.StartNew();
            Parallel.ForEach(actions , (action) => action());
            // Task[] tasks = new Task[actions.Length];
            // for (int i = 0; i < actions.Length; i++)
            // {
            //     tasks[i] = new Task(actions[i]);
            //     tasks[i].Start(); 
            // }
            // Task.WhenAll(tasks).Wait();
            long result = stopwatch.ElapsedMilliseconds;
            return result;
            #endregion

        }

        static object sync_lock = new object();

        public static long CallParallelThreadSafe(int count, params Action[] actions)
        {
            #region TODO
            Stopwatch stopwatch = Stopwatch.StartNew();
            for (int i = 0; i < count; i++)
            {
                Parallel.ForEach(actions , (action) => {
                    lock (sync_lock)
                    {
                        action();
                    }
                    });
            // Task[] tasks = new Task[actions.Length];
            // for (int j = 0; j < actions.Length; j++)
            // {
            //     tasks[j] = new Task(() => {
            //         lock (sync_lock)
            //         {
            //             actions[j]();
            //         } 
            //     });
            //     tasks[j].Start(); 
            // }
            // Task.WhenAll(tasks).Wait(); 
            }
            long result = stopwatch.ElapsedMilliseconds;
            return result;
            #endregion
        }


        public static async Task<long> CallSequentialAsync(params Action[] actions)
        {
            #region TODO
            Stopwatch sw = Stopwatch.StartNew();
            Task[] tasks = new Task[actions.Length];
            for (int i = 0; i < actions.Length; i++)
            {
                tasks[i] = new Task(actions[i]);
                tasks[i].Start();
                await tasks[i]; 
            }
            long result = sw.ElapsedMilliseconds;
            return result;
            #endregion

        }

        public static async Task<long> CallParallelAsync(params Action[] actions)
        {
            #region TODO
            Stopwatch stopwatch = Stopwatch.StartNew();
            Task[] tasks = new Task[actions.Length];
            for (int i = 0; i < actions.Length; i++)
            {
                tasks[i] = new Task(actions[i]);
                tasks[i].Start(); 
            }
            await Task.WhenAll(tasks);
            long result = stopwatch.ElapsedMilliseconds;
            return result;
            #endregion
        }

        public static async Task<long> CallParallelThreadSafeAsync(int count, params Action[] actions)
        {
            #region TODO
            Stopwatch stopwatch = Stopwatch.StartNew();
            int i = 0;
            Task[] tasks = new Task[actions.Length];
            foreach(var action in actions)
            {
                tasks[i] = new Task (() => {
                    for(int j =0;j<count;j++)
                        lock (sync_lock)
                            action();
                });
                tasks[i].Start();i++;
            }
            await Task.WhenAll(tasks);
            long result = stopwatch.ElapsedMilliseconds;
            return result;
            #endregion
        }
    }
}