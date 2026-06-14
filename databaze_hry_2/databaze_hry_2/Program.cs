using System.ComponentModel.Design;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;

namespace databaze_hry_2
{
    internal class Program
    {
        //Zadani: Napsat pridavani do Listu clanku, vyhledavani hry v listu, Filtrování her podle žánru, Úprava údajů o hře, Smazání hry, Seřazení her podle názvu nebo hodnocení, Zobrazení statistik: pocet her, prumer hodnoceni, nejlepe hodnocena hra.
        
        static Random rnd = new Random();
        static void Main(string[] args)
        {
            
            List<Hry> soubor = new List<Hry>();
            
            
            string[] radky = File.ReadAllLines("hry.txt");
            bool pravda = true;
            foreach (string radek in radky)
            {
                string[] data = radek.Split(';');

                Hry hra = new Hry
                {
                    ID = int.Parse(data[0]),
                    Nazev = data[1],
                    Zanr = data[2],
                    StavHry = data[3],
                    Hodnoceni = int.Parse(data[4]),
                    Cena = int.Parse(data[5])
                };

                soubor.Add(hra);
            }
            
            
            while (pravda == true)
            {
                Hry hra = new Hry();
                
                Menu();
                int vyber = 0;
                while (!int.TryParse(Console.ReadLine(),out vyber))
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("PIS JENOM CISLA!");
                    Console.ResetColor();
                }
                while (vyber < 1 || vyber > 9)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("CISLO OD 1 DO 9!");
                    Console.ResetColor();
                    vyber = 0;
                    while (!int.TryParse(Console.ReadLine(), out vyber))
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("PIS JENOM CISLA!");
                        Console.ResetColor();
                    }
                }
                if (vyber == 1)
                {
                    Console.Clear();
                    VypisHer(soubor);
                }
                else if (vyber==2)
                {
                    Console.Clear();
                    PridavaniHry(soubor);
                }
                else if (vyber ==3)
                {
                    Console.Clear();
                    VypisHer(soubor);
                    NajitPodleNazvy(soubor);
                }
                else if (vyber==4)
                {
                    Console.Clear();
                    VypisHer(soubor);
                    FiltrovaniSouboru(soubor);
                }
                else if (vyber==5)
                {
                    Console.Clear();
                    VypisHer(soubor);
                    UpravaUdaju(soubor);
                }
                else if (vyber==6)
                {
                    Console.Clear();
                    VypisHer(soubor);
                    SmazaniHry(soubor);
                }
                else if (vyber==7)
                {
                    Console.Clear();
                    SerazeniPodleHodnoceni(soubor);
                }
                else if (vyber==8)
                {
                    Console.Clear();
                    Statistika(soubor);
                }
                else if (vyber==9)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Koncim a ukladam do souboru");
                    Konec(soubor);
                    pravda = false;
                }
                if (pravda==true)
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\ndejte ENTER pro prechod do MENU");
                    Console.ResetColor();
                    string enter = Console.ReadLine();
                }
                
            }
        }

        static void VypisHer(List<Hry> soubor)
        {
            foreach (Hry hra in soubor)
            {
                for (int i = 0; i < soubor.Count; i++)
                {
                    soubor[i].ID = i + 1;
                }
                Console.WriteLine();
                Console.Write($" | ID hry: ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(hra.ID);
                Console.ResetColor();
                Console.Write($" | Nazev hry : ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(hra.Nazev);
                Console.ResetColor();
                Console.Write($" | Zanr hry: ");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write(hra.Zanr);
                Console.ResetColor();
                Console.Write($" | Stav hry: ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(hra.StavHry);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.ResetColor();
                Console.Write($" | Hodnoceni: ");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(hra.Hodnoceni);
                Console.ResetColor();
                Console.Write($" |Cena hry Kč: ");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine(hra.Cena);
                Console.ResetColor();

                //vymen mistama hodnoty a cw blbe vypada
            }
            Console.WriteLine("\n");
        }
        static List<Hry> PridavaniHry(List<Hry> list)
        {
            Hry hra2 = new Hry();

            Console.WriteLine($" Pridej novou hru do souboru:\n");
            Console.Write("Nazev: ");
            hra2.Nazev = Console.ReadLine();
            Console.WriteLine();
            Console.Write("Zanr: ");
            hra2.Zanr = Console.ReadLine();
            Console.WriteLine();
            Console.Write("Stav(Dohrano/Nedohrano/Rozehrano): ");
            hra2.StavHry = Console.ReadLine();
            Console.WriteLine();
            Console.Write("Hodnoceni: ");
            int hodnoceni = 0;
            while (!int.TryParse(Console.ReadLine(), out hodnoceni))
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("PIS JENOM CISLA!");
                Console.ResetColor();
            }
            hra2.Hodnoceni = hodnoceni;
            Console.WriteLine();
            Console.Write("Cena: ");
            int cena = 0;
            while (!int.TryParse(Console.ReadLine(), out cena))
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("PIS JENOM CISLA!");
                Console.ResetColor();
            }
            hra2.Cena = cena;
            Console.WriteLine();
            hra2.ID = list.Count + 1;

            list.Add(hra2);

            return list;
        }

        static void Menu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("    MENU");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Vyber moznosti:");
            Console.ResetColor();
            Console.WriteLine($"\nVypis souboru: 1\nPridat hru: 2\nVyhledat hry v souboru: 3\nFiltrovani her podle zanru: 4\nUprava udaju o hre: 5\nSmazani hry: 6\nSerazeni her podle hodnoceni: 7\nZobrazit statistiku her: 8\nKonec: 9");

        }
        static void FiltrovaniSouboru(List<Hry> soubor)
        {
            int count = 0;
            Console.Write("Zadej zanry pro filtraci(kdyz zanru je vic nez 1 zadej oddelene carkou): ");
            string vstup = Console.ReadLine();
            Console.WriteLine();
            string[] zanry = vstup.Split(',');

            bool nalezeno = false;
            Console.WriteLine();
            foreach (Hry hra in soubor)
            {
                foreach (string zanr in zanry)
                {
                    if (hra.Zanr.ToLower() == zanr.Trim().ToLower())
                    {
                        nalezeno = true;

                        Console.WriteLine($"ID: {hra.ID} | Nazev: {hra.Nazev} | Zanr: {hra.Zanr} | Stav: {hra.StavHry} | Hodnoceni: {hra.Hodnoceni} | Cena: {hra.Cena}");

                        break;
                    }
                    
                    
                }
            }

          
            nalezeno = false;
        }
        static List<Hry> Konec(List<Hry> soubor)
        {

            using (StreamWriter sw = new StreamWriter("hry_upraveno.txt"))
            {
                foreach (Hry hra in soubor)
                {
                    sw.WriteLine($"{hra.ID};{hra.Nazev};{hra.Zanr};{hra.StavHry};{hra.Hodnoceni};{hra.Cena}");
                }
            }
            return soubor;
        }
        static void Statistika(List<Hry> soubor)
        {
            Console.WriteLine($"Pocet her v souboru: {soubor.Count}\n");
            
            double hodnoceni = 0;
            for (int i = 0; i < soubor.Count; i++)
            {
                hodnoceni += soubor[i].Hodnoceni;
            }
            Console.WriteLine($"Prumer hodnoceni je: {hodnoceni / soubor.Count}");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine();
            Console.WriteLine("Hry s hodnocenim 10: ");
            Console.ResetColor();
            for (int i = 0; i < soubor.Count; i++)
            {
                if (soubor[i].Hodnoceni == 10)
                {
                    Console.Write(soubor[i].Nazev + " | ");
                }
            }
            hodnoceni = 0;

        }
        static List<Hry> UpravaUdaju(List<Hry> soubor)
        {
            Console.WriteLine("Napiš název hry, kterou chceš upravit:");
            string nazev = Console.ReadLine();
            Console.WriteLine();
            bool nalezeno = false;

            for (int i = 0; i < soubor.Count; i++)
            {
                if (soubor[i].Nazev.Trim().ToLower() == nazev.Trim().ToLower())
                {
                    nalezeno = true;
                    Console.WriteLine($"Nalezena hra:");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine( soubor[i].Nazev);
                    Console.ResetColor();

                    Console.WriteLine("\nCo chceš upravit?\nHodnocení: 1\nStav hry: 2");

                    int vyber = 0;

                    while (!int.TryParse(Console.ReadLine(), out vyber))
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("\nPIS JENOM CISLA!");
                        Console.ResetColor();
                    }

                    while (vyber < 1 || vyber > 2)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("\nCISLO OD 1 DO 2!");
                        Console.ResetColor();

                        int.TryParse(Console.ReadLine(), out vyber);
                    }

                    if (vyber == 1)
                    {
                        Console.WriteLine("Napis hodnoceni od 1 do 10:");

                        int hodnoceni = 0;

                        while (!int.TryParse(Console.ReadLine(), out hodnoceni))
                        {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("\nPIS JENOM CISLA!");
                            Console.ResetColor();
                        }

                        soubor[i].Hodnoceni = hodnoceni;
                    }
                    else
                    {
                        Console.WriteLine("\nNapis stav:\nDohrano\nNedohrano\nRozehrano");

                        string stav = Console.ReadLine().ToLower();

                        while (stav != "dohrano" && stav != "nedohrano" && stav != "rozehrano")
                        {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("Napis pouze dohrano, nedohrano nebo rozehrano:");
                            Console.ResetColor();

                            stav = Console.ReadLine().ToLower();
                        }

                        if (stav == "dohrano")
                        {
                           soubor[i].StavHry = "Dohrano";
                        }
                        else if (stav == "nedohrano")
                        {
                            soubor[i].StavHry = "Nedohrano";
                        }
                        else if (stav == "rozehrano")
                        {
                            soubor[i].StavHry = "Rozehrano";
                        }
                    }

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nUdaje byly upraveny.");
                    Console.ResetColor();

                    break;
                }
            }

            if (nalezeno==false)
            {
                Console.Write($"Hra s nazvem ");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write(nazev);
                Console.ResetColor();
                Console.Write(" nebyla nalezena");
            }
            nalezeno = false;
            return soubor;
        }
        static List<Hry> SmazaniHry(List<Hry> soubor)
        {
            bool nalezeno = false;
            Console.WriteLine("Napis nazev hry kterou chces smazat:");
            string nazev = Console.ReadLine();
            for (int i = 0; i < soubor.Count; i++)
            {

                if (soubor[i].Nazev.Trim().ToLower() == nazev.Trim().ToLower())//Trim ubere mezery v textu
                {
                    nalezeno = true;
                    Console.WriteLine($"Nalezena hra: {soubor[i].Nazev}");
                    Console.WriteLine();
                    Console.WriteLine("\nOpravdu chces ji smazat?\nAno: 1\nNe: 2");
                    int vyber = int.Parse(Console.ReadLine());

                    while (vyber < 1 || vyber > 2)
                    {
                        Console.WriteLine("\nCISLO OD 1 DO 2!");
                        vyber = 0;
                        while (!int.TryParse(Console.ReadLine(), out vyber))
                        {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("\nPIS JENOM CISLA!");
                            Console.ResetColor();
                        }
                    }
                    if (vyber==1)
                    {
                        soubor.RemoveAt(i);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("Smazano");
                        Console.ResetColor();
                    }
                    else if (vyber == 2)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.Write("Nemazat");
                        Console.ResetColor();
                        break;
                    }
                }
            }
            if (nalezeno == false)
            {
                Console.Write($"Hra s nazvem ");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write(nazev);
                Console.ResetColor();
                Console.Write(" nebyla nalezena");
            }
            nalezeno = false;
            return soubor;
        }
        static void SerazeniPodleHodnoceni(List<Hry> soubor)
        {
            int index = 10;
            List<Hry> filtr_hodnoceni = new List<Hry>();
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < soubor.Count; j++)
                {
                    if (soubor[j].Hodnoceni == index)
                    {
                        filtr_hodnoceni.Add(soubor[j]);
                    }
                }
                index--;
            }
            index = 10;
            foreach (Hry hra in filtr_hodnoceni)
            {
                for (int i = 0; i < filtr_hodnoceni.Count; i++)
                {
                    filtr_hodnoceni[i].ID = i + 1;
                }
                
                Console.Write($"\n | ID hry: ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(hra.ID);
                Console.ResetColor();
                Console.Write($" | Nazev hry : ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(hra.Nazev);
                Console.ResetColor();
                Console.Write($" | Zanr hry: ");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write(hra.Zanr);
                Console.ResetColor();
                Console.Write($" | Stav hry: ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(hra.StavHry);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.ResetColor();
                Console.Write($" | Hodnoceni: ");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(hra.Hodnoceni);
                Console.ResetColor();
                Console.Write($" |Cena hry Kč: ");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine(hra.Cena);
                Console.ResetColor();
            }


            //vymen mistama hodnoty a cw blbe vypada

        }
        static void NajitPodleNazvy(List<Hry> soubor)
        {
            Console.WriteLine("Zadej nazvu hry a ja ti napisu kde ona je");
            string nazev = Console.ReadLine();
            bool nalezeno = false;
            for (int i = 0; i < soubor.Count; i++)
            {
                if (soubor[i].Nazev.Trim().ToLower() == nazev.Trim().ToLower())//Trim ubere mezery v textu
                {
                    nalezeno = true;
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("\nHra byla nalezena");
                    Console.ResetColor();
                    Console.Write($"\n | ID hry: ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(soubor[i].ID);
                    Console.ResetColor();
                    Console.Write($" | Nazev hry : ");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write(soubor[i].Nazev);
                    Console.ResetColor();
                    Console.Write($" | Zanr hry: ");
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write(soubor[i].Zanr);
                    Console.ResetColor();
                    Console.Write($" | Stav hry: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(soubor[i].StavHry);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.ResetColor();
                    Console.Write($" | Hodnoceni: ");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write(soubor[i].Hodnoceni);
                    Console.ResetColor();
                    Console.Write($" |Cena hry Kč: ");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine(soubor[i].Cena);
                    Console.ResetColor();
                }
            }
            if (nalezeno==false)
            {
                Console.Write($"Hra s nazvou ");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write(nazev);
                Console.ResetColor();
                Console.Write(" nebyla nalezena");
            }
            nalezeno = false;
        }
    }
}