using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace ConOperatorok
{
    internal class Program
    {
        static List<string> adatok = new List<string>();

        static void Main(string[] args)
        {
            // 1.
            adatok = File.ReadAllLines("Datasource\\kifejezesek.txt").ToList();

            // 2.
            Console.WriteLine($"2. feladat: Kifejezések száma: {adatok.Count()}");

            // 3.
            Console.WriteLine($"3. feladat: Kifejezések maradékos osztással: {adatok.Count(x => x.Split(" ")[1] == "mod")}");

            // 4.
            Console.WriteLine($"4. feladat: {(adatok.Any(x => int.Parse(x.Split(" ")[0]) % 10 == 0 && int.Parse(x.Split(" ")[2]) % 10 == 0) ? "Van ilyen kifejezés!" : "Nincs ilyen kifejezés!")}");

            // 5.
            Console.WriteLine($"5. feladat: Statisztika");
            adatok.GroupBy(x => x.Split(" ")[1]).ToList().ForEach(x => Console.WriteLine($"\t{x.Key} -> {x.Count()}"));
            // ???

            // 6.
            static string operatorVizsgalat(string kifejezes)
            {
                double szam1 = double.Parse(kifejezes.Split(" ")[0]);
                string oper = kifejezes.Split(' ')[1];
                double szam2 = double.Parse(kifejezes.Split(" ")[2]);

                string kiszamolt = "";

                switch (oper)
                {
                    case "/":
                        if (szam2 != 0)
                        {
                            kiszamolt = $"{kifejezes} = {szam1 / szam2}";
                            break;
                        }
                        else
                        {
                            kiszamolt = $"{kifejezes} = Egyéb hiba!";
                            break;
                        }
                    case "+":
                        kiszamolt = $"{kifejezes} = {szam1 + szam2}";
                        break;
                    case "-":
                        kiszamolt = $"{kifejezes} = {szam1 - szam2}";
                        break;
                    case "*":
                        kiszamolt = $"{kifejezes} = {szam1 * szam2}";
                        break;
                    case "mod":
                        kiszamolt = $"{kifejezes} = {szam1 % szam2}";
                        break;
                    case "div":
                        if (szam2 != 0)
                        {
                            kiszamolt = $"{kifejezes} = {szam1 / szam2}";
                            break;
                        }
                        else
                        {
                            kiszamolt = $"{kifejezes} = Egyéb hiba!";
                            break;
                        }
                    default:
                        kiszamolt = $"{kifejezes} = Hibás operátor!";
                        break;
                }
                return kiszamolt;
            }

            // 7.
            while (true)
            {
                Console.Write("7. feladat: Kérek egy kifejezést (pl.: 1 + 1): ");
                string input = Console.ReadLine();

                if (input == "vége")
                {
                    break;
                }
                else
                {
                    Console.WriteLine($"\t{operatorVizsgalat(input)}");
                }
            }

            // 8.
            List<string> eredmenyek = new List<string>();
            adatok.ForEach(x => eredmenyek.Add(operatorVizsgalat(x)));
            foreach (var item in eredmenyek)
            {
                Console.WriteLine(item);
            }
            File.WriteAllLines("Datasource\\eredmenyek.txt", eredmenyek);
        }
    }
}