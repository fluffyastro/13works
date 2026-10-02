using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ_Gyakorlas_13
{
    class Diak
    {
        public int Id { get; set; }
        public string Nev { get; set; }
        public int Eletkor { get; set; }
        public string Osztaly { get; set; }
        public List<int> Jegyek { get; set; }
    }

    class Tantargy
    {
        public string Nev { get; set; }
        public int HetiOraszam { get; set; }
        public bool ErettsegiTantargy { get; set; }
    }

    class Tanar
    {
        public string Nev { get; set; }
        public List<Tantargy> Tantargyak { get; set; }
        public int TapasztalatEv { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Diak> diakok = new List<Diak>
            {
                new Diak { Id = 1, Nev = "Anna", Eletkor = 18, Osztaly = "13.A", Jegyek = new List<int>{5,4,5,5}},
                new Diak { Id = 2, Nev = "Bence", Eletkor = 19, Osztaly = "13.B", Jegyek = new List<int>{3,4,2,3}},
                new Diak { Id = 3, Nev = "Csilla", Eletkor = 18, Osztaly = "13.A", Jegyek = new List<int>{5,5,5,5}},
                new Diak { Id = 4, Nev = "Dani", Eletkor = 20, Osztaly = "13.C", Jegyek = new List<int>{2,2,3}},
                new Diak { Id = 5, Nev = "Eszter", Eletkor = 19, Osztaly = "13.B", Jegyek = new List<int>{4,4,4,5}}
            };

            List<Tanar> tanarok = new List<Tanar>
            {
                new Tanar
                {
                    Nev = "Kovács Péter",
                    TapasztalatEv = 12,
                    Tantargyak = new List<Tantargy>
                    {
                        new Tantargy{ Nev="Matematika", HetiOraszam=4, ErettsegiTantargy=true},
                        new Tantargy{ Nev="Informatika", HetiOraszam=5, ErettsegiTantargy=true}
                    }
                },
                new Tanar
                {
                    Nev = "Nagy Júlia",
                    TapasztalatEv = 6,
                    Tantargyak = new List<Tantargy>
                    {
                        new Tantargy{ Nev="Magyar", HetiOraszam=4, ErettsegiTantargy=true}
                    }
                }
            };

            // 1️ Listázd ki azoknak a diákoknak a nevét,
            //    akiknek az átlaga legalább 4.5!
            Console.WriteLine("1. feladat:");
            var joDiakok = diakok.Where(x => x.Jegyek.Average() > 4.5);
            
            foreach(var jo in joDiakok)
            {
                Console.WriteLine(jo.Nev);
            }
            Console.WriteLine();
            // 2️ Csoportosítsd a diákokat osztály szerint,
            //    és írd ki osztályonként a diákok számát!

            Console.WriteLine("2. feladat:");
            var osztalySzerint = diakok
                .GroupBy(x => x.Osztaly.Count());
            foreach (var oSz in osztalySzerint)
            {
                Console.WriteLine(oSz);
            }
            Console.WriteLine();

            // 3️ Keresd meg azt a diákot,
            //    akinek a legmagasabb az átlaga!

            Console.WriteLine("3. feladat:");
            var legjobbDiak = diakok.Where(x => x.Jegyek.Average() > 4.5);
            Console.WriteLine();

            // 4️ Írd ki azon diákok nevét,
            //    akiknek VAN legalább egy 2-es jegyük!
            Console.WriteLine("4. feladat:");
            var kettesDiak = diakok.Where(x => x.Jegyek.Contains(2));
            foreach (var kettes in kettesDiak)
            {
                Console.WriteLine(kettes.Nev);
            }
            Console.WriteLine();

            // 5️ Készíts egy listát azokról a tanárokról,
            //    akik legalább 2 tantárgyat tanítanak!
            Console.WriteLine("5. feladat:");
            var tobbMintKettoTantargy = tanarok.Where(x => x.Tantargyak.Count() > 2).ToList();
            Console.WriteLine();

            // 6️ Listázd ki az összes érettségi tantárgy nevét
            //    (ismétlődés nélkül)!
            // hint: .Select
            Console.WriteLine("6. feladat:");
            var erettsegiTantargyak = tanarok.Select(x => x.Tantargyak);
            foreach(var tantargyak in erettsegiTantargyak)
            {
                Console.WriteLine(tantargyak);
            }

            Console.WriteLine();
            // 7️ Számold ki tanáronként,
            //    hogy összesen hány órát tanít hetente!
            Console.WriteLine("7. feladat:");
            var oraMennyiseg = tanarok.Sum(x => x.Or)
            Console.WriteLine();
            // 8️ Keresd meg azt a diákot,
            //    akinek a jegyeinek szórása a legnagyobb!
            Console.WriteLine("8. feladat:");

            Console.WriteLine();
            // 9️ Készíts egy új objektumlistát,
            //    amelyben szerepel:
            //    - Diák neve
            //    - Átlag
            //    - Megbukott-e (van-e 1-es vagy 2-es)
            Console.WriteLine("9. feladat:");

            Console.WriteLine();
            // 10 Határozd meg,
            //    hogy van-e olyan tanár,
            //    aki CSAK érettségi tantárgyat tanít
            //    (All használata kötelező!)
            Console.WriteLine("10. feladat:");

            Console.WriteLine();
        }
    }
}