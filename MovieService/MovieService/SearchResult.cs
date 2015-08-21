using System.Collections.Generic;
using System.Linq;

namespace MovieService
{
    /// <summary>
    /// A class that represnets a list of movies by their titles and release years
    /// </summary>
    public class SearchResult
    {
        private List<string> titles;
        private List<string> years;

        public SearchResult()
        {
            titles = new List<string>();
            years = new List<string>();
        }

        public List<string> Titles
        {
            get
            {
                return titles;
            }
            set
            {
                if (value != null)
                {
                    titles = value;
                }
                else
                {
                    titles.Add("Missing data");
                }
            }
        }


        public List<string> Years
        {
            get
            {
                return years;
            }
            set
            {
                if (value != null)
                {
                    years = value;
                }
                else
                {
                    years.Add("Missing data");
                }
            }
        }

        public override string ToString()
        {
            string output = null;
            var movies = Titles.Zip(Years, (title, year) => title + " (" + year + ")");
            foreach (var movie in movies)
            {
                output += movie + "\n";
            }
            return "#### Movie Serach Results #####\n\n" + output + "\n";
        }
    }
}