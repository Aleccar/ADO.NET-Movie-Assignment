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
                var choice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("[orange1]---[/] Filmregister [orange1]---[/]:")
                    .WrapAround()
                    .HighlightStyle(new Style(Color.Orange1, Color.Black, Decoration.Bold))
                    .AddChoices("Visa alla filmer", "Sök filmer efter genre", "Lägg till film", "Ta bort film", "Avsluta"));

                switch (choice)
                {
                    case "Visa alla filmer":
                        MovieController.GetAndShowAllMovies();
                        break;
                    case "Sök filmer efter genre":
                        break;
                    case "Lägg till film":
                        break;
                    case "Ta bort film":
                        break;


                    case "Avsluta":
                        isRunning = false;
                        break;
                    
                    default:
                        break;
                }


            }

        }
    }
}
