using System;

namespace MovieService
{
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