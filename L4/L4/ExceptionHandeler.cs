using System;
using System.IO;

namespace L4
{
    public class ExceptionHandler
    {
        private int _num;
        public int num
        {
            get 
            { 
                return _num; 
            }
            set 
            { 
                if(value <0)
                    if(ThrowException)
                        throw new InvalidDataException();
                _num = value;
            }
        }
        public bool ThrowException { get; set; }
        public ExceptionHandler(bool throwException)
        {
            ThrowException = throwException;
        }

        public void ThrowOutOfMemoryException()
        {
            if (ThrowException)
                throw new OutOfMemoryException();
        }

        public void ThrowInvalidDataException()
        {
            if (ThrowException)
                throw new InvalidDataException("Invalid Data");
        }

        public void A(Boolean catchException)
        {
            if (!catchException)
                B();
            if(catchException)
                throw new NotImplementedException();
        }
        public void B(){C();}
        public void C(){D();}
        public void D(){throw new NotImplementedException();}
        public void RecursiveFunctions(bool catchException)
        {
            A(catchException);
        }

        public void UsingFinallyBlock(FileStream reader)
        {
            reader.Dispose();
            ThrowNotImplementedException();
        }

        public void ThrowNotImplementedException()
        {
            throw new NotImplementedException();
        }
    }
}