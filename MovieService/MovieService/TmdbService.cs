using System;
using System.Net;
using Newtonsoft.Json.Linq;



namespace MovieService

{
    /// <summary>
    /// A class that implements the IMoveService Interface using the TMDb RESTful API 
    /// </summary>
    /// <seealso cref="MovieService.IMovieService"/>
    public class TmdbService : IMovieService
    {
        private static TmdbService service;
        private const string baseUrl = "http://api.themoviedb.org/3/";
        private const string authentication = "authentication/token/";
        private const string newToken = "new?api_key=";
        private const string apiKey = "d22f2c0044f4c4eb0a46c5539bf4fc89";
        private string token;
        private string sessionID;

        private TmdbService()
        {
        }

        /// <summary>The Token property represents the request token we use for TMDb authentication</summary> 
        /// <value>The Token property gets/sets the value of the string field Token</value>
        public string Token
        {
            get
            {
                return token;
            }
            set
            {
                token = value;
            }
        }

        /// <summary>The Service property represents the one and only(singleton) instance of TmdbServoce</summary> 
        /// <value>The Service property gets the service or creates one if needed</value>
        public static TmdbService Service
        {
            get
            {
                if (service == null)
                {
                    service = new TmdbService();
                }
                return service;
            }
        }

        /// <summary>
        /// Compsosites queries necessary for authentication porposes, loads and parses the response
        /// </summary>
        /// <exception cref="MovieService.AuthenticationFailedException">Throws exception when one of the authentication
        /// steps fails</exception> 
        /// <returns>A string indicating the status of the authentication</returns>
        /// <exception cref="MovieService.AuthenticationFailedException">Throws exception when the authentication fails</exception>
        public string Authenticate(string userName, string password)
        {
            string Url = baseUrl + authentication + newToken + apiKey;
            using (WebClient wc = new WebClient())
            {
                string Json = null;
                JObject Auth = null;
                try
                {
                    Json = wc.DownloadString(Url);
                }
                catch
                {
                    throw new AuthenticationFailedException("Error loading file. Please make sure you are connected to the intenet");
                }
                Auth = JObject.Parse(Json);
                token = (string)Auth["request_token"];
                Url = baseUrl + authentication + "validate_with_login?api_key=" + apiKey + 
                    "&request_token=" + token + "&username=" + userName + "&password=" + password;
                try
                {
                    Json = wc.DownloadString(Url);
                }
                catch(Exception UrlException)
                {
                    if (UrlException.Message == "The remote server returned an error: (401) Unauthorized.")
                    {
                        throw new AuthenticationFailedException("Wrong user name or password");
                    }
                    else if (UrlException.Message == "The remote server returned an error: (400) Bad Request.")
                    {
                        throw new AuthenticationFailedException("No user name or password was enterd");
                    }
                    else
                    {
                        throw new AuthenticationFailedException("Error loading file. Please make sure you are connected to the intenet");
                    }
                }

                Auth = JObject.Parse(Json);
                token = (string)Auth["request_token"];
                Url = baseUrl + "authentication/session/new?api_key=" + apiKey + "&request_token=" + token;
                try
                {
                    Json = wc.DownloadString(Url);
                }
                catch
                {
                    throw new AuthenticationFailedException("Error loading file. Please make sure you are connected to the intenet");
                }
                Auth = JObject.Parse(Json);
                sessionID = (string)Auth["session_id"];
            }
            if (sessionID != null)
            {
                return "OK";
            }
            else
            {
                return "FAIL";
            }
        }

        /// <summary>
        /// Compsosites a query, loads and parses the response
        /// </summary>
        /// <param name="title"></param>
        /// <returns>Object of type SearchResult containing names and release years of resembling movie titles</returns>
        /// <exception cref="MovieService.FailedToLoadMovieDBException">Throws exception when the query fails</exception>
        public SearchResult SearchMovie(string title)
        {
            SearchResult Result = new SearchResult();
            string Url = baseUrl + "search/movie?api_key=" + apiKey + "&query=" + title;
            using (WebClient Wc = new WebClient())
            {
                JObject Search = new JObject();
                try
                {
                    var Json = Wc.DownloadString(Url);
                    Search = JObject.Parse(Json);
                }
                catch
                {
                    throw new FailedToLoadMovieDBException("Error loading file. Please make sure you are connected to the intenet");
                }
                if ((string)Search["total_results"] != "0")
                {
                    JArray MovieList = new JArray();
                    MovieList = (JArray)Search["results"];
                    foreach (var Movie in MovieList)
                    {
                        Result.Titles.Add((string)Movie["original_title"]);
                        Result.Years.Add((string)Movie["release_date"]);
                        Result.Id.Add((string)Movie["id"]);
                    }
                }
                else
                {
                    throw new TitleNotFoundException("Title not found");
                }
            }
        return Result;
        }

        /// <summary>
        /// Compsosites a query, loads and parses the response
        /// </summary>
        /// <param name="title"></param>
        /// <returns>Object of type MovieInfo containing information from selected movie</returns>
        /// <exception cref="MovieService.TitleNotFoundException">Throws exception when the query fails</exception>
        public MovieInfo GetMovieInfo(string title)
        {
            SearchResult Result = SearchMovie(title);
            MovieInfo MovieInfo = new MovieInfo();
            if (Result.Id.Count < 1)
            {
                throw new TitleNotFoundException("Title not found");
            }
            string Url = baseUrl + "movie/" + Result.Id[0] + "?api_key=" + apiKey;
            using (WebClient wc = new WebClient())
            {
                JObject Info = new JObject();
                try
                {
                    var Json = wc.DownloadString(Url);
                    Info = JObject.Parse(Json);
                }
                catch
                {
                    throw new FailedToLoadMovieDBException("Error loading file. Please make sure you are connected to the intenet");
                }
                JArray Genres = new JArray();
                Genres = (JArray)Info["genres"];
                MovieInfo.Genre = " ";
                foreach (var EachGenre in Genres)
                {
                    MovieInfo.Genre += (string)EachGenre["name"];
                    MovieInfo.Genre += ", ";
                }
                MovieInfo.Language = (string)Info["original_language"];
                MovieInfo.Plot = (string)Info["overview"];
                MovieInfo.Released = (string)Info["release_date"]; 
                MovieInfo.RunTime = (string)Info["runtime"]; 
                MovieInfo.Title = (string)Info["original_title"];
                MovieInfo.Year = null;
                MovieInfo.Rated = null;
                MovieInfo.Director = null;
                MovieInfo.Writer = null;
                MovieInfo.Actors = null;
                MovieInfo.Country = null;
                MovieInfo.Awards = null;
                MovieInfo.Rating = null;
            }
            return MovieInfo;
        }
    }
}
