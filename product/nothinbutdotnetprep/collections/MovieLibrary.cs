using System;
using System.Collections.Generic;
using System.Threading;

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
            return movies;
        }

        public void add(Movie movie)
        {
            int matches = 0;
            foreach (Movie m in movies)
                if (m.title == movie.title)
                    matches++;

            if(matches == 0)
                movies.Add(movie);
            
        }

        public IEnumerable<Movie> sort_all_movies_by_title_descending
        {
            get
            {
                IList<Movie> tempMovies = movies;

                for (int i = 0; i < tempMovies.Count - 1; i++)
                {
                    for (int j = i + 1; j < tempMovies.Count; j++)
                    {
                        Movie moviei = tempMovies[i];
                        Movie moviej = tempMovies[j];

                        if(moviej.title.CompareTo(moviei.title) > 0)
                        {
                            Movie temp = tempMovies[i];
                            tempMovies[i] = tempMovies[j];
                            tempMovies[j] = temp;
                        }
                    }
                }

                return tempMovies;
            }
        }

        public IEnumerable<Movie> all_movies_published_by_pixar()
        {
            IList<Movie> tempMovies = new List<Movie>();

            foreach(Movie m in movies)
            {
                if(m.production_studio == ProductionStudio.Pixar)
                    tempMovies.Add(m);
            }

            return tempMovies;
        }

        public IEnumerable<Movie> all_movies_published_by_pixar_or_disney()
        {
            IList<Movie> tempMovies = new List<Movie>();

            foreach (Movie m in movies)
            {
                if (m.production_studio==ProductionStudio.Pixar || m.production_studio == ProductionStudio.Disney)
                    tempMovies.Add(m);
            }

            return tempMovies;
        }

        public IEnumerable<Movie> sort_all_movies_by_title_ascending
        {
            get
            {
                IList<Movie> tempMovies = movies;

                for (int i = 0; i < tempMovies.Count - 1; i++)
                {
                    for (int j = i + 1; j < tempMovies.Count; j++)
                    {
                        Movie moviei = tempMovies[i];
                        Movie moviej = tempMovies[j];

                        if (moviej.title.CompareTo(moviei.title) < 0)
                        {
                            Movie temp = tempMovies[i];
                            tempMovies[i] = tempMovies[j];
                            tempMovies[j] = temp;
                        }
                    }
                }

                return tempMovies;
            }
        }

        public IEnumerable<Movie> sort_all_movies_by_movie_studio_and_year_published()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Movie> all_movies_not_published_by_pixar()
        {
            IList<Movie> tempMovies = new List<Movie>();

            foreach (Movie m in movies)
            {
                if (m.production_studio != ProductionStudio.Pixar)
                    tempMovies.Add(m);
            }

            return tempMovies;
        }

        public IEnumerable<Movie> all_movies_published_after(int year)
        {
            IList<Movie> tempMovies = new List<Movie>();

            foreach (Movie m in movies)
            {
                if (m.date_published.Year > year)
                    tempMovies.Add(m);
            }

            return tempMovies;
        }

        public IEnumerable<Movie> all_movies_published_between_years(int startingYear, int endingYear)
        {
            IList<Movie> tempMovies = new List<Movie>();

            foreach (Movie m in movies)
            {
                if (m.date_published.Year >= startingYear && m.date_published.Year <= endingYear)
                    tempMovies.Add(m);
            }

            return tempMovies;
        }

        public IEnumerable<Movie> all_kid_movies()
        {
            IList<Movie> tempMovies = new List<Movie>();

            foreach (Movie m in movies)
            {
                if (m.genre == Genre.kids)
                    tempMovies.Add(m);
            }

            return tempMovies;
        }

        public IEnumerable<Movie> all_action_movies()
        {
            IList<Movie> tempMovies = new List<Movie>();

            foreach (Movie m in movies)
            {
                if (m.genre == Genre.action)
                    tempMovies.Add(m);
            }

            return tempMovies;
        }

        public IEnumerable<Movie> sort_all_movies_by_date_published_descending()
        {
            IList<Movie> tempMovies = movies;

            for (int i = 0; i < tempMovies.Count - 1; i++)
            {
                for (int j = i + 1; j < tempMovies.Count; j++)
                {
                    Movie moviei = tempMovies[i];
                    Movie moviej = tempMovies[j];

                    if (moviej.date_published > moviei.date_published)
                    {
                        Movie temp = tempMovies[i];
                        tempMovies[i] = tempMovies[j];
                        tempMovies[j] = temp;
                    }
                }
            }

            return tempMovies;
        }

        public IEnumerable<Movie> sort_all_movies_by_date_published_ascending()
        {
            IList<Movie> tempMovies = movies;

            for (int i = 0; i < tempMovies.Count - 1; i++)
            {
                for (int j = i + 1; j < tempMovies.Count; j++)
                {
                    Movie moviei = tempMovies[i];
                    Movie moviej = tempMovies[j];

                    if (moviej.date_published < moviei.date_published)
                    {
                        Movie temp = tempMovies[i];
                        tempMovies[i] = tempMovies[j];
                        tempMovies[j] = temp;
                    }
                }
            }

            return tempMovies;
        }
    }
}