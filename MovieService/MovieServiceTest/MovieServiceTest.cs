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
        public void OmdbTMovieInfoNotFoundExceptionTest()
        {
            OmdbService service = OmdbService.Service;
            title = "thisIsNotAnameOfAmovie";
            service.GetMovieInfo(title);
        }

        [TestMethod]
        public void TmdbSearchMovieByTitleTest()
        {
            OmdbService service = OmdbService.Service;
            title = "The Matrix";
            SearchResult expected = new SearchResult();
            SearchResult actual = service.SearchMovie(title);
            Assert.IsTrue(actual.Titles.Contains("The Matrix") && actual.Years.Contains("1999"));
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
            title = "The Matrix";
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
        public void TmdbTMovieInfoNotFoundExceptionTest()
        {
            TmdbService service = TmdbService.Service;
            title = "thisIsNotAnameOfAmovie";
            service.GetMovieInfo(title);
        }
    }
}
