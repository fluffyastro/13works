using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

class Program
{
    static void Main()
    {
        Feladat1();
        Feladat2();
        Feladat3();
        Feladat4();
        Feladat5();
    }


    class Diak
    {
        public string Nev { get; set; }
        public int Kor { get; set; }
        public double Atlag { get; set; }
        public string Osztaly { get; set; }
    }

    static List<Diak> diakok = new List<Diak>
    {
        new Diak{ Nev="Anna", Kor=18, Atlag=4.5, Osztaly="13A"},
        new Diak{ Nev="Béla", Kor=19, Atlag=3.2, Osztaly="13B"},
        new Diak{ Nev="Cecil", Kor=18, Atlag=4.8, Osztaly="13A"},
        new Diak{ Nev="Dani", Kor=20, Atlag=2.9, Osztaly="13C"},
        new Diak{ Nev="Eszter", Kor=19, Atlag=4.1, Osztaly="13B"},
        new Diak{ Nev="Feri", Kor=18, Atlag=3.7, Osztaly="13A"}
    };

    // ============================================
    // 1. FELADAT:
    // Írd ki azoknak a diákoknak a nevét,
    // akiknek az átlaga nagyobb mint 4.0!
    // ============================================
    static void Feladat1()
    {
        Console.WriteLine("1. feladat");

        var diak = diakok.Where(x => x.Atlag > 4.0); // mindegy, hogy 4 vagy 4.0
        
        foreach(var item in diak)
        {
            Console.WriteLine(item.Nev);
        }
        Console.WriteLine();
    }

    // ============================================
    // 2. FELADAT:
    // Csoportosítsd a diákokat osztály szerint,
    // majd írd ki, hogy egy-egy osztályban hány diák van!
    // ============================================
    static void Feladat2()
    {
        Console.WriteLine("2. feladat");

        var diak = diakok.GroupBy(x => x.Osztaly);

        foreach(var item in diak)
        {
            Console.WriteLine($"{item.Key}: {item.Count()} diák.");
        }
        Console.WriteLine();
    }

    // ============================================
    // 3. FELADAT:
    // Rendezd a diákokat átlag szerint csökkenő sorrendbe,
    // majd írd ki a TOP 3 diák nevét és átlagát!
    // ============================================
    static void Feladat3()
    {
        Console.WriteLine("3. feladat");

        var diak = diakok
            .OrderByDescending(x => x.Atlag)
            .Take(3);

        foreach(var item in diakok)
        {
            Console.WriteLine($"{item.Nev} {item.Atlag}");
        }
        Console.WriteLine();
    }

    // ============================================
    // 4. FELADAT:
    // Számold ki az egyes osztályok átlagát!
    // (pl. 13A átlaga, 13B átlaga, stb.)
    // ============================================
    static void Feladat4()
    {
        Console.WriteLine("4. feladat");

        var diak = diakok
            .GroupBy(x => x.Osztaly)
            .Select(csoport => new
            {
                Osztaly = csoport.Key,
                Atlag = csoport.Average(x => x.Atlag)
            });

        foreach(var item in diak)
        {
            Console.WriteLine($"{item.Osztaly}: {item.Atlag}");
        }
        Console.WriteLine();
    }

    // ============================================
    // 5. FELADAT:
    // Írd ki azokat az osztályokat,
    // ahol van legalább egy 4.5 feletti átlagú diák!
    // ============================================
    static void Feladat5()
    {
        Console.WriteLine("5. feladat");

        var osztalyok = diakok
            .GroupBy(x => x.Osztaly)
            .Where(csoport => csoport.Any(x => x.Atlag > 4.5));

        foreach(var osztaly in osztalyok)
        {
            Console.WriteLine(osztaly.Key);
        }

        Console.WriteLine();
    }
}