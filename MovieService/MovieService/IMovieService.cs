namespace MovieService
{
    /// <summary>
    /// Interface that MovieService classes are required to implement 
    /// </summary>
    /// <seealso cref="MovieService.OmdbService"/>
    ///  /// <seealso cref="MovieService.TmdbService"/>
    interface IMovieService
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
    }
}
