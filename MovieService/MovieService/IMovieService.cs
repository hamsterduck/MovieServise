﻿namespace MovieService
{
    /// <summary>
    /// Interface that MovieService classes are required to implement 
    /// </summary>
    /// <seealso cref="MovieService.OmdbService"/>
    ///  /// <seealso cref="MovieService.TmdbService"/>
    public interface IMovieService
    {
        /// <summary>
        /// A method that searches for a movie by its title
        /// </summary>
        /// <param name="title"></param>
        /// <returns>returns a list related movie titles and their release years</returns>
        SearchResult SearchMovie(string title);

        /// <summary>
        /// A method that presents the data of a specific movie by its title
        /// </summary>
        /// <param name="title"></param>
        /// <returns>Movie information (Director, Awards, Actors and more)</returns>
        MovieInfo GetMovieInfo(string title);

        /// <summary>
        /// Compsosites queries necessary for authentication porposes, loads and parses the response
        /// </summary>
        /// <exception cref="MovieService.AuthenticationFailedException">Throws exception when one of the authentication
        /// steps fails</exception>
        string Authenticate(string userName, string password);
    }
}
