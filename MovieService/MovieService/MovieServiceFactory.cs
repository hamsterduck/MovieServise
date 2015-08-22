namespace MovieService
{
    /// <summary>
    /// A static class used as a factory for creating Movie Services  
    /// </summary>
    static class MovieServiceFactory
    {
        public static string OMDB = "OMDB";
        public static string TMDB = "TMDB";

        /// <summary>
        /// A method for creating instances of Movie Services
        /// </summary>
        /// <param name="service"></param>
        /// <returns>An object of type IMovieService</returns>
        /// <exception cref="MovieService.WrongServiceNameException">Thrown when trying to pass
        ///  a name of a service we do not suuport </exception>
        public static IMovieService GetMovieService(string service)
        {
            if (service == "OMDB")
            {
                return OmdbService.Service;
            }
            else if(service == "TMDB")
            {
                return TmdbService.Service;
            }
            else {
                {
                    throw new WrongServiceNameException("Sorry, we currently have no service named " + service);
                }
            }
        }
    }
}