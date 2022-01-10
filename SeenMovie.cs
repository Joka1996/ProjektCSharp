using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace MovieProject
{
    public class SeenMovie
    {
        //hämta textfil att spara filmerna i 
        string filePath = "seenMovies.txt";

        public void AddSeenMovie(string title, int grade, string rewatch, string review )
        {
            var seenMovie = new SeenMoviesClass();
         
            // inga tomma fält
            if(title == "" || grade < 0 || grade > 5 || review == "" || rewatch == "")
            {
                Console.WriteLine("Ej tillåtet att addera tomma inlägg, eller betyg över 5");
               
            } else
            {
                seenMovie.SeenList.Add(new SeenMoviesClass { Title = title, Grade = grade, Review = review, Rewatch = rewatch });
                Console.WriteLine("Film: " + title + " är tillagd.");
                // skapa fil om den inte finns och skriv ett meddelande till konsolen.
                if (!File.Exists(filePath))
                {
                    using (StreamWriter sw = File.CreateText(filePath))
                    {
                        Console.WriteLine("Textfil 'seenMovies.txt' har skapats och finns: bin/debug/netcoreapp3.1/seenMovies.txt");
                     
                    }

                }
                //lägg till den nya filmen i txt-filen.
                using (StreamWriter sw = File.AppendText(filePath))
                {
                    sw.WriteLine("Film: "  + title + " - " + "Betyg:" + grade + "/5" + " - " + "Titta om?:" + rewatch + " - " + "Recenssion: " + review + "|");
                    sw.Close();
                }
            }
            //rensa konsolen 
            System.Threading.Thread.Sleep(3000);
            Console.Clear();
        }
        //Läs ut lagrade filmer
        public void ReadSeenMovie()
        {
            //kontrollera om den sparade filen finns
            if(!File.Exists(filePath))
            {
                Console.WriteLine("Det finns ännu inga filmer tillagda, lägg till en film du sett eller har sett.");
            } else
            {
                // läs in textfilen som array, loopa igenom och lägg till ett index. 
                string[] movies = File.ReadAllLines(filePath);
                if(movies.Length == 0)
                {
                    // om filen finns men inga inlägg:
                    Console.WriteLine("Inga filmer i text-filen");

                } else
                {
                    for (int i = movies.GetLowerBound(0); i <= movies.GetUpperBound(0); i++)
                    //skriv ut innehållet från textfilen
                    Console.WriteLine("[{0,2}]: {1}", i, movies[i]);
                }
            }
        }

        //ta bort en lagrad film
        public void DeleteSeenMovie(int delete)
        {

            //kontroll om filen existerar eller inte.

            if (!File.Exists(filePath))
            {
                Console.WriteLine("Finns ännu inga lagrade filmer.");
            } else
            {
                List<string> ReadFile = File.ReadAllLines(filePath).ToList();

                //radera på angivet ID/Index
                ReadFile.RemoveAt(delete);
                Console.WriteLine($"Film med ID nr:[{delete}] är raderad");
                //ersätt den gamla txt-filen med den uppdaterad
                File.WriteAllLines(filePath, ReadFile);

                //Rensa konsolen efter fyra sekunder.
                System.Threading.Thread.Sleep(4000);
                Console.Clear();
            }

        }

        //sök efter en film, söker egentligen i hela dokumentet efter matchningar så blir brett. 
        public void SearchForSeenMovie(string searchPhrase)
        {

            //kontroll om filen existerar eller inte.
            if (!File.Exists(filePath))
            {
                Console.WriteLine("Finns ännu inga lagrade filmer.");
            }
            else
            {
                //för att kunna stoppa foreachloopen och endast skriva ut ett felmeddelande.
                var testWasTrue = false;

                List<string> ReadFile = File.ReadAllLines(filePath).ToList();

                //skapa en ny lista som ska vara filtrerad
                var filterd = new List<string>();
                //loopa igenom den första listan med alla filmer
                foreach (var movie in ReadFile)
                {
                    if (movie.Contains(searchPhrase))
                    {
                        //om listan innehåller något med sökfrasen, addera den till den nya listan 
                        filterd.Add(movie);
                        //skriv ut den nya listan i konsolen
                        Console.WriteLine("Resultat: " + string.Join(",", filterd) + "\n");
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
