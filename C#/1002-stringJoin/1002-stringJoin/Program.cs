using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ_StringJoin_Gyakorlas
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> gyumolcsok = new List<string>
            {
                "alma",
                "körte",
                "banán",
                "alma",
                "narancs",
                "eper",
                "dinnye"
            };

            List<int> szamok = new List<int>
            {
                2, 5, 8, 11, 14, 17, 20, 23
            };

            List<string> diakok = new List<string>
            {
                "Anna",
                "Bence",
                "Csilla",
                "Dani",
                "Eszter"
            };


            // ============================================================
            // 1. FELADAT
            // Írd ki a 5 betűnél hosszabb gyümölcsöket egy sorba!
            //
            // FONTOS:
            // A feladat megoldásánál használj:
            // - LINQ Where()
            // - String.Join()
            // ============================================================

            var tobbMint5 = gyumolcsok.Where(x => x.Length > 5);
            Console.WriteLine("5 betűnél hosszabb névvel rendelkező gyümölcsök: " + string.Join(", ", tobbMint5));
            Console.WriteLine();

            // ============================================================
            // 2. FELADAT
            // Írd ki a páros számokat egy sorba,
            // vesszővel elválasztva!
            //
            // Használj:
            // - LINQ Where()
            // - String.Join()
            // ============================================================

            var parosSzamok = szamok.Where(x => x % 2 == 0);
            Console.WriteLine("Páros számok: " + string.Join(", ", parosSzamok));
            Console.WriteLine();

            // ============================================================
            // 3. FELADAT
            // Írd ki a gyümölcsöket ABC sorrendben,
            // egy sorban, vesszővel elválasztva!
            //
            // Használj:
            // - LINQ OrderBy()
            // - String.Join()
            // ============================================================

            var abcSorrend = gyumolcsok.OrderBy(x => x[0]);
            Console.WriteLine("ABC sorrendbe helyezve:" + string.Join(", ", abcSorrend));
            Console.WriteLine();

            // ============================================================
            // 4. FELADAT
            // Írd ki azokat a diákokat, akiknek a neve
            // "a" betűt tartalmaz!
            //
            // Használj:
            // - LINQ Where()
            // - String.Join()
            // ============================================================

            var aBetutTartalmazoNevek = diakok.Where(n => n.Contains("a"));
            Console.WriteLine("A betűt tartamlmazó nevek: " + string.Join(", ", aBetutTartalmazoNevek));
            Console.WriteLine();

            // ============================================================
            // 5. FELADAT
            // Írd ki az ismétlődés nélküli gyümölcsöket
            // egy sorba, vesszővel elválasztva!
            //
            // Használj:
            // - LINQ Distinct()
            // - String.Join()
            // ============================================================

            var ismetlodesNelkul = gyumolcsok.Distinct().ToList();
            Console.WriteLine("Ismétlődés nélkül gyümölcsök: " + string.Join(", ", ismetlodesNelkul));


        }
    }
}