﻿using System.Collections.Generic;
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
        private List<string> id;

        /// <summary>
        /// SearchResult Constructor that takes no parameters
        /// </summary>
        public SearchResult()
        {
            titles = new List<string>();
            years = new List<string>();
            id = new List<string>();
        }

        /// <summary>The Titles property represents the a list of movie titles</summary> 
        /// <value>The Titles property gets/sets the value of the list field titles</value>
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


        /// <summary>The Titles property represents the a list of movie release year</summary> 
        /// <value>The Years property gets/sets the value of the list field years</value>
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

        /// <summary>The Id property represents the a list of movie id's</summary> 
        /// <value>The Titles property gets/sets the value of the list field titles</value>
        public List<string> Id
        {
            get
            {
                return id;
            }
            set
            {
                if (value != null)
                {
                    id = value;
                }
                else
                {
                    id.Add("Missing data");
                }
            }
        }

        /// <summary>
        /// Overriding ToString to print a SearchResult Object
        /// </summary>
        /// <returns>A string representing A SearchResult Object</returns>
        public override string ToString()
        {
            string Output = null;
            var Movies = Titles.Zip(Years, (title, year) => title + " (" + year + ")");
            foreach (var Movie in Movies)
            {
                Output += Movie + "\n";
            }
            return "#### Movie Serach Results #####\n\n" + Output + "\n";
        }
    }
}