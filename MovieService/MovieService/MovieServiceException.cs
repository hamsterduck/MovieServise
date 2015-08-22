using System;

namespace MovieService
{
    /// <summary>
    /// Thrown when trying to create an instance of an unknown service
    /// </summary>
    public class WrongServiceNameException : ApplicationException
    {
        public WrongServiceNameException(string msg)
            : base(msg)
        {

        }
    }

    /// <summary>
    /// Thrown when no data is found for the title that was passed
    /// </summary>
    public class TitleNotFoundException : ApplicationException
    {
        public TitleNotFoundException(string msg)
            : base(msg)
        {

        }
    }

    /// <summary>
    /// Thrown when the data file fails to load
    /// </summary>
    public class FailedToLoadMovieDBException : ApplicationException
    {
        public FailedToLoadMovieDBException(string msg)
            : base(msg)
        {

        }
    }

    /// <summary>
    /// Thrown when authentication fails
    /// </summary>
    public class AuthenticationFailedException : ApplicationException
    {

    }
}
