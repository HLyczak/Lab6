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
            var ListStudent3 = ListStudent1.OrderBy(u => u.Marks.Count()).ToList();
            var ListMin = ListStudent3.Where(u => u.Marks.Count() == ListStudent3.First().Marks.Length).ToList();
            //Console.WriteLine(best);

            //Listę studentów, którzy posiadają najwięcej ocen
            var ListMax = ListStudent3.Where(u => u.Marks.Count() == ListStudent3.Last().Marks.Length).ToList();
            //Listę obiektów zawierających tylko nazwę i średnią ocenę(mapowanie na inny obiekt)
            var NameAvg = Users.Get().Where(u => u.Marks != null).Select(u => new { Type = u.Name, avg = u.Marks.Average() }).ToList();

            //Studentów posortowanych od najlepszego
            var ListStudent4 = ListStudent1.OrderByDescending(u => u.Marks.Average()).ToList();

            //Listę użytkowników pogrupowanych po miesiącach daty utworzenia
            var DateCreate = Users.Get().OrderBy(u => u.CreatedAt).Where(u => u.CreatedAt != null).Where(u => u.CreatedAt.HasValue).GroupBy(u => u.CreatedAt.Value.Month).ToList();

            //Listę użytkowników, którzy nie zostali usunięci(data usunięcia nie została ustawiona)
            var noDeleteStudent = Users.Get().Where(u => u.RemovedAt == null).ToList();
            Console.WriteLine();

            //Najnowszego studenta(najnowsza data utworzenia)
            var newUser = Users.Get().Where(u => u.Role == "STUDENT").OrderBy(u => u.CreatedAt).Select(u => u.Name).Last();
            Console.WriteLine(newUser);
            //}
        }
    }
}