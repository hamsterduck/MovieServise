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
        private const string BaseUrl = "http://api.themoviedb.org/3/";
        private const string Authentication = "authentication/token/";
        private const string newToken = "new?api_key=";
        private const string ApiKey = "d22f2c0044f4c4eb0a46c5539bf4fc89";
        private string token;
        private string sessionID;
        private string userName;
        private string password;

        private TmdbService()
        {
            if (Authenticate() == "FAIL")
            {
                throw new AuthenticationFailedException("Wrong user name or password");
            }
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
        public string Authenticate()
        {
            string url = BaseUrl + Authentication + newToken + ApiKey;
            using (WebClient wc = new WebClient())
            {
                string json = null;
                JObject auth = null;
                try
                {
                    json = wc.DownloadString(url);
                }
                catch
                {
                    throw new AuthenticationFailedException("Error loading file. Please make sure you are connected to the intenet");
                }
                auth = JObject.Parse(json);
                token = (string)auth["request_token"];
                Console.Write("Please enter username: ");
                userName = Console.ReadLine();
                Console.Write("Please enter password: ");
                password = Console.ReadLine();
                url = BaseUrl + Authentication + "validate_with_login?api_key=" + ApiKey + 
                    "&request_token=" + token + "&username=" + userName + "&password=" + password;
                try
                {
                    json = wc.DownloadString(url);
                }
                catch(Exception e)
                {
                    if (e.Message == "The remote server returned an error: (401) Unauthorized.")
                    {
                        throw new AuthenticationFailedException("Wrong user name or password");
                    }
                    else if (e.Message == "The remote server returned an error: (400) Bad Request.")
                    {
                        throw new AuthenticationFailedException("No user name or password was enterd");
                    }
                    else
                    {
                        throw new AuthenticationFailedException("Error loading file. Please make sure you are connected to the intenet");
                    }
                }

                auth = JObject.Parse(json);
                token = (string)auth["request_token"];
                url = BaseUrl + "authentication/session/new?api_key=" + ApiKey + "&request_token=" + token;
                try
                {
                    json = wc.DownloadString(url);
                }
                catch
                {
                    throw new AuthenticationFailedException("Error loading file. Please make sure you are connected to the intenet");
                }
                auth = JObject.Parse(json);
                sessionID = (string)auth["session_id"];
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
            SearchResult result = new SearchResult();
            string url = BaseUrl + "search/movie?api_key=" + ApiKey + "&query=" + title;
            using (WebClient wc = new WebClient())
            {
                JObject search = new JObject();
                try
                {
                    var json = wc.DownloadString(url);
                    search = JObject.Parse(json);
                }
                catch
                {
                    throw new FailedToLoadMovieDBException("Error loading file. Please make sure you are connected to the intenet");
                }
                if ((string)search["total_results"] != "0")
                {
                    JArray jArray = new JArray();
                    jArray = (JArray)search["results"];
                    foreach (var token in jArray)
                    {
                        result.Titles.Add((string)token["original_title"]);
                        result.Years.Add((string)token["release_date"]);
                        result.Id.Add((string)token["id"]);
                    }
                }
                else
                {
                    throw new TitleNotFoundException("Title not found");
                }
            }
        return result;
        }

        /// <summary>
        /// Compsosites a query, loads and parses the response
        /// </summary>
        /// <param name="title"></param>
        /// <returns>Object of type MovieInfo containing information from selected movie</returns>
        /// <exception cref="MovieService.FailedToLoadMovieDBException">Throws exception when the query fails</exception>
        public MovieInfo GetMovieInfo(string title)
        {
            SearchResult result = SearchMovie(title);
            MovieInfo movieInfo = new MovieInfo();
            if (result.Id.Count > 1)
            {
                throw new TitleNotFoundException("There are too many result - try to make a more concrete search");
            }
            else if (result.Id.Count == 1)
            {
                string url = BaseUrl + "movie/" + result.Id[0] + "?api_key=" + ApiKey;
                using (WebClient wc = new WebClient())
                {
                    JObject info = new JObject();
                    try
                    {
                        var json = wc.DownloadString(url);
                        info = JObject.Parse(json);
                    }
                    catch
                    {
                        throw new FailedToLoadMovieDBException("Error loading file. Please make sure you are connected to the intenet");
                    }
                    JArray jArray = new JArray();
                    jArray = (JArray)info["genres"];
                    movieInfo.Genre = " ";
                    foreach (var token in jArray)
                    {
                        movieInfo.Genre += (string)token["name"];
                        movieInfo.Genre += ", ";
                    }
                    movieInfo.Language = (string)info["original_language"];
                    movieInfo.Plot = (string)info["overview"];
                    movieInfo.Released = (string)info["release_date"]; 
                    movieInfo.RunTime = (string)info["runtime"]; 
                    movieInfo.Title = (string)info["original_title"];
                }
            }
            else
            {
                throw new TitleNotFoundException("Title not found");
            }
            return movieInfo;
        }
    }
}
