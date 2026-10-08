using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Text;

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
                    .Title("[orange]---[/] Filmregister [orange]---[/]:")
                    .AddChoices("Visa alla filmer", "Sök filmer efter genre", "Lägg till film", "Ta bort film", "Avsluta"));
            }

        }
    }
}
