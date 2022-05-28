using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab6
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //Ilość rekordów w tablicy
            var count = Users.Get().Count();
            //Console.WriteLine(count);
            //Listę nazw użytkowników ( nazwa zmiennej)
            var names = Users.Get().Select(u => u.Name);
            /*foreach (var a in names)
            {
                Console.Write(a + " ");
            }*/

            //Posortowanych użytkowników po nazwach
            var usersByName = Users.Get().OrderBy(u => u.Name);
            /*foreach (var item in usersByName)
            {
                Console.WriteLine(item.Name);
            }
            */
            //Listę dostępnych ról użytkowników
            var roles = Users.Get().Select(u => u.Role).Distinct();
            /*foreach (var a in roles)
            {
                Console.Write(a + " ");
            }*/
            //Listy pogrupowanych użytkowników po rolach
            var orderByRoles = Users.Get().GroupBy(u => u.Role);

            //Ilość rekordów, dla których podano oceny(nie null i więcej niż 0)
            var degree = Users.Get().Where(u => u.Marks == null).Count();

            //Sumę, ilość i średnią wszystkich ocen studentów
            var countDegree = Users.Get().Where(u => u.Marks != null).SelectMany(u => u.Marks).Count();
            //Console.WriteLine(countDegree);
            var sumDegree = Users.Get().Where(u => u.Marks != null).SelectMany(u => u.Marks).Sum();
            //Console.WriteLine(sumDegree);
            var avgDegree = Users.Get().Where(u => u.Marks != null).SelectMany(u => u.Marks).Average();
            //Console.WriteLine((double)117 / 33);
            //Console.WriteLine(avgDegree);

            //Najlepszą ocenę
            var maxDegree = Users.Get().Where(u => u.Marks != null).SelectMany(u => u.Marks).Max();
            //Console.WriteLine(maxDegree);

            //Najgorszą ocenę
            var minDegree = Users.Get().Where(u => u.Marks != null).SelectMany(u => u.Marks).Min();
            //Console.WriteLine(minDegree);

            //Najlepszego studenta
            var ListStudent1 = Users.Get().OrderBy(u => u.Name).Where(u => u.Marks != null).ToList();
            var ListStudent2 = ListStudent1.OrderBy(u => u.Marks.Average()).ToList();
            var best = ListStudent2.Select(u => u.Name).Last();
            Console.WriteLine(best);
            //Listę studentów, którzy posiadają najmniej ocen
            //var ListStudent3 = ListStudent1.OrderBy(u => u.Marks).Max().ToString();
            //Console.WriteLine(best);

            //Listę studentów, którzy posiadają najwięcej ocen

            //Listę obiektów zawierających tylko nazwę i średnią ocenę(mapowanie na inny obiekt)

            //Studentów posortowanych od najlepszego
            var ListStudent3 = ListStudent1.OrderByDescending(u => u.Marks.Average()).ToList();
            Console.WriteLine(ListStudent3);
            //Listę użytkowników pogrupowanych po miesiącach daty utworzenia(np. 2022 - 02, 2022 - 03, 2022 - 04, itp.)

            //var groupByMonth = Users.Get().GroupBy(u => u.CreatedAt);

            //Listę użytkowników, którzy nie zostali usunięci(data usunięcia nie została ustawiona)
            //var noDeleteStudent = Users.Get().OrderBy

            //Najnowszego studenta(najnowsza data utworzenia)
        }
    }
}