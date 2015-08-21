using System;

namespace MovieService
{
    /// <summary>
    /// A class that holds all Exceptiotions related to the MovieService
    /// </summary>
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
