using ADO.NET_Movie_Assignment.Controllers;
using Spectre.Console;

namespace ADO.NET_Movie_Assignment
{
    public class App
    {
        public void Run()
        {

            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                var choice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("[orange1]---[/] Filmregister [orange1]---[/]:")
                    .WrapAround()
                    .HighlightStyle(new Style(Color.Orange1, Color.Black, Decoration.Bold))
                    .AddChoices("Visa alla filmer", "Sök filmer efter genre", "Lägg till film", "Ta bort film", "Avsluta"));

                switch (choice)
                {
                    case "Visa alla filmer":
                        InputController.GetAndShowAllMovies();
                        break;
                    case "Sök filmer efter genre":
                        InputController.GetMoviesByGenre();
                        break;
                    case "Lägg till film":
                        InputController.CreateNewMovie();
                        break;
                    case "Ta bort film":
                        InputController.DeleteMovie();
                        break;


                    case "Avsluta":
                        isRunning = false;
                        break;
                    
                    default:
                        break;
                }
            }

            AnsiConsole.MarkupLine("[orange1]Tack för att du använt vårt filmregister[/]");
        }
    }
}
