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
               //throw eception
            }
        }
    }
}