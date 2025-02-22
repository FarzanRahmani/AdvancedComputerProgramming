using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;

namespace A7
{
    public class ExceptionHandler
    {
        public string ErrorMsg { get; set; }
        public readonly bool DoNotThrow;
        private string _Input;

        public string Input
        {
            get
            {
                try
                {
                    // if (_Input == null)
                    //     throw new NullReferenceException();

                    if (_Input.Length < 50)
                        return _Input;
                }
                catch
                {
                    if (!DoNotThrow)
                        throw;
                    ErrorMsg = "Caught exception in GetMethod";
                }
                return null;
            }
            set
            {
                try
                {
                    // if (value == null)
                    //     throw new NullReferenceException();

                    if (value.Length < 50)
                        _Input = value;
                }
                catch
                {
                    if (!DoNotThrow)
                        throw;
                    ErrorMsg = "Caught exception in SetMethod";
                }
            }
        }


        public ExceptionHandler(
            string input,
            bool causeExceptionInConstructor,
            bool doNotThrow=false)
        {
            DoNotThrow = doNotThrow;
            this._Input = input;
            try
            {
                if (causeExceptionInConstructor)
                {
                    string test = null;
                    if (test.Length > 0) // nullrefrence exeption
                        Console.WriteLine("test");
                }
            }
            catch
            {
                if (!DoNotThrow)
                    throw;
                ErrorMsg = "Caught exception in constructor";
            }
        }

        public void OverflowExceptionMethod()
        {
            #region TODO
            try
            {
                checked
                {
                    int test = int.Parse(Input);
                    test++;
                }
            }
            catch(OverflowException ofe)
            {
                if (!DoNotThrow)
                    throw;
                ErrorMsg = $"Caught exception {ofe.GetType()}";
            }
            #endregion
        }

        public void FormatExceptionMethod()
        {
            try
            {
                int i = int.Parse(Input);
            }
            catch(FormatException e)
            {
                if (!DoNotThrow)
                    throw;
                ErrorMsg = $"Caught exception {e.GetType()}";
            }
        }

        public void FileNotFoundExceptionMethod()
        {
            #region TODO
            if (Input == "10")
                return;
            try
            {
                // throw new FileNotFoundException();
                StreamReader sr = new StreamReader("abzxcdfv.txt");
                var s = sr.ReadToEnd();
            }
            catch (FileNotFoundException fne)
            {
                if (!DoNotThrow)
                    throw;
                ErrorMsg = $"Caught exception {fne.GetType()}";
            }
            #endregion
        }

        public void IndexOutOfRangeExceptionMethod()
        {
            #region TODO
            int[] t = new int[1];
            // if (Input == "0")
            //     ErrorMsg = null;
            // if (Input == "1")
            // {
                try
                {
                    var f = t[int.Parse(Input)];
                    // throw new IndexOutOfRangeException();
                }
                catch(IndexOutOfRangeException e)
                {
                    if (!DoNotThrow)
                        throw;
                    ErrorMsg = $"Caught exception {e.GetType()}";
                }
            // }
            #endregion
        }

        public void OutOfMemoryExceptionMethod()
        {
            #region TODO
            // if (Input == "10")
            //     return;
            try
            {
                var a = new double[int.Parse(Input)];
                // throw new OutOfMemoryException();
            }
            catch (OutOfMemoryException ome)
            {
                if (!DoNotThrow)
                    throw;
                ErrorMsg = $"Caught exception {ome.GetType()}";
            }
            #endregion
        }

        public void MultiExceptionMethod()
        {
            #region TODO
            if (Input == "0")
                return;
            if (Input == "1")
                IndexOutOfRangeExceptionMethod();
            else 
                OutOfMemoryExceptionMethod();
            #endregion
        }

        public static void ThrowIfOdd(int n)
        {
            #region TODO
            if (n % 2 == 1)
                throw new InvalidDataException();
            #endregion
        }

        public string FinallyBlockStringOut;

        public void FinallyBlockMethod(string s)
        {
            StringBuilder sb = new StringBuilder();
            StringWriter swr = new StringWriter(sb);
            try
            {
                #region TODO
                swr.Write($"InTryBlock:");
                // if (s == null)
                    var n = s.Length;
                    // throw new NullReferenceException();
                if (s == "beautiful")
                {
                    swr.Write($"{s}:");
                    swr.Write($"9:DoneWriting");
                }
                #endregion
            }
            catch (NullReferenceException nre)
            {
                #region TODO
                swr.Write($":{nre.Message}");
                if (!DoNotThrow)
                    throw;
                #endregion
            }
            finally
            {
                swr.Write(":InFinallyBlock");
                swr.Dispose();
                FinallyBlockStringOut = sb.ToString();
            }
            if(s != "ugly")
                FinallyBlockStringOut += ":EndOfMethod";
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void NestedMethods()
        {
            #region TODO
            MethodA();
            #endregion
        }

        #region TODO
        public static void MethodA()
        {
            MethodB();
        }
        public static void MethodB()
        {
            MethodC();
        }

        public static void MethodC()
        {
            MethodD();
        }

        public static void MethodD()
        {
            throw new NotImplementedException();
        }


        #endregion
    }
}
