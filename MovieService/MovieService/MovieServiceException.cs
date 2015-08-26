using System;

namespace MovieService
{
    /// <summary>
    /// Thrown when trying to create an instance of an unknown service
    /// </summary>
    public class WrongServiceNameException : ApplicationException
    {
        /// <summary>
        /// Thrown when trying to create an instance of an unknown service
        /// </summary>
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
        /// <summary>
        /// Thrown when no data is found for the title that was passed
        /// </summary>
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
        /// <summary>
        /// Thrown when the data file fails to load
        /// </summary>
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
        /// <summary>
        /// Thrown when authentication fails
        /// </summary>
        public AuthenticationFailedException(string msg) :
            base(msg)
        {

        }
    }
}
