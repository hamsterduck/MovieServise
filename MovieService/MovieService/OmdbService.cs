using System;
using System.Linq;
using System.Xml.Linq;

/// <summary>
/// A class that implements the IMoveService Interface using the Omdb RESTful API 
/// </summary>
/// <seealso cref="MovieService.IMovieService"/>

namespace MovieService
{
    public class OmdbService : IMovieService
    {
        private static OmdbService service;
        public const string baseUrl = "http://www.omdbapi.com/?r=xml&type=movie&";

        /// <summary>
        /// OmdbServise Constructor that takes no parameters
        /// </summary>
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

        /// <summary>
        /// Compsosites a query, loads and parses the response
        /// </summary>
        /// <param name="title"></param>
        /// <returns>Object of type SearchResult containing names and release years of resemling movie titles</returns>
        /// <exception cref="MovieService.FailedToLoadMovieDBException">Throws exception when the query result file 
        /// fails to load</exception>
        /// <exception cref="MovieService.TitleNotFoundException">Throws exception when Omdb returns a false reponse 
        /// (the movie title does not exist in the database)</exception>
        public SearchResult SearchMovie(string title)
        {
            string url = baseUrl + "s=" + title;
            XDocument xDoc = null;
            SearchResult result = new SearchResult();
            try
            {
                xDoc = XDocument.Load(url);
            }
            catch (Exception)
            {
                throw new FailedToLoadMovieDBException("Error loading file. Please make sure you are connected to the intenet");
            }
            string response = xDoc.Descendants("root").Attributes("response").First().Value;
            if (xDoc != null && response == "True")
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

        /// <summary>
        /// Compsosites a query, loads and parses the response
        /// </summary>
        /// <param name="title"></param>
        /// <returns>Obhect of type MovieInfo containing information about a particular movie</returns>
        /// <exception cref="MovieService.FailedToLoadMovieDBException">Throws exception when the query result file 
        /// fails to load</exception>
        /// <exception cref="MovieService.TitleNotFoundException">Throws exception when Omdb returns a false reponse 
        /// (the movie title does not exist in the database)</exception>
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

        /// <summary>
        /// Prints the result of the query
        /// </summary>
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
