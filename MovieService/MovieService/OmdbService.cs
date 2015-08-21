using System;

namespace MovieService
{
    public class OmdbService : IMovieService
    {
        private static OmdbService service;

        private OmdbService(){ }

        public static OmdbService Service
        {
            get
            {
                if (service == null)
                {
                    service = new OmdbService();
                }
                return service;
            }
        }

        public SearchResult SearchMovie(string title)
        {
            SearchResult result = new SearchResult();
            return result;
        }

        public MovieInfo GetMovieInfo(string title)
        {
            MovieInfo info = new MovieInfo();
            return info;
        }
    }
}
