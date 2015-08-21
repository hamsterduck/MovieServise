using System.Collections.Generic;
using System.Linq;

namespace MovieService
{
    public class SearchResult
    {
        private List<string> titles;
        private List<string> years;

        public SearchResult()
        {
            titles = new List<string>();
            years = new List<string>();
        }

        public List<string> Title
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


        public List<string> Year
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
            var movies = Title.Zip(Year, (title, year) => title + " (" + year + ")");
            foreach (var movie in movies)
            {
                output += movie + "\n";
            }
            return "\n" + output + "\n";
        }
    }
}
