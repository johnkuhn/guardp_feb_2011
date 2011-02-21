using System;
using System.Collections.Generic;
using nothinbutdotnetprep.infrastructure;

namespace nothinbutdotnetprep.collections
{
    public class MovieLibrary
    {
        IList<Movie> movies;

        public MovieLibrary(IList<Movie> list_of_movies)
        {
            this.movies = list_of_movies;
        }

        public IEnumerable<Movie> all_movies()
        {
            return movies.one_at_a_time();
        }

        public void add(Movie movie)
        {
            if (already_contains(movie)) return;

            movies.Add(movie);
        }

        bool already_contains(Movie movie)
        {
            return movies.Contains(movie);
        }

        public IEnumerable<Movie> all_movies_published_by_pixar()
        {
            //IList<Movie> tempMovies = new List<Movie>();

            //foreach (var m in movies)
            //{
            //    if (m.production_studio == ProductionStudio.Pixar)
            //        tempMovies.Add(m);
            //}

            //return tempMovies;

            return FilterMoviesByProdStudio(ProductionStudio.Pixar, true);
        }

        public IEnumerable<Movie> all_movies_not_published_by_pixar()
        {
            //IList<Movie> tempMovies = new List<Movie>();

            //foreach (var m in movies)
            //{
            //    if (m.production_studio != ProductionStudio.Pixar)
            //        tempMovies.Add(m);
            //}

            return FilterMoviesByProdStudio(ProductionStudio.Pixar, false);
        }

        public IList<Movie> FilterMoviesByProdStudio(ProductionStudio prodStudio, bool return_those_that_match)
        {
            IList<Movie> tempMovies = new List<Movie>();
            foreach (var m in movies)
            {
                if (return_those_that_match)
                {
                    if (m.production_studio == prodStudio)
                        tempMovies.Add(m);
                }
                else
                {
                    if (m.production_studio != prodStudio)
                    tempMovies.Add(m);
                }
                
            }

            return tempMovies;
        }

        public IEnumerable<Movie> all_action_movies()
        {
            IList<Movie> tempMovies = new List<Movie>();

            foreach (var m in movies)
            {
                if (m.genre == Genre.action)
                    tempMovies.Add(m);
            }

            return tempMovies;
        }

        public IEnumerable<Movie> all_movies_published_by_pixar_or_disney()
        {
            IList<Movie> tempMovies = new List<Movie>();

            foreach (var m in movies)
            {
                if (m.production_studio == ProductionStudio.Pixar || m.production_studio == ProductionStudio.Disney)
                    tempMovies.Add(m);
            }

            return tempMovies;
        }

        public IEnumerable<Movie> all_movies_published_after(int year)
        {
            IList<Movie> tempMovies = new List<Movie>();

            foreach (var m in movies)
            {
                if (m.date_published.Year > year)
                    tempMovies.Add(m);
            }

            return tempMovies;
        }

        public IEnumerable<Movie> all_movies_published_between_years(int startingYear, int endingYear)
        {
            IList<Movie> tempMovies = new List<Movie>();

            foreach (var m in movies)
            {
                if (m.date_published.Year >= startingYear && m.date_published.Year <= endingYear)
                    tempMovies.Add(m);
            }

            return tempMovies;
        }

        public IEnumerable<Movie> all_kid_movies()
        {
            IList<Movie> tempMovies = new List<Movie>();

            foreach (var m in movies)
            {
                if (m.genre == Genre.kids)
                    tempMovies.Add(m);
            }

            return tempMovies;
        }

        public IEnumerable<Movie> sort_all_movies_by_movie_studio_and_year_published()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Movie> sort_all_movies_by_date_published_descending()
        {
            var tempMovies = movies;

            for (var i = 0; i < tempMovies.Count - 1; i++)
            {
                for (var j = i + 1; j < tempMovies.Count; j++)
                {
                    var moviei = tempMovies[i];
                    var moviej = tempMovies[j];

                    if (moviej.date_published > moviei.date_published)
                    {
                        var temp = tempMovies[i];
                        tempMovies[i] = tempMovies[j];
                        tempMovies[j] = temp;
                    }
                }
            }

            return tempMovies;
        }

        public IEnumerable<Movie> sort_all_movies_by_date_published_ascending()
        {
            var tempMovies = movies;

            for (var i = 0; i < tempMovies.Count - 1; i++)
            {
                for (var j = i + 1; j < tempMovies.Count; j++)
                {
                    var moviei = tempMovies[i];
                    var moviej = tempMovies[j];

                    if (moviej.date_published < moviei.date_published)
                    {
                        var temp = tempMovies[i];
                        tempMovies[i] = tempMovies[j];
                        tempMovies[j] = temp;
                    }
                }
            }

            return tempMovies;
        }

        public IEnumerable<Movie> sort_all_movies_by_title_ascending
        {
            get
            {
                var tempMovies = movies;

                for (var i = 0; i < tempMovies.Count - 1; i++)
                {
                    for (var j = i + 1; j < tempMovies.Count; j++)
                    {
                        var moviei = tempMovies[i];
                        var moviej = tempMovies[j];

                        if (moviej.title.CompareTo(moviei.title) < 0)
                        {
                            var temp = tempMovies[i];
                            tempMovies[i] = tempMovies[j];
                            tempMovies[j] = temp;
                        }
                    }
                }

                return tempMovies;
            }
        }

        public IEnumerable<Movie> sort_all_movies_by_title_descending
        {
            get
            {
                var tempMovies = movies;

                for (var i = 0; i < tempMovies.Count - 1; i++)
                {
                    for (var j = i + 1; j < tempMovies.Count; j++)
                    {
                        var moviei = tempMovies[i];
                        var moviej = tempMovies[j];

                        if (moviej.title.CompareTo(moviei.title) > 0)
                        {
                            var temp = tempMovies[i];
                            tempMovies[i] = tempMovies[j];
                            tempMovies[j] = temp;
                        }
                    }
                }

                return tempMovies;
            }
        }
    }
}