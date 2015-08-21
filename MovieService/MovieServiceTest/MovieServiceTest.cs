using System;
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
            title = "Ant man";
            SearchResult expected = new SearchResult();
            expected.Title.Add("Fight Club");
            expected.Year.Add("1999");
            SearchResult actual = service.SearchMovie(title);
            Assert.AreEqual(expected, actual);
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
    }
}
