using ADO.NET_Movie_Assignment.Repositories;
using ADO.NET_Movie_Assignment.UI;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Text;

namespace ADO.NET_Movie_Assignment.Controllers
{
    public class InputController
    {
        private static readonly string _connectionString = "Server=localhost;Database=AdoMovies;Trusted_Connection=True;TrustServerCertificate=True;";
        public static void GetAndShowAllMovies()
        {
            var movieList = MovieRepository.GetAllMovies(_connectionString);
            DisplayMovies.DisplayMovieTable(movieList);
        }

        public static void GetMoviesByGenre()
        {
            var genreList = GenreRepository.GetAllGenreNames(_connectionString);

            var selected = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                .Title("Vilken genre vill du se filmer från?")
                .HighlightStyle(new Style(Color.Orange1, Color.Black, Decoration.Bold))
                .AddChoices(genreList));

            var genreId = GenreRepository.GetGenreIdByName(_connectionString, selected);
            var movieList = MovieRepository.GetAllMoviesByGenreId(_connectionString, genreId);
            DisplayMovies.DisplayMovieTable(movieList);
        }

        public static void CreateNewMovie()
        {
            var newMovieTitle = "";

            bool askForMovieTitle = true;
            while (askForMovieTitle)
            {
                newMovieTitle = AnsiConsole.Ask<string>("Ange titel på filmen: ");

                AnsiConsole.MarkupLine($"Du angav \"{newMovieTitle}\"");

                if (AnsiConsole.Confirm("Är detta korrekt?"))
                {
                    askForMovieTitle = false;
                }
            }

            var newMovieGenreId = 0;
            bool askForMovieGenre = true;
            while (askForMovieGenre)
            {
                var genreList = GenreRepository.GetAllGenreNames(_connectionString);

                var selected = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                    .Title("Vilken genre tillhör filmen?")
                    .HighlightStyle(new Style(Color.Orange1, Color.Black, Decoration.Bold))
                    .AddChoices(genreList));

                AnsiConsole.MarkupLine($"Du angav \"{selected}\"");

                if (AnsiConsole.Confirm("Är detta korrekt?"))
                {
                    newMovieGenreId = GenreRepository.GetGenreIdByName(_connectionString, selected);
                    askForMovieGenre = false;
                }
            }

            MovieRepository.AddMovie(_connectionString, newMovieTitle, newMovieGenreId);
        }

        public static void DeleteMovie()
        {
            var listOfAllMovies = MovieRepository.GetAllMovies(_connectionString);

            var deleteMovieConfirm = true;
            while (deleteMovieConfirm)
            {
                Console.Clear();
                DisplayMovies.DisplayMoviesToDelete(listOfAllMovies);

                var idToRemove = AnsiConsole.Ask<int>("Välj ID på den film du vill ta bort: ");

                AnsiConsole.MarkupLine($"Du angav \"{idToRemove}\"");
                if (AnsiConsole.Confirm("Är detta korrekt?"))
                {
                    MovieRepository.DeleteMovieById(_connectionString, idToRemove);
                    deleteMovieConfirm = false;
                }
                else
                {
                    deleteMovieConfirm = false;
                }
            }


        }
    }
}
