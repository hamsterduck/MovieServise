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

    public class TitleNotFoundException : ApplicationException
    {
        public TitleNotFoundException(string msg)
            : base(msg)
        {

        }
    }

    public class FailedToLoadMovieDBException : ApplicationException
    {
        public FailedToLoadMovieDBException(string msg)
            : base(msg)
        {

        }
    }
}
