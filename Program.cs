using CA231209;
using System.Linq;

static void Beolvasas(List<Laptop> laptopok) 
{
    StreamReader sr = new(@"..\..\..\src\laptopok.txt");
    _ = sr.ReadLine();
    while (!sr.EndOfStream) laptopok.Add(new Laptop(sr.ReadLine()));
    sr.Close();
}
static void Feladat6(List<Laptop> laptopok) 
{
    Console.WriteLine("6.feladat:\n");
    laptopok.ForEach(x => Console.WriteLine(x));
}
static List<Laptop> Feladat7(List<Laptop> laptopok) 
{
    return laptopok
        .Where(l => l.OperaciosRendszer.Contains("Windows") == false && l.Suly >= 2)
        .ToList();
}
static (List<Laptop> lista, int db, double legkevesebb) Feladat8(List<Laptop> laptopok) 
{
    double legkevesebbUzeimdo = laptopok.Min(l => l.AkkuUzemido);

    List<Laptop> feladat8 = laptopok
        .Where(l => l.AkkuUzemido == legkevesebbUzeimdo)
        .ToList();

    return (feladat8, feladat8.Count, legkevesebbUzeimdo);

}
static double Feladat9(List<Laptop> laptopok) 
{
    return laptopok
        .Average(l => l.ProcSeb);
}
static List<string> Feladat10(List<Laptop> laptopok) 
{
    return laptopok
        .SelectMany(l => l.Kapcsolatok, (gy, k) => new { Gyarto = gy.Gyarto, Kapcsolat = k })
        .Where(k => k.Kapcsolat == " Bluetooth 5.2")
        .DistinctBy(gy => gy.Gyarto)
        .OrderBy(gy => gy.Gyarto)
        .Select(gy => gy.Gyarto)
        .ToList();
}
static List<int> Feladat11(List<Laptop> laptopok) 
{
    return laptopok
        .Where(l => l.ProcTipusSeb.Contains("AMD") && l.Suly > 1.3)
        .Select(l => l.Azonosito)
        .ToList();
}
static void Kiiras(List<Laptop> laptopok) 
{
    StreamWriter sw = new(@"..\..\..\src\ujfile.txt");
    laptopok.ForEach(l => sw.WriteLine($"{l.ProcTipusSeb} GHz, {l.SulyToGramm()} gramm"));
    sw.Close();
}

//Main

List<Laptop> laptopok = new();

try
{
    Beolvasas(laptopok);
    Console.WriteLine("A fájl sikeresen beolvasva!\n");
}
catch
{
    Console.WriteLine("Hiba a beolvasás során!\n");
}

// 6.feladat
Feladat6(laptopok);

// 7.feladat
List<Laptop> feladat7 = Feladat7(laptopok);
Console.WriteLine($"7.feladat: \n\t{feladat7.Count} db");

// 8.feladat
Console.WriteLine($"8.feladat:\n");
Feladat8(laptopok).lista.ForEach(x => Console.WriteLine(x));
Console.WriteLine($"\tDb: {Feladat8(laptopok).db}, Legkevesebb üzemidő : {Feladat8(laptopok).legkevesebb} óra\n");

// 9.feladat
Console.WriteLine($"9.feladat: \n\tAz átlagos processzor sebesség: {Feladat9(laptopok)}\n");

// 10.feladat
Console.WriteLine("10.feladat: ");
try
{
    Feladat10(laptopok).ForEach(x => Console.WriteLine($"\t{x}"));
}
catch
{
    Console.WriteLine("\tNincs a keresettnek megfelelő laptop!");
}

// 11.feladat
Console.WriteLine("11.feladat: ");
Feladat11(laptopok).ForEach(x => Console.Write($"{x}, "));

// 12.feladat (osztályban kész)

// 13.feladat
try
{
    Kiiras(laptopok);
    Console.WriteLine("\n\n13.feladat: \n\tSikeres kiírás!");
}
catch
{
    Console.WriteLine("13.feladat: \n\tHiba a fájlban kiírás során!");
}