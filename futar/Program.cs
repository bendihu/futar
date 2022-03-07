namespace futar;

public class Futar
{
    public int Nap { get; set; }
    public int Fuvar { get; set; }
    public int Km { get; set; }
}

public class Program
{
    static List<Futar> list = new List<Futar>();
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Feladat1();
        Feladat2();
        Feladat3();
        Feladat4();
        Feladat5();
        Feladat6();
        Feladat7();
        Feladat8();
        Feladat9();

        Console.ReadKey();
    }
    private static int Fizetes(int km)
    {
        int fizetes = 0;

        switch (km)
        {
            case <= 2:
                fizetes = 500;
                break;
            case int n when (n >= 3 && n <= 5):
                fizetes = 700;
                break;
            case int n when (n >= 6 && n <= 10):
                fizetes = 900;
                break;
            case int n when (n >= 11 && n <= 20):
                fizetes = 1400;
                break;
            case int n when (n >= 21 && n <= 30):
                fizetes = 2000;
                break;
            default:
                break;
        }

        return fizetes;
    }
    private static void Feladat1()
    {
        StreamReader sr = new StreamReader(@"tavok.txt");

        while (!sr.EndOfStream)
        {
            string[] line = sr.ReadLine().Split(' ');
            Futar uj = new Futar();

            uj.Nap = int.Parse(line[0]);
            uj.Fuvar = int.Parse(line[1]);
            uj.Km = int.Parse(line[2]);

            list.Add(uj);
        }

        sr.Close();
    }
    private static void Feladat2()
    {
        Console.WriteLine("2. feladat");

        var elso = list.OrderBy(x => x.Nap).ThenBy(x => x.Fuvar).First().Km;

        Console.WriteLine($"A legelső út {elso} km volt.\n");
    }
    private static void Feladat3()
    {
        Console.WriteLine("3. feladat");

        var utolso = list.OrderBy(x => x.Nap).ThenBy(x => x.Fuvar).Last().Km;

        Console.WriteLine($"Az utolsó út {utolso} km volt.\n");
    }
    private static void Feladat4()
    {
        Console.WriteLine("4. feladat");
        Console.Write("A futár nem dolgozott ezeken a napokon: ");

        for (int i = 1; i < 7; i++)
        {
            if (list.Where(x => x.Nap == i).Count() == 0) Console.Write($"{i}. ");
        }

        Console.WriteLine("\n");
    }
    private static void Feladat5()
    {
        Console.WriteLine("5. feladat");

        int max = 0, nap = 0;

        for (int i = 1; i < 7; i++)
        {
            if (list.Where(x => x.Nap == i).Count() != 0)
            {
                int fuvar = list.Where(x => x.Nap == i).Max(x => x.Fuvar);

                if (fuvar >= max)
                {
                    max = fuvar;
                    nap = i;
                }
            }
        }

        Console.WriteLine($"A legtöbb fuvar a(z) {nap}. napon volt.\n");
    }
    private static void Feladat6()
    {
        Console.WriteLine("6. feladat");

        for (int i = 1; i < 7; i++)
        {
            int km = list.Where(x => x.Nap == i).Sum(x => x.Km);
            Console.WriteLine($"{i}. nap: {km} km");
        }

        Console.WriteLine("\n");
    }
    private static void Feladat7()
    {
        Console.WriteLine("7. feladat");

        Console.Write("Adjon meg egy távolságot: ");
        int bKm = int.Parse(Console.ReadLine());

        int fizetes = Fizetes(bKm);

        Console.WriteLine($"A futár {fizetes} Forintot kapott.\n");
    }
    private static void Feladat8()
    {
        StreamWriter sw = new StreamWriter(@"dijazas.txt");

        var csoport = list.OrderBy(x => x.Nap).ThenBy(x => x.Fuvar).GroupBy(x => x.Nap).ToList();

        foreach (var group in csoport)
        {
            foreach (var item in group)
            {
                sw.WriteLine($"{item.Nap}. nap {item.Fuvar}. út: {Fizetes(item.Km)} Ft");
            }
        }

        sw.Close();
    }
    private static void Feladat9()
    {
        Console.WriteLine("9. feladat");

        int ossz = 0;

        foreach (var item in list)
        {
            ossz += Fizetes(item.Km);
        }

        Console.WriteLine($"A futár a heti munkájáért {ossz} Forintot kapott.");
    }
}