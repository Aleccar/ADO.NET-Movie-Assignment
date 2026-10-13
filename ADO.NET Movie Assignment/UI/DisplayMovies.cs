using ADO.NET_Movie_Assignment.Models;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Text;

namespace ADO.NET_Movie_Assignment.UI
{
    public class DisplayMovies
    {
        public static void DisplayMovieTable(List<Movies> movieList)
        {
            var movieTable = new Table();

            movieTable.AddColumn("Id");
            movieTable.AddColumn("Titel");
            movieTable.AddColumn("Genre");

            foreach (var movie in movieList)
            {
                movieTable.AddRow(movie.Id.ToString(), movie.MovieTitle, movie.MovieGenre);
            }

            AnsiConsole.Write(movieTable);
            AnsiConsole.MarkupLine("[orange1]Tryck på valfri knapp för att återgå[/]");
            Console.ReadKey(true);
            Console.Clear();
        }

        public static void DisplayMoviesToDelete(List<Movies> movieList)
        {
            var movieTable = new Table();

            movieTable.AddColumn("Id");
            movieTable.AddColumn("Titel");
            movieTable.AddColumn("Genre");

            foreach (var movie in movieList)
            {
                movieTable.AddRow(movie.Id.ToString(), movie.MovieTitle, movie.MovieGenre);
            }
            AnsiConsole.Write(movieTable);
        }
    }
}
