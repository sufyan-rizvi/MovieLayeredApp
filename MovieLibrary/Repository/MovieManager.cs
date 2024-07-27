using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieLibrary.Exceptions;
using MovieLibrary.Models;
using MovieLibrary.Services;

namespace MovieLibrary.Repository
{
    public class MovieManager
    {
        public static int MAX_MOVIES { get; } = 5;
        public static List<Movie> movies = new List<Movie>();
        static Movie findMovie;

        public MovieManager()
        {
            movies = DataSerializer.Deserialize();
        }


        public static Movie FindMovieByID(int id)
        {
            findMovie = movies.Where(movie => movie.Id == id).FirstOrDefault()!;
            if (findMovie == null)
                throw new MovieNotFoundException("No Movie with the specified ID !");
            return findMovie;
        }

        public static List<Movie> DisplayAllMovies()
        {
            if (movies.Count == 0)//Ask maam
                throw new MovieStoreEmptyException("No Movies in the store ! ");
            return movies;
        }

        public static void AddMovie(int id, int year, string name, string genre)
        {
            movies.Add(new Movie { Id = id, Name = name, YearOfRelease = year, Genre = genre });
        }

        public static void RemoveMovie(int id)
        {
            findMovie = FindMovieByID(id);
            movies.Remove(findMovie);
        }

        public static void ClearAllMovies()
        {
            if (movies.Count == 0)
                throw new MovieStoreEmptyException("No movies in store ! Nothing to Clear !");
            movies.Clear();
        }

        public static void SerializeMovie()
        {
            DataSerializer.Serialize(movies);
        }

        public static void ListIsFull()
        {
            if (movies.Count >= MAX_MOVIES)
                throw new CapacityFullException("The List is Full ! Cannot add a new movie !");
        }
    }
}
