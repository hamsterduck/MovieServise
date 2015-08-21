using System;

namespace MovieService
{
    public class WrongServiceNameException : ApplicationException
    {
        public WrongServiceNameException(string msg)
            : base(msg)
        {

        }
    }
}
