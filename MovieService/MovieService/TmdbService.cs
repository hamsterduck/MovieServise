using System;
using System.Net;

namespace MovieService

{
    /// <summary>
    /// A class that implements the IMoveService Interface using the TMDb RESTful API 
    /// </summary>
    /// <seealso cref="MovieService.IMovieService"/>
    public class TmdbService : IMovieService
    {
        private static TmdbService service;

        private TmdbService() { }
        private const string BaseUrl = "http://api.themoviedb.org/3/";
        private const string Authentication = "authentication/token/";
        private const string newToken = "new?api_key=";
        private const string ApiKey = "d22f2c0044f4c4eb0a46c5539bf4fc89";
        private string token;
        private string sessionID;

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
            string userName;
            string password;
            string url = BaseUrl + Authentication + newToken + ApiKey;
            using (WebClient wc = new WebClient())
            {
                string json = null;
                JObject auth = null;

                try
                {
                    json = wc.DownloadString(url);
                    auth = JObject.Parse(json);
                    token = (string)auth["request_token"];
                }
                catch
                {
                    //throw exception

                }

                Console.Write("Please enter username: ");
                userName = Console.ReadLine();
                Console.Write("Please enter password: ");
                password = Console.ReadLine();
                url = BaseUrl + Authentication + "validate_with_login?api_key=" + ApiKey + 
                    "&request_token=" + token + "&username=" + userName + "&password=" + password;
                try
                {
                    json = wc.DownloadString(url);
                    auth = JObject.Parse(json);
                }
                catch
                {
                    //throw exception
                }
                token = (string)auth["request_token"];
                url = BaseUrl + "/authentication/session/new?api_key=" + ApiKey + "&request_token=" + token;
                try
                {
                    json = wc.DownloadString(url);
                    auth = JObject.Parse(json);
                }
                catch
                {
                    //throw exception
                }
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
        /// <exception cref="MovieService.AuthenticationFailedException">Throws exception when authentiction fails</exception>
        public SearchResult SearchMovie(string title)
        {
            SearchResult result = new SearchResult();
            if (Authenticate() == "OK") 
            {
                string url = BaseUrl + "search/movie?api_key=" + ApiKey + "&query=" + title;
                using (WebClient wc = new WebClient())
                {
                    try
                    {
                        var json = wc.DownloadString(url);
                        JObject search = JObject.Parse(json);
                    }
                    catch
                    {
                        //throw exception
                    }
                    if ((string)search["total_results"] != "0")
                    {
                        JArray jArray = new JArray();
                        jArray = (JArray)search["results"];
                        foreach (var token in jArray)
                        {
                            result.Titles.Add((string)token["original_title"]);
                            result.Years.Add((string)token["release_date"]);
                        }
                    }
                }
            }
            else
            {
                //throw Exception
            }
            return result;
        }

        public MovieInfo GetMovieInfo(string title)
        {
            throw new NotImplementedException();
        }
    }
}
