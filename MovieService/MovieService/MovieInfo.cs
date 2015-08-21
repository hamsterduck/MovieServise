namespace MovieService
{
    public class MovieInfo
    {
        private string title;
        private string year;
        private string rated;
        private string released;
        private string runTime;
        private string genre;
        private string director;
        private string writer;
        private string actors;
        private string plot;
        private string language;
        private string country;
        private string awards;
        private string rating;

        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                if (value != null)
                {
                    title = value;
                }
                else
                {
                    title = "Missing data";
                }
            }
        }

        public string Year
        {
            get
            {
                return year;
            }
            set
            {
                if (value != null)
                {
                    year = value;
                }
                else
                {
                    year = "Missing data";
                }
            }
        }

        public string Rated
        {
            get
            {
                return rated;
            }
            set
            {
                if (value != null)
                {
                    rated = value;
                }
                else
                {
                    rated = "Missing data";
                }
            }
        }

        public string Released
        {
            get
            {
                return released;
            }
            set
            {
                if (value != null)
                {
                    released = value;
                }
                else
                {
                    released = "Missing data";
                }
            }
        }

        public string RunTime
        {
            get
            {
                return runTime;
            }
            set
            {
                if (value != null)
                {
                    runTime = value;
                }
                else
                {
                    runTime = "Missing data";
                }
            }
        }

        public string Genre
        {
            get
            {
                return genre;
            }
            set
            {
                if (value != null)
                {
                    genre = value;
                }
                else
                {
                    genre = "Missing data";
                }
            }
        }

        public string Director
        {
            get
            {
                return director;
            }
            set
            {
                if (value != null)
                {
                    director = value;
                }
                else
                {
                    director = "Missing data";
                }
            }
        }

        public string Writer
        {
            get
            {
                return writer;
            }
            set
            {
                if (value != null)
                {
                    writer = value;
                }
                else
                {
                    writer = "Missing data";
                }
            }
        }

        public string Actors
        {
            get
            {
                return actors;
            }
            set
            {
                if (value != null)
                {
                    actors = value;
                }
                else
                {
                    actors = "Missing data";
                }
            }
        }

        public string Plot
        {
            get
            {
                return plot;
            }
            set
            {
                if (value != null)
                {
                    plot = value;
                }
                else
                {
                    plot = "Missing data";
                }
            }
        }

        public string Language
        {
            get
            {
                return language;
            }
            set
            {
                if (value != null)
                {
                    language = value;
                }
                else
                {
                    language = "Missing data";
                }
            }
        }

        public string Country
        {
            get
            {
                return country;
            }
            set
            {
                if (value != null)
                {
                    country = value;
                }
                else
                {
                    country = "Missing data";
                }
            }
        }

        public string Awards
        {
            get
            {
                return awards;
            }
            set
            {
                if (value != null)
                {
                    awards = value;
                }
                else
                {
                    awards = "Missing data";
                }
            }
        }

        public string Rating
        {
            get
            {
                return rating;
            }
            set
            {
                if (value != null)
                {
                    rating = value;
                }
                else
                {
                    rating = "Missing data";
                }
            }
        }
        public override string ToString()
        {
            return "\nTitle: " + Title + "\n" + "Year: " + Year + "\n" + "Rated: " + Rated + "\n" + "Released: " + Released + "\n"
                + "RunTime: " + RunTime + "\n" + "Genre: " + Genre + "\n" + "Director: " + Director + "\n"
                + "Writer: " + Writer + "\n" + "Actors: " + Actors + "\n"
                + "Plot: " + Plot + "\n" + "Language: " + Language + "\n" + "Country: " + Country + "\n"
                + "Awards: " + Awards + "\n" + "IMDB Rating: " + Rating + "\n\n";
        }
    }
}