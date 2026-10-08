using ADO.NET_Movie_Assignment.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ADO.NET_Movie_Assignment.Controllers
{
    public class MovieController
    {
        public static void GetAndShowAllMovies()
        {
            MovieRepository.GetAllMovies();

        }
    }
}
