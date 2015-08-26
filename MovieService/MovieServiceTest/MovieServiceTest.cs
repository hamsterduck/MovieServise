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
            OmdbService service = OmdbService.Service;
            title = "Fight Club";
            SearchResult expected = new SearchResult();
            SearchResult actual = service.SearchMovie(title);
            Assert.IsTrue(actual.Titles.Contains("Fight Club") && actual.Years.Contains("1999"));
        }

        [TestMethod]
        [ExpectedException(typeof(TitleNotFoundException))]
        public void OmdbTitleNotFoundExceptionTest()
        {
            OmdbService service = OmdbService.Service;
            title = "thisIsNotAnameOfAmovie";
            service.SearchMovie(title);
        }

        [TestMethod]
        public void OmdbGetMovieInfoTest()
        {
            OmdbService service = OmdbService.Service;
            title = "The matrix";
            MovieInfo expected = new MovieInfo();
            expected.Title = "The Matrix";
            expected.Year = "1999";
            expected.Rated = "R";
            expected.Released = "31 Mar 1999";
            expected.RunTime = "136 min";
            expected.Genre = "Action, Sci-Fi";
            expected.Director = "Andy Wachowski, Lana Wachowski";
            expected.Writer = "Andy Wachowski, Lana Wachowski";
            expected.Actors = "Keanu Reeves, Laurence Fishburne, Carrie-Anne Moss, Hugo Weaving";
            expected.Plot = "A computer hacker learns from mysterious rebels about the true nature of his reality and his role in the war against its controllers.";
            expected.Language = "English";
            expected.Country = "USA, Australia";
            expected.Awards = "Won 4 Oscars. Another 33 wins & 40 nominations.";
            expected.Rating = "8.7";
            MovieInfo actual = service.GetMovieInfo(title);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(TitleNotFoundException))]
        public void OmdbMovieInfoNotFoundExceptionTest()
        {
            OmdbService service = OmdbService.Service;
            title = "thisIsNotAnameOfAmovie";
            service.GetMovieInfo(title);
        }

        [TestMethod]
        public void TmdbSearchMovieByTitleTest()
        {
            TmdbService service = TmdbService.Service;
            title = "The Matrix";
            SearchResult expected = new SearchResult();
            SearchResult actual = service.SearchMovie(title);
            Assert.IsTrue(actual.Titles.Contains("The Matrix") && actual.Years.Contains("1999-03-30"));
        }

        [TestMethod]
        [ExpectedException(typeof(TitleNotFoundException))]
        public void TmdbTitleNotFoundExceptionTest()
        {
            TmdbService service = TmdbService.Service;
            title = "thisIsNotAnameOfAmovie";
            service.SearchMovie(title);
        }

        [TestMethod]
        public void TmdbGetMovieInfoTest()
        {
            TmdbService service = TmdbService.Service;
            title = "Batman Begins";
            MovieInfo expected = new MovieInfo();
            expected.Title = "Batman Begins";
            expected.Released = "2005-06-15";
            expected.RunTime = "140";
            expected.Genre = " Action, Crime, Drama";
            expected.Plot = "Driven by tragedy, billionaire Bruce Wayne dedicates his life to uncovering and defeating the corruption that plagues his home, Gotham City.  Unable to work within the system, he instead creates a new identity, a symbol of fear for the criminal underworld - The Batman.";
            expected.Language = "en";
            expected.Year = "Missing data";
            expected.Rated = "Missing data";
            expected.Director = "Missing data";
            expected.Writer = "Missing data";
            expected.Actors = "Missing data";
            expected.Country = "Missing data";
            expected.Awards = "Missing data";
            expected.Rating = "Missing data";
            MovieInfo actual = service.GetMovieInfo(title);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(TitleNotFoundException))]
        public void TmdbMovieInfoNotFoundExceptionTest()
        {
            TmdbService service = TmdbService.Service;
            title = "thisIsNotAnameOfAmovie";
            service.GetMovieInfo(title);
        }

        [TestMethod]
        public void AuthenticateTest()
        {
            TmdbService service = TmdbService.Service;
            string expected = "OK";
            string userName = "kogrego";
            string password = "Gk2547963";
            string actual = service.Authenticate(userName, password);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(AuthenticationFailedException))]
        public void TmdbAuthenticationFailedExceptionTest()
        {
            TmdbService service = TmdbService.Service;
            title = "thisIsNotAnameOfAmovie";
            string userName = "kogrego";
            string password = "wrongPassword";
            service.Authenticate(userName, password);
        }
    }
}
