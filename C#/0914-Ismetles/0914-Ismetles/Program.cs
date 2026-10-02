// 1. feladat
int[] bekert_szamok = new int[5];

Console.WriteLine("1. feladat.");
Console.WriteLine("Adj meg 5 számot, az ötödik szám után kiírom az összeget!");
for (int a = 0; a < 5; a++)
{
    try
    {
        int szam = Convert.ToInt32(Console.ReadLine());

        bekert_szamok[a] = szam;
    }
    catch (Exception ex) { Console.WriteLine("Számot adj meg!");
    }
}




// 2. feladat
Random rng = new Random();
int[] szamok2 = new int[10];

for (int i = 0; i < 10; i++)
{
    int szam = rng.Next(1, 100);

    szamok2[i] = szam;
}

szamok2.ToList().ForEach(x => Console.WriteLine(x));
Console.WriteLine();
Console.WriteLine(szamok2.Max());
Console.WriteLine();
Console.WriteLine(szamok2.Min());

// 3. feladat
List<int> lista3 = new List<int>();

while (true)
{
    try
    {
        int szam = Convert.ToInt32(Console.ReadLine());

        lista3.Add(szam);

        if (szam == 0)
        {
            break;
        }
    }
    catch (Exception ex) { Console.WriteLine("Számot adj meg!"); }
}
Console.WriteLine($"{lista3.Count()} számot adott meg");

// 4. feladat
Console.WriteLine("Adj meg egy számot!");
int n = Convert.ToInt32(Console.ReadLine());
string szoveg4 = "*";
Console.WriteLine();
for  (int i = 0; i < n; i++)
{
    Console.WriteLine(szoveg4);
    szoveg4+="*";
}