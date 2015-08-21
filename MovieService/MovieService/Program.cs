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
            IMovieService movieService = MovieServiceFactory.GetMovieService(MovieServiceFactory.OMDB);
            Console.WriteLine(movieService.SearchMovie("Fight Club"));
            Console.WriteLine(movieService.GetMovieInfo("Fight Club"));
            Console.ReadLine();
        }
    }
}