using ADO.NET_Movie_Assignment.Models;
using Microsoft.Data.SqlClient;

namespace ADO.NET_Movie_Assignment.Repositories
{
    public class MovieRepository
    {
        public static void GetAllMovies()
        {
            string connectionString = "Server=localhost;Database=AdoMovies;Trusted_Connection=True;TrustServerCertificate=True;";

            using var connection = new SqlConnection(connectionString);
            connection.Open();

            string sqlQuery = "SELECT * FROM Movies";
            using var command = new SqlCommand(sqlQuery, connection);

            using var reader = command.ExecuteReader();

            List<Movies> movieList = new List<Movies>();
            while (reader.Read())
            {
                Movies newMovie = new Movies()
                {
                    Id = reader.GetInt32(i: 0),
                    GenreId = reader.GetInt32(i: 1),
                    MovieTitle = reader.GetString(i: 2)
                };
                movieList.Add(newMovie);
            }

            foreach (var movie in movieList)
            {
                Console.WriteLine($"{movie.Id} - {movie.GenreId} - {movie.MovieTitle}");
            }
            Console.ReadKey(true);
        }
        
    }
}
