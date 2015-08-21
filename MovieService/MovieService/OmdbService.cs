using System;
using System.Linq;
using System.Xml.Linq;

namespace MovieService
{
    public class OmdbService : IMovieService
    {
        private static OmdbService service;
        public const string baseUrl = "http://www.omdbapi.com/?r=xml&type=movie&";

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
            string url = baseUrl + "s=" + title;
            SearchResult result = new SearchResult();
            XDocument xDoc = XDocument.Load(url);
            string response = xDoc.Descendants("root").Attributes("response").First().Value;
            if (response == "True")
            {
                {
                    var moviesQuery = from root in xDoc.Root.Descendants("Movie")
                                      select new
                                      {
                                          Title = root.Attribute("Title").Value,
                                          Year = root.Attribute("Year").Value
                                      };
                    var movies = moviesQuery.ToList();
                    foreach (var movie in movies)
                    {
                        result.Titles.Add(movie.Title);
                        result.Years.Add(movie.Year);
                    }
                }

            }
            else
            {
                throw new TitleNotFoundException("Sorry, never heard of the movie " + title);
            }
            return result;
        }

        public MovieInfo GetMovieInfo(string title)
        {
            string url = baseUrl + "t=" + title;
            XDocument xDoc = null;
            MovieInfo result = new MovieInfo();
            
            try
            {
                xDoc = XDocument.Load(url);
            } 
            catch(Exception)
            {
                throw new FailedToLoadMovieDBException("Error loading file. Please make sure you are connected to the intenet");
            }
            string response = xDoc.Descendants("root").Attributes("response").First().Value;
            if (xDoc != null && response == "True")
            {
                var moviesQuery = from root in xDoc.Root.Descendants("movie")
                                  select new
                                  {
                                      Title = root.Attribute("title").Value,
                                      Year = root.Attribute("year").Value,
                                      Rated = root.Attribute("rated").Value,
                                      Released = root.Attribute("released").Value,
                                      Runtime = root.Attribute("runtime").Value,
                                      Genre = root.Attribute("genre").Value,
                                      Director = root.Attribute("director").Value,
                                      Writer = root.Attribute("writer").Value,
                                      Actors = root.Attribute("actors").Value,
                                      Plot = root.Attribute("plot").Value,
                                      Language = root.Attribute("language").Value,
                                      Country = root.Attribute("country").Value,
                                      Awards = root.Attribute("awards").Value,
                                      Rating = root.Attribute("imdbRating").Value
                                  };
                var movies = moviesQuery.ToList();
                foreach (var movie in movies)
                {
                    result.Title = movie.Title;
                    result.Year = movie.Year;
                    result.Rated = movie.Rated;
                    result.Released = movie.Released;
                    result.RunTime = movie.Runtime;
                    result.Genre = movie.Genre;
                    result.Director = movie.Director;
                    result.Writer = movie.Writer;
                    result.Actors = movie.Actors;
                    result.Plot = movie.Plot;
                    result.Language = movie.Language;
                    result.Country = movie.Country;
                    result.Awards = movie.Awards;
                    result.Rating = movie.Rating;
                }
            }
            else
            {
                throw new TitleNotFoundException("Sorry, never heard of the movie " + title);
            }
            return result;
        }

        public void PrintResult(object result)
        {
            if (result.GetType() == typeof(SearchResult))
            {
                Console.WriteLine("SearchResult");
            }
            else if (result.GetType() == typeof(MovieInfo))
            {
                Console.WriteLine("MovieInfo");
            }
        }
    }
}
