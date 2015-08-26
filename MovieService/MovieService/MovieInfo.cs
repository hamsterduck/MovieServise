namespace MovieService
{
    /// <summary>
    /// A class that represents a movie and it's fields contain information about the movie
    /// </summary>
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



        /// <summary>The Title property represents the movie's title</summary> 
        /// <value>The Title property gets/sets the value of the string field title</value>
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

        /// <summary>The Year property represents the movie's release year</summary> 
        /// <value>The Year property gets/sets the value of the string field year</value>
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


        /// <summary>The Rated property represents the movie's rate</summary> 
        /// <value>The Rated property gets/sets the value of the string field rated</value>
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


        /// <summary>The Released property represents the movie's release date</summary> 
        /// <value>The Released property gets/sets the value of the string field release</value>
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


        /// <summary>The RunTime property represents the movie's runTime</summary> 
        /// <value>The RunTime property gets/sets the value of the string field runTime</value>
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


        /// <summary>The Genre property represents the movie's genre</summary> 
        /// <value>The Genre property gets/sets the value of the string field genre</value>
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


        /// <summary>The Director property represents the movie's director</summary> 
        /// <value>The Director property gets/sets the value of the string field director</value>
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


        /// <summary>The Writer property represents the movie's writer</summary> 
        /// <value>The Writer property gets/sets the value of the string field writer</value>
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


        /// <summary>The Actors property represents the movie's actors</summary> 
        /// <value>The Actors property gets/sets the value of the string field actors</value>
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


        /// <summary>The Plot property represents the movie's plot</summary> 
        /// <value>The Plot property gets/sets the value of the string field plot</value>
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


        /// <summary>The Language property represents the movie's language</summary> 
        /// <value>The Language property gets/sets the value of the string field language</value>
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


        /// <summary>The Country property represents the movie's country</summary> 
        /// <value>The Country property gets/sets the value of the string field country</value>
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


        /// <summary>The Awards property represents the movie's awards</summary> 
        /// <value>The Awards property gets/sets the value of the string field awards</value>
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


        /// <summary>The Rating property represents the movie's rating</summary> 
        /// <value>The Rating property gets/sets the value of the string field rating</value>
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
        /// <summary>
        /// Overriding ToString to print a MovieInfo Object
        /// </summary>
        /// <returns>A string representing A MovieInfo Object</returns>
        public override string ToString()
        {
            return "##### Movie Info #####\n" + "\nTitle: " + Title + "\n" + "Year: " + Year + "\n" + "Rated: " + Rated + "\n" + "Released: " + Released + "\n"
                + "RunTime: " + RunTime + "\n" + "Genre: " + Genre + "\n" + "Director: " + Director + "\n"
                + "Writer: " + Writer + "\n" + "Actors: " + Actors + "\n"
                + "Plot: " + Plot + "\n" + "Language: " + Language + "\n" + "Country: " + Country + "\n"
                + "Awards: " + Awards + "\n" + "IMDB Rating: " + Rating + "\n\n";
        }

        /// <summary>
        /// Overriding Equals to be able to compare between two object. Mainly for testing purposes
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>True if Object are equal or False, otherwise</returns>
        public override bool Equals(object obj)
        {
            MovieInfo movieInfo = obj as MovieInfo;
            if(movieInfo == null)
            {
                return false;
            }
            else
            {
                return title.Equals(movieInfo.Title) && year.Equals(movieInfo.Year) &&
                        rated.Equals(movieInfo.Rated) && released.Equals(movieInfo.Released) &&
                        runTime.Equals(movieInfo.RunTime) && genre.Equals(movieInfo.Genre) &&
                        director.Equals(movieInfo.Director) && writer.Equals(movieInfo.Writer) &&
                        actors.Equals(movieInfo.Actors) && plot.Equals(movieInfo.Plot) &&
                        language.Equals(movieInfo.Language) && country.Equals(movieInfo.Country) &&
                        awards.Equals(movieInfo.Awards) && rating.Equals(movieInfo.Rating);
            }
        }

        /// <summary>
        /// Overriding GetHashCode to be able to compare between two object. Mainly for testing purposes
        /// </summary>
        /// <returns>int base hash code</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

    }
}