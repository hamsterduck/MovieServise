using System;

namespace MovieService
{
    static class MovieServiceFactory
    {
        public static string OMDB = "OMDB";

        public static IMovieService GetMovieService(string service)
        {
            if (service == "OMDB")
            {
                return OmdbService.Service;
            }
            else {
                {
                    throw new WrongServiceNameException("Sorry, we currently have no service named " + service);
                }
            }
        }
    }
}