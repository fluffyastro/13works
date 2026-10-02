using System;
using System.Collections.Generic;
using System.Linq;

public class Film
{
    public string Cim { get; set; }
    public string Rendezo { get; set; }
    public int MegjelenesiEv { get; set; }
    public int Hossz { get; set; } // perc
    public double Ertekeles { get; set; } // 0-10
    public string Mufaj { get; set; }
    public int NezokSzama { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        List<Film> filmek = new List<Film>()
        {
            new Film
            {
                Cim = "A kezdet",
                Rendezo = "Christopher Nolan",
                MegjelenesiEv = 2010,
                Hossz = 148,
                Ertekeles = 8.8,
                Mufaj = "Sci-Fi",
                NezokSzama = 950000
            },

            new Film
            {
                Cim = "A sötét lovag",
                Rendezo = "Christopher Nolan",
                MegjelenesiEv = 2008,
                Hossz = 152,
                Ertekeles = 9.0,
                Mufaj = "Akcio",
                NezokSzama = 1200000
            },

            new Film
            {
                Cim = "Interstellar",
                Rendezo = "Christopher Nolan",
                MegjelenesiEv = 2014,
                Hossz = 169,
                Ertekeles = 8.7,
                Mufaj = "Sci-Fi",
                NezokSzama = 1100000
            },

            new Film
            {
                Cim = "Titanic",
                Rendezo = "James Cameron",
                MegjelenesiEv = 1997,
                Hossz = 195,
                Ertekeles = 7.9,
                Mufaj = "Romantikus",
                NezokSzama = 1500000
            },

            new Film
            {
                Cim = "Avatar",
                Rendezo = "James Cameron",
                MegjelenesiEv = 2009,
                Hossz = 162,
                Ertekeles = 7.8,
                Mufaj = "Sci-Fi",
                NezokSzama = 1400000
            },

            new Film
            {
                Cim = "Gladiator",
                Rendezo = "Ridley Scott",
                MegjelenesiEv = 2000,
                Hossz = 155,
                Ertekeles = 8.5,
                Mufaj = "Tortenelmi",
                NezokSzama = 980000
            },

            new Film
            {
                Cim = "Alien",
                Rendezo = "Ridley Scott",
                MegjelenesiEv = 1979,
                Hossz = 117,
                Ertekeles = 8.5,
                Mufaj = "Horror",
                NezokSzama = 650000
            },

            new Film
            {
                Cim = "A remény rabjai",
                Rendezo = "Frank Darabont",
                MegjelenesiEv = 1994,
                Hossz = 142,
                Ertekeles = 9.3,
                Mufaj = "Drama",
                NezokSzama = 1300000
            },

            new Film
            {
                Cim = "Zöld könyv",
                Rendezo = "Peter Farrelly",
                MegjelenesiEv = 2018,
                Hossz = 130,
                Ertekeles = 8.2,
                Mufaj = "Drama",
                NezokSzama = 720000
            },

            new Film
            {
                Cim = "Oppenheimer",
                Rendezo = "Christopher Nolan",
                MegjelenesiEv = 2023,
                Hossz = 180,
                Ertekeles = 8.6,
                Mufaj = "Tortenelmi",
                NezokSzama = 900000
            }
        };


        // ============================================================
        // LINQ GYAKORLÓ FELADATOK
        // 13. ÉVFOLYAM
        // ============================================================


        // ============================================================
        // 1. FELADAT - MAGAS ÉRTÉKELÉSŰ FILMEK
        // ============================================================
        //
        // Gyűjtsd ki azokat a filmeket, amelyek értékelése
        // legalább 8,5!
        //
        // Írasd ki:
        // - a film címét
        // - az értékelését
        //
        // A feladatot LINQ segítségével oldd meg!
        //
        // Ide írd a megoldásodat:
        //

        Console.WriteLine("1. feladat:");

        var eredmeny1 = filmek.Where(x => x.Ertekeles >= 8.5);
        
        foreach (var film in eredmeny1)
        {
            Console.WriteLine(film.Cim + " " + film.Ertekeles);
        }
        Console.WriteLine();



        // ============================================================
        // 2. FELADAT - RÖVID FILMEK
        // ============================================================
        //
        // Listázd ki azoknak a filmeknek a címét és hosszát,
        // amelyek 130 percnél rövidebbek!
        //
        // Az eredményben csak a következő adatok szerepeljenek:
        // - Cim
        // - Hossz
        //
        // A feladatot LINQ segítségével oldd meg!
        //
        // Ide írd a megoldásodat:
        //

        Console.WriteLine("2. feladat:");

        var eredmeny2 = filmek.Where(x => x.Hossz < 150);
        
        foreach (var film in eredmeny2)
        {
            Console.WriteLine(film.Cim + " " + film.Hossz);
        }
        Console.WriteLine();


        // ============================================================
        // 3. FELADAT - ÚJABB FILMEK
        // ============================================================
        //
        // Keresd meg a 2010 után megjelent filmeket!
        //
        // Írasd ki:
        // - a film címét
        // - a megjelenési évét
        // - a műfaját
        //
        // A feladatot LINQ segítségével oldd meg!
        //
        // Ide írd a megoldásodat:
        //

        Console.WriteLine("3. feladat:");

        var eredmeny3 = filmek.Where(x => x.MegjelenesiEv > 2010);
        
        foreach (var film in eredmeny3)
        {
            Console.WriteLine(film.Cim + " " + film.MegjelenesiEv + " " + film.Mufaj);
        }
        Console.WriteLine();


        // ============================================================
        // 4. FELADAT - LEG NÉZETTEBB FILMEK
        // ============================================================
        //
        // Rendezd a filmeket a nézők száma alapján
        // csökkenő sorrendbe!
        //
        // Írasd ki:
        // - a film címét
        // - a rendezőt
        // - a nézők számát
        //
        // A feladat megoldásához használj LINQ rendezést!
        //
        // Ide írd a megoldásodat:
        //

        Console.WriteLine("4. feladat:");

        var eredmeny4 = filmek.OrderByDescending(x => x.NezokSzama);
        
        foreach (var film in eredmeny4)
        {
            Console.WriteLine(film.Cim + " " + film.Rendezo + " " + film.NezokSzama);
        }
        Console.WriteLine();


        // ============================================================
        // 5. FELADAT - ÁTLAGOS ÉRTÉKELÉS
        // ============================================================
        //
        // Számítsd ki az összes film átlagos értékelését!
        //
        // Az eredményt írasd ki a konzolra.
        //
        // A feladat megoldásához használj megfelelő LINQ
        // statisztikai metódust!
        //
        // Például:

        Console.WriteLine("5. feladat:");

        double atlag = filmek.Average(x => x.Ertekeles);
        
        Console.WriteLine(atlag);
        Console.WriteLine();


        // ============================================================
        // HASZNOS LINQ METÓDUSOK
        // ============================================================
        //
        // A feladatok megoldásához az alábbi LINQ metódusokat
        // érdemes megismerni és használni:
        //
        // Where()
        //     - feltétel alapján szűr
        //
        // Select()
        //     - kiválasztja, hogy milyen adatokat szeretnénk
        //
        // OrderBy()
        //     - növekvő sorrendbe rendez
        //
        // OrderByDescending()
        //     - csökkenő sorrendbe rendez
        //
        // Average()
        //     - átlagot számol
        //
        // Count()
        //     - megszámolja az elemeket
        //
        // Any()
        //     - megvizsgálja, hogy van-e megfelelő elem
        //
        // GroupBy()
        //     - csoportosítja az elemeket
        //
        // FirstOrDefault()
        //     - visszaadja az első megfelelő elemet
        //
        // ============================================================

        Console.ReadKey();
    }
}