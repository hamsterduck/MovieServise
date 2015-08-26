using System;

namespace MovieService
{
    /// <summary>
    /// A class to test run the service
    /// </summary>
    class Program
    {
        static void Main()
        {
            // Flow for using OMDb service 
            IMovieService movieService = MovieServiceFactory.GetMovieService(MovieServiceFactory.OMDB);
            Console.WriteLine(movieService.SearchMovie("Fight Club"));
            Console.WriteLine(movieService.GetMovieInfo("Fight Club"));

            // Flow for using TMDb service
            IMovieService movieService2 = MovieServiceFactory.GetMovieService(MovieServiceFactory.TMDB);
            Console.WriteLine(movieService2.SearchMovie("the matrix"));
            Console.WriteLine(movieService2.GetMovieInfo("the matrix"));
            Console.ReadLine();
        }
    }
}