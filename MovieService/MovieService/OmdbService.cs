using System;
using System.Linq;
using System.Xml.Linq;

namespace MovieService
{
    /// <summary>
    /// A class that implements the IMoveService Interface using the OMDb RESTful API 
    /// </summary>
    /// <seealso cref="MovieService.IMovieService"/>
    public class OmdbService : IMovieService
    {
        private static OmdbService service;
        private const string baseUrl = "http://www.omdbapi.com/?r=xml&type=movie&";

        private OmdbService(){ }

        /// <summary>The Service property represents the one and only(singleton) instance of OmdbServoce</summary> 
        /// <value>The Service property gets the service or creates one if needed</value>
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
        /// <returns>Object of type SearchResult containing names and release years of resembling movie titles</returns>
        /// <exception cref="MovieService.FailedToLoadMovieDBException">Throws exception when the query result file 
        /// fails to load</exception>
        /// <exception cref="MovieService.TitleNotFoundException">Throws exception when Omdb returns a false reponse 
        /// (the movie title does not exist in the database)</exception>
        public SearchResult SearchMovie(string title)
        {
            string Url = baseUrl + "s=" + title;
            XDocument XDoc = null;
            SearchResult Result = new SearchResult();
            try
            {
                XDoc = XDocument.Load(Url);
            }
            catch (Exception)
            {
                throw new FailedToLoadMovieDBException("Error loading file. Please make sure you are connected to the intenet");
            }
            string response = XDoc.Descendants("root").Attributes("response").First().Value;
            if (XDoc != null && response == "True")
            {
                {
                    var MoviesQuery = from Root in XDoc.Root.Descendants("Movie")
                                      select new
                                      {
                                          Title = Root.Attribute("Title").Value,
                                          Year = Root.Attribute("Year").Value
                                      };
                    var Movies = MoviesQuery.ToList();
                    foreach (var Movie in Movies)
                    {
                        Result.Titles.Add(Movie.Title);
                        Result.Years.Add(Movie.Year);
                    }
                }

            }
            else
            {
                throw new TitleNotFoundException("Sorry, never heard of the movie " + title);
            }
            return Result;
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
            string Url = baseUrl + "t=" + title;
            XDocument XDoc = null;
            MovieInfo Result = new MovieInfo();
            
            try
            {
                XDoc = XDocument.Load(Url);
            } 
            catch(Exception)
            {
                throw new FailedToLoadMovieDBException("Error loading file. Please make sure you are connected to the intenet");
            }
            string response = XDoc.Descendants("root").Attributes("response").First().Value;
            if (XDoc != null && response == "True")
            {
                var MoviesQuery = from Root in XDoc.Root.Descendants("movie")
                                  select new
                                  {
                                      Title = Root.Attribute("title").Value,
                                      Year = Root.Attribute("year").Value,
                                      Rated = Root.Attribute("rated").Value,
                                      Released = Root.Attribute("released").Value,
                                      Runtime = Root.Attribute("runtime").Value,
                                      Genre = Root.Attribute("genre").Value,
                                      Director = Root.Attribute("director").Value,
                                      Writer = Root.Attribute("writer").Value,
                                      Actors = Root.Attribute("actors").Value,
                                      Plot = Root.Attribute("plot").Value,
                                      Language = Root.Attribute("language").Value,
                                      Country = Root.Attribute("country").Value,
                                      Awards = Root.Attribute("awards").Value,
                                      Rating = Root.Attribute("imdbRating").Value
                                  };
                var Movies = MoviesQuery.ToList();
                foreach (var Movie in Movies)
                {
                    Result.Title = Movie.Title;
                    Result.Year = Movie.Year;
                    Result.Rated = Movie.Rated;
                    Result.Released = Movie.Released;
                    Result.RunTime = Movie.Runtime;
                    Result.Genre = Movie.Genre;
                    Result.Director = Movie.Director;
                    Result.Writer = Movie.Writer;
                    Result.Actors = Movie.Actors;
                    Result.Plot = Movie.Plot;
                    Result.Language = Movie.Language;
                    Result.Country = Movie.Country;
                    Result.Awards = Movie.Awards;
                    Result.Rating = Movie.Rating;
                }
            }
            else
            {
                throw new TitleNotFoundException("Sorry, never heard of the movie " + title);
            }
            return Result;
        }

        /// <summary>
        /// Compsosites queries necessary for authentication porposes, loads and parses the response
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns>A string indicationg that there is no need for authentication</returns>
        public string Authenticate(string userName, string password)
        {
            return "No authentication needed";
        }
    }
}
