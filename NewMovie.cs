using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace MovieProject
{
   public class NewMovie
    {
        string filePath = "newMovie.txt";
        //lägg till ny film att se
        public void AddNewMovie(string title, decimal imdb, string stream)
        {
            var newMovie = new NewMovieClass();
            // kontroll efter tomma inlägg
            if(title == "" || imdb < 0 || imdb > 10 || stream =="" )
            {
                Console.WriteLine("Inga tomma inlägg samt inget större värde än 10.");
            }
            else
            {
                //addera till  listan
                newMovie.NewList.Add(new NewMovieClass { Title = title, Imdb = imdb, Stream = stream });
                Console.WriteLine("Film: " + title + " är tillagd.");
                
                //kontroll om txt-filen finns, annars skapa en.
                if(!File.Exists(filePath))
                {
                    using(StreamWriter sw = File.CreateText(filePath))
                    {
                        Console.WriteLine("Textfil 'newMovie.txt' har skapats och finns: bin/debug/netcoreapp3.1/newMovie.txt");
                    }
                }

                // lägg till i txt filen. Appends används för att kunna addera nytt innehåll.
                using(StreamWriter sw= File.AppendText(filePath))
                {
                    sw.WriteLine("Film: " + title + " - " + "IMDB: " + imdb  + "/10" + " - " + "Streamingtjänst: " + stream + " |");
                    sw.Close();
                }
            }
            //rensa konsolen 
            System.Threading.Thread.Sleep(4000);
            Console.Clear();
        }
        //läs ut alla filmer 
        public void ReadNewMovies()
        {
            //kontrollera om den sparade filen finns
            if (!File.Exists(filePath))
            {
                Console.WriteLine("Det finns ännu inga filmer tillagda, lägg till en film du sett.");
            }
            else
            {
                // läs in textfilen som array, loopa igenom och lägg till ett index.  en if om txt-filen finns men inget innehåll.
                string[] movies = File.ReadAllLines(filePath);
                if (movies.Length == 0)
                {
                    // om filen finns men inga inlägg:
                    Console.WriteLine("Inga filmer i text-filen");

                }
                else
                {
                    for (int i = movies.GetLowerBound(0); i <= movies.GetUpperBound(0); i++)
                        //skriv ut innehållet från textfilen
                        Console.WriteLine("[{0,2}]: {1}", i, movies[i]);
                }
            }
        }
        //radera efter index 
        public void DeleteNewMovie(int delete)
        {
            //kontroll om filen existerar eller inte.

            if (!File.Exists(filePath))
            {
                Console.WriteLine("Finns ännu inga lagrade filmer.");
            }
            else
            {
                List<string> ReadFile = File.ReadAllLines(filePath).ToList();
                ReadFile.RemoveAt(delete);
                Console.WriteLine($"Film med ID nre:[{delete}] är raderad");
                //ersätt den gamla txtfilen med ny
                File.WriteAllLines(filePath, ReadFile);

                //Rensa konsolen efter fyra sekunder.
                System.Threading.Thread.Sleep(4000);
                Console.Clear();
            }

        }
        //sök efter film
        public void SearchForNewMovie(string searchPhrase)
        {
            //kontroll om filen existerar eller inte.
            if(!File.Exists(filePath))
            {
                Console.WriteLine("Finns ännu inga lagrade filmer.");
            } else
            {
                // en simplare lösning för att söka
                List<string> ReadFile = File.ReadAllLines(filePath).ToList();
                var testWasTrue = false;

                foreach (var movie in ReadFile)
                {
                    if (movie.Contains(searchPhrase))
                    {
                        Console.WriteLine($"Resultat: {movie}\n");
                        Console.WriteLine("Inget resultat eller för många? Gör en specifikare sökning.\n");
                        testWasTrue = true;
                        break;
                    }
                }
                if (!testWasTrue)
                {
                    Console.WriteLine("Inget resultat, kontrollera stor/liten bokstav.");
                }
            }
           

        }

    }
}
