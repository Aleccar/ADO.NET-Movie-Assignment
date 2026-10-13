using ADO.NET_Movie_Assignment.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace ADO.NET_Movie_Assignment.Repositories
{
    public class GenreRepository
    {
        public static List<string> GetAllGenreNames(string connectionString)
        {
            using var connection = new SqlConnection(connectionString);
            connection.Open();

            string sqlQuery = "SELECT * FROM Genres";
            using var command = new SqlCommand(sqlQuery, connection);

            using var reader = command.ExecuteReader();

            List<string> genreList = new List<string>();
            while (reader.Read())
            {
                genreList.Add(reader.GetString(i: 1));
            }

            return genreList;
        }

        public static int GetGenreIdByName(string connectionString, string genreName)
        {
            using var connection = new SqlConnection(connectionString);
            connection.Open();

            string sqlQuery = "SELECT Id FROM Genres WHERE GenreName = @genreName";
            using var command = new SqlCommand(sqlQuery, connection);
            command.Parameters.AddWithValue("@genreName", genreName);

            using var reader = command.ExecuteReader();

            int id = 0;
            while (reader.Read())
            {
                id = reader.GetInt32(i: 0);
            }

            return id;
        }
    }
}
