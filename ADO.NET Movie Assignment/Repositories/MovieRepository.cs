using ADO.NET_Movie_Assignment.Models;
using Microsoft.Data.SqlClient;
using Spectre.Console;

namespace ADO.NET_Movie_Assignment.Repositories
{
    public class MovieRepository
    {
        public static List<Movies> GetAllMovies(string connectionString)
        {
            using var connection = new SqlConnection(connectionString);
            connection.Open();

            string sqlQuery = "SELECT Movies.Id, Movies.MovieTitle, Genres.GenreName FROM Movies INNER JOIN Genres ON Movies.GenreId= Genres.Id";
            using var command = new SqlCommand(sqlQuery, connection);

            using var reader = command.ExecuteReader();

            List<Movies> movieList = new List<Movies>();
            while (reader.Read())
            {
                Movies newMovie = new Movies()
                {
                    Id = reader.GetInt32(i: 0),
                    MovieTitle = reader.GetString(i: 1),
                    MovieGenre = reader.GetString(i: 2)
                };
                movieList.Add(newMovie);
            }

            return movieList;
        }

        public static List<Movies> GetAllMoviesByGenreId(string connectionString, int genreId)
        {
            using var connection = new SqlConnection(connectionString);
            connection.Open();

            string sqlQuery = "SELECT Movies.Id, Movies.MovieTitle, Genres.GenreName FROM Movies INNER JOIN Genres ON Movies.GenreId= Genres.Id WHERE GenreId = @genreId";
            using var command = new SqlCommand(sqlQuery, connection);
            command.Parameters.AddWithValue("@genreId", genreId);

            using var reader = command.ExecuteReader();

            List<Movies> movieList = new List<Movies>();
            while (reader.Read())
            {
                Movies newMovie = new Movies()
                {
                    Id = reader.GetInt32(i: 0),
                    MovieTitle = reader.GetString(i: 1),
                    MovieGenre = reader.GetString(i: 2)
                };
                movieList.Add(newMovie);
            }

            return movieList;
        }

        public static void AddMovie(string connectionString, string movieTitle, int genreId)
        {
            using var connection = new SqlConnection(connectionString);
            connection.Open();

            string sqlQuery = "INSERT INTO Movies (MovieTitle, GenreId) VALUES (@MovTitle, @MovGenre)";
            using var command = new SqlCommand(sqlQuery, connection);
            command.Parameters.AddWithValue("@MovTitle", movieTitle);
            command.Parameters.AddWithValue("@MovGenre", genreId);

            int rowsAffected = command.ExecuteNonQuery();
            AnsiConsole.MarkupLine($"{rowsAffected} [orange1]{movieTitle}[/] tillagd");
            Console.WriteLine("Tryck på valfri knapp för att återgå.");
            Console.ReadKey(true);
        }

        public static void DeleteMovieById(string connectionString, int movieId)
        {
            using var connection = new SqlConnection(connectionString);
            connection.Open();

            string sqlQuery = "DELETE FROM Movies WHERE Id = @Id";
            using var command = new SqlCommand(sqlQuery, connection);
            command.Parameters.AddWithValue("@Id", movieId);

            int rowsAffected = command.ExecuteNonQuery();
            if (rowsAffected == 0)
            {
                AnsiConsole.MarkupLine($"Filmen med id [orange1]{movieId}[/] finns ej...");
            }
            else
            {
                AnsiConsole.MarkupLine($"{rowsAffected} Filmen med id [orange1]{movieId}[/] är borttagen");
            }
            Console.WriteLine("Tryck på valfri knapp för att återgå.");
            Console.ReadKey(true);
        }
    }
}
