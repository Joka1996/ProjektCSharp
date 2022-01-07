using System;

namespace MovieProject
{
    class Program
    {
        static void Main(string[] args)
        {
            //kalla på huvudmenyn
            StartMenu();
            static void StartMenu()
            {
                MainMenu();
                //Hämta alternativ
                var userInput = Console.ReadLine();
                //Startmeny
                while (true)
                {
                    switch (userInput)
                    {
                        case "1":
                            Console.Clear();
                            AddSeenMovieController();
                            break;
                        case "2":
                            Console.Clear();
                            AddNewMovieController();
                            break;
                        case "x":
                            ExitApp();
                            break;

                    }
                    //om användaren skriver en siffra som inte finns med i switch
                    Console.WriteLine("Välj alternativ 1-2");
                    userInput = Console.ReadLine();
                }
            }


            //funktion för att lägga till filmer som man sett
            static void AddSeenMovieController()
            {
                UserOptions();
                // Hämta användarens input
                var userInputSeen = Console.ReadLine();

                //instans 
                var seenMovie = new SeenMovie();

                // switchsats för kommandon.
                // Title, Grade Review
                while (true)
                {
                    switch (userInputSeen)
                    { 
                        //Lägg till en sedd film.
                        case "1":
                            Console.WriteLine("Titel:");
                            var title = Console.ReadLine();
                            Console.WriteLine("Ditt betyg 1-5:");
                            //konventera till int
                            var grade = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Recenssion:");
                            var review = Console.ReadLine();
                            //skicka till klassen SeenMovie och funktionen AddSeenMovie
                            seenMovie.AddSeenMovie(title, grade, review);
                            UserOptions();
                            break;
                        //Läs ut alla sedda filmer.
                        case "2":
                            //Hämta funktionen
                            Console.WriteLine("Sedda filmer:");
                            seenMovie.ReadSeenMovie();
                            break;
                        //sök efter sedd film
                        case "3":
                            Console.WriteLine("Ange en sökfras från filmens titel");
                            var searchPhrase = Console.ReadLine();
                            seenMovie.SearchForSeenMovie(searchPhrase);
                            break;
                        //Radera en sedd film
                        case "4":
                            Console.WriteLine("Ange det ID filmen har för att radera");
                            var delete = Convert.ToInt32(Console.ReadLine());
                            seenMovie.DeleteSeenMovie(delete);
                            UserOptions();
                            break;
                        //Rensa konsolen

                        case "5":
                            Console.Clear();
                            //Kalla på alternativen 
                            UserOptions();
                            break;

                        case "6":
                            StartMenu();
                            break;
                        //Stopppa applikationen
                        case "x":
                            ExitApp();
                            break;
                    }
                    //om användaren skriver en siffra som inte finns med i switch
                    Console.WriteLine("Välj alternativ 1-6");
                    userInputSeen = Console.ReadLine();
                }
            }
            //funktion för att lägga till nya filmer
            static void AddNewMovieController()
            {
                UserOptionsNew();
                var newMovie = new NewMovie();
                var userInputNew = Console.ReadLine();
                while (true)
                {
                    switch(userInputNew)
                    {
                        case "1":
                            Console.WriteLine("Titel:");
                            var title = Console.ReadLine();
                            Console.WriteLine("Betyg på IMDB:");
                            var imdb = Convert.ToDecimal( Console.ReadLine());
                            Console.WriteLine("Streamingtjänst:");
                            var stream = Console.ReadLine();
                            //skicka till 
                            newMovie.AddNewMovie(title, imdb, stream);
                            UserOptionsNew();
                            break;
                        case "2":
                            Console.WriteLine("Filmer som ska ses:");
                            newMovie.ReadNewMovies();
                            break;
                        case "3":
                            Console.WriteLine("Ange filmens titel:");
                            var searchPhrase = Console.ReadLine();
                            newMovie.SearchForNewMovie(searchPhrase);
                            break;
                        case "4":
                            Console.WriteLine("ID du vill radera:");
                            var delete = Convert.ToInt32( Console.ReadLine());
                            //skicka till klassen
                            newMovie.DeleteNewMovie(delete);
                            break;
                        case "5":
                            Console.Clear();
                            UserOptionsNew();
                            break;
                        case "6":

                            StartMenu();
                            break;
                        case "x":
                            ExitApp();
                            break;
                    }
                    //om användaren skriver en siffra som inte finns med i switch
                    Console.WriteLine("Välj alternativ 1-6");
                    userInputNew = Console.ReadLine();
                }
            }
            //Huvudmeny
            static void MainMenu()
            {
                Console.Clear();
                Console.WriteLine("Hej från FilmBasen, Här kan du spara filmer du sett, ge betyg och recenssion.\nMen även lägga till filmer som vill se i framtiden.\n");
                Console.WriteLine("Alternativ:");
                Console.WriteLine("1. Gå till sedda filmer");
                Console.WriteLine("2. Gå till filmer som ska ses.\n");

                Console.WriteLine("x. Avsluta applikation");
            }
            //Kontroller för filmer att se
            static void UserOptionsNew()
            {
                Console.Clear();
                Console.WriteLine("Filmer som ska ses\n");
                Console.WriteLine("Alternativ:");
                Console.WriteLine("1.Lägg till en Film du vill se");
                Console.WriteLine("2.Se alla filmer du vill se");
                Console.WriteLine("3.Sök bland filmer \nSök efter TITEL. OBS Känslig för stor/liten bokstav");
                Console.WriteLine("4.Radera film du sett efter index\n");
                Console.WriteLine("5.Rensa konsolen\n");

                Console.WriteLine("6.Huvudmeny \n");

                Console.WriteLine("x.Avsluta applikationen\n");
            }

            //kontroller för sedda filmer
            static void UserOptions()
            {
                Console.Clear();
                //kommandon 
                Console.WriteLine("Sedda filmer \n");
                Console.WriteLine("Alternativ:");
                Console.WriteLine("1.Lägg till en Film du sett");
                Console.WriteLine("2.Visa alla filmer du sett");
                Console.WriteLine("3.Sök bland filmer \nSök efter TITEL. OBS Känslig för stor/liten bokstav");
                Console.WriteLine("4.Radera film du sett efter index\n");

                Console.WriteLine("5.Rensa konsolen\n");

                Console.WriteLine("6.Huvudmeny\n");

                Console.WriteLine("x. Avsluta applikationen\n ");

            }
            //stäng appen
            static void ExitApp()
            {
                Environment.Exit(0);
            }
        }
    }
}
