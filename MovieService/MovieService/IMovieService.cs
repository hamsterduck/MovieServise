namespace MovieService
{
    interface IMovieService
    {
        SearchResult SearchMovie(string title);
        MovieInfo GetMovieInfo(string title);
    }
}
