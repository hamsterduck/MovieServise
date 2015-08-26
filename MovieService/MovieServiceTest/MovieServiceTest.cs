using Microsoft.VisualStudio.TestTools.UnitTesting;
using MovieService;

namespace MovieServiceTest
{
    [TestClass]
    public class MovieServiceTest
    { 
        private string title;

        [TestMethod]
        public void OmdbSearchMovieByTitleTest()
        {
            OmdbService Service = OmdbService.Service;
            title = "Fight Club";
            SearchResult Expected = new SearchResult();
            SearchResult Actual = Service.SearchMovie(title);
            Assert.IsTrue(Actual.Titles.Contains("Fight Club") && Actual.Years.Contains("1999"));
        }

        [TestMethod]
        [ExpectedException(typeof(TitleNotFoundException))]
        public void OmdbTitleNotFoundExceptionTest()
        {
            OmdbService Service = OmdbService.Service;
            title = "thisIsNotAnameOfAmovie";
            Service.SearchMovie(title);
        }

        [TestMethod]
        public void OmdbGetMovieInfoTest()
        {
            OmdbService Service = OmdbService.Service;
            title = "The matrix";
            MovieInfo Expected = new MovieInfo();
            Expected.Title = "The Matrix";
            Expected.Year = "1999";
            Expected.Rated = "R";
            Expected.Released = "31 Mar 1999";
            Expected.RunTime = "136 min";
            Expected.Genre = "Action, Sci-Fi";
            Expected.Director = "Andy Wachowski, Lana Wachowski";
            Expected.Writer = "Andy Wachowski, Lana Wachowski";
            Expected.Actors = "Keanu Reeves, Laurence Fishburne, Carrie-Anne Moss, Hugo Weaving";
            Expected.Plot = "A computer hacker learns from mysterious rebels about the true nature of his reality and his role in the war against its controllers.";
            Expected.Language = "English";
            Expected.Country = "USA, Australia";
            Expected.Awards = "Won 4 Oscars. Another 33 wins & 40 nominations.";
            Expected.Rating = "8.7";
            MovieInfo Actual = Service.GetMovieInfo(title);
            Assert.AreEqual(Expected, Actual);
        }

        [TestMethod]
        [ExpectedException(typeof(TitleNotFoundException))]
        public void OmdbMovieInfoNotFoundExceptionTest()
        {
            OmdbService Service = OmdbService.Service;
            title = "thisIsNotAnameOfAmovie";
            Service.GetMovieInfo(title);
        }

        [TestMethod]
        public void TmdbSearchMovieByTitleTest()
        {
            TmdbService Service = TmdbService.Service;
            title = "The Matrix";
            SearchResult Expected = new SearchResult();
            SearchResult Actual = Service.SearchMovie(title);
            Assert.IsTrue(Actual.Titles.Contains("The Matrix") && Actual.Years.Contains("1999-03-30"));
        }

        [TestMethod]
        [ExpectedException(typeof(TitleNotFoundException))]
        public void TmdbTitleNotFoundExceptionTest()
        {
            TmdbService Service = TmdbService.Service;
            title = "thisIsNotAnameOfAmovie";
            Service.SearchMovie(title);
        }

        [TestMethod]
        public void TmdbGetMovieInfoTest()
        {
            TmdbService Service = TmdbService.Service;
            title = "Batman Begins";
            MovieInfo Expected = new MovieInfo();
            Expected.Actors = "Missing data";
            Expected.Awards = "Missing data";
            Expected.Country = "Missing data";
            Expected.Director = "Missing data";
            Expected.Genre = " Action, Crime, Drama, ";
            Expected.Language = "en";
            Expected.Plot = "Driven by tragedy, billionaire Bruce Wayne dedicates his life to uncovering and defeating the corruption that plagues his home, Gotham City.  Unable to work within the system, he instead creates a new identity, a symbol of fear for the criminal underworld - The Batman.";
            Expected.Rated = "Missing data";
            Expected.Rating = "Missing data";
            Expected.Released = "2005-06-15";
            Expected.RunTime = "140";
            Expected.Title = "Batman Begins";
            Expected.Writer = "Missing data";
            Expected.Year = "Missing data";
            MovieInfo Actual = Service.GetMovieInfo(title);
            Assert.AreEqual(Expected, Actual);
        }

        [TestMethod]
        [ExpectedException(typeof(TitleNotFoundException))]
        public void TmdbMovieInfoNotFoundExceptionTest()
        {
            TmdbService Service = TmdbService.Service;
            title = "thisIsNotAnameOfAmovie";
            Service.GetMovieInfo(title);
        }

        [TestMethod]
        public void AuthenticateTest()
        {
            TmdbService Service = TmdbService.Service;
            string Expected = "OK";
            string UserName = "kogrego";
            string Password = "Gk2547963";
            string Actual = Service.Authenticate(UserName, Password);
            Assert.AreEqual(Expected, Actual);
        }

        [TestMethod]
        [ExpectedException(typeof(AuthenticationFailedException))]
        public void TmdbAuthenticationFailedExceptionTest()
        {
            TmdbService Service = TmdbService.Service;
            title = "thisIsNotAnameOfAmovie";
            string UserName = "kogrego";
            string Password = "wrongPassword";
            Service.Authenticate(UserName, Password);
        }
    }
}
