using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1;

namespace SampleConsleApp
{
    class Movie
    {

        public int MovieId { get; set; }
        public string MovieName { get; set; }
        public string MovieDirector { get; set; }
        public string MovieReleaseDate { get; set; }

    }
    class MovieManager
    {
        private Movie[] _MovieData = null;
        private int _size = 0;
        public void disp()
        {

            foreach (Movie item in _MovieData)
            {
                Console.WriteLine($"{item.MovieId} {item.MovieName} {item.MovieReleaseDate} {item.MovieDirector}");

            }
        }
        public MovieManager(int size)
        {
            _size = size;
            _MovieData = new Movie[_size];
        }
        public void AddNewMovie(Movie mv)
        {
            for (int i = 0; i < _size; i++)
            {
                if (_MovieData[i] == null)
                {
                    _MovieData[i] = new Movie { MovieId = mv.MovieId, MovieName = mv.MovieName, MovieDirector = mv.MovieDirector, MovieReleaseDate = mv.MovieReleaseDate };

                    return;
                }

            }
        }
        public void UpdateMovieDetails(Movie mv)
        {
            for (int i = 0; i < _size; i++)
            {
                if (_MovieData[i] != null && _MovieData[i].MovieId == mv.MovieId)
                {
                    _MovieData[i].MovieName = mv.MovieName;
                    _MovieData[i].MovieDirector = mv.MovieDirector;
                    _MovieData[i].MovieReleaseDate = mv.MovieReleaseDate;
                    return;

                }
            }
            throw new Exception("Movie Not Found to Update");

        }

        public void DeleteMovie(int id)
        {
            for (int i = 0; i < _size; i++)
            {
                if (_MovieData[i] != null && _MovieData[i].MovieId == id)
                {
                    _MovieData[i] = null;
                    return;

                }

            }
            throw new Exception("Movie Not Found to Delete");
        }
        public Movie FindMovie(int id)
        {
            foreach (Movie mv in _MovieData)
            {
                if (mv != null && mv.MovieId == id)
                {
                    return mv;
                }

            }
            throw new Exception("Movie Not Found to");
        }
    }
    class MovieUI
    {
        public const string menu = "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~MOVIE DATABASE SOFTWARE~~~~~~~~~~~~~~~~~~~\nTO ADD NEW MOVIE------------------------>PRESS 1\nTO UPDATE EXISTING ACCOUNT---------------->PRESS 2\nTO FIND MOVIE BY ID----------------->PRESS 3\nTO DELETE MOVIE------------------>PRESS 4\nPS: ANY OTHER KEY IS CONSIDERED AS EXIT.....................................";
        public static MovieManager mvd = null;
        internal static void DisplayMenu(string file)
        {
            int size = Utilities.GetNumber("Enter the size");
            mvd = new MovieManager(size);
            bool processing = true;
            //string menu = File.ReadAllText(file);
            do
            {
                int choice = Utilities.GetNumber(menu);
                processing = processMenu(choice);

            } while (processing);
            Console.WriteLine("Thanks for using our application");
        }
        private static bool processMenu(int choice)
        {
            switch (choice)
            {
                case 1:
                    addingAccountHelper();
                    break;
                case 2:
                    updatingAccountHelper();
                    break;
                case 3:
                    findingAccountHelper();
                    break;
                case 4:
                    deleteAccountHelper();
                    break;

                default:
                    return false;

            }
            return true;
        }
        private static void addingAccountHelper()
        {
            int MovieId = Utilities.GetNumber("Enter the Id of the MovieId");
            string MovieName = Utilities.Prompt("Enter the Name of MovieName");
            string MovieDirector = Utilities.Prompt("Enter the Name of MovieDirector");
            string MovieReleaseDate = Utilities.Prompt("Enter the Name of MovieReleaseDate");
            Movie mv = new Movie { MovieId = MovieId, MovieName = MovieName, MovieDirector = MovieDirector, MovieReleaseDate = MovieReleaseDate };
            mvd.AddNewMovie(mv);
            Utilities.Prompt("Press Enter to clean the Screen");
            Console.Clear();
        }
        private static void updatingAccountHelper()
        {
            int MovieId = Utilities.GetNumber("Enter the Id of the MovieId");
            string MovieName = Utilities.Prompt("Enter the Name of MovieName");
            string MovieDirector = Utilities.Prompt("Enter the Name of MovieDirector");
            string MovieReleaseDate = Utilities.Prompt("Enter the Name of MovieReleaseDate");
            Movie mv = new Movie { MovieId = MovieId, MovieName = MovieName, MovieDirector = MovieDirector, MovieReleaseDate = MovieReleaseDate };
            try
            {
                mvd.UpdateMovieDetails(mv);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message); ;
            }

            Utilities.Prompt("Press Enter to clear the Screen");
            Console.Clear();


        }
        private static void findingAccountHelper()
        {
            int id = Utilities.GetNumber("Enter the ID of the Account to Find");
            try
            {
                Movie mv = mvd.FindMovie(id);
                Console.WriteLine("The Details of the Movie as follows:");
                string content = $"The Movie Name: {mv.MovieName}\nThe Movie Director  : {mv.MovieDirector}\nThe Movie ReleaseDate: {mv.MovieReleaseDate}\n";
                Console.WriteLine(content);
                Utilities.Prompt("Press Enter to clear the Screen");
                Console.Clear();


            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }


        }
        private static void deleteAccountHelper()
        {
            int id = Utilities.GetNumber("Enter the ID of the Account to Delete");
            try
            {
                mvd.DeleteMovie(id);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message); ;
            }

        }
    }

    class MovieDatabase
    {
        static void Main(string[] args)
        {

            MovieManager mv = new MovieManager(1);
            MovieUI.DisplayMenu(args[0]);


            mv.AddNewMovie(new Movie
            {
                MovieId = 1,
                MovieName = "movie",
                MovieDirector = "unknown",
                MovieReleaseDate = "12/05/2022"
            });
            mv.disp();
            mv.UpdateMovieDetails(new Movie
            {
                MovieId = 1,
                MovieName = "movie123",
                MovieDirector = "unknownv bv",
                MovieReleaseDate = "12/05/2012"
            });
            mv.disp();



        }
    }
}

