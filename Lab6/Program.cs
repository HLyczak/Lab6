using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.Json;
using System.Xml.Serialization;

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

            // serializacja user json
            var user = Users.Get().First();
            string jsonUser = JsonSerializer.Serialize(user);
            Console.WriteLine(jsonUser);
            //serializacja listy
            var users = Users.Get();
            string jsonUsers = JsonSerializer.Serialize(users);
            Console.WriteLine(jsonUsers);

            //deserializacja user json
            //string jsondes = jsonUser;
            User userjsondeserialize = JsonSerializer.Deserialize<User>(jsonUser);
            Console.WriteLine("Name: " + user.Name);
            Console.WriteLine("Role: " + user.Role);
            Console.WriteLine("Marks: " + user.Marks);
            Console.WriteLine("Age: " + user.Age);
            // deserializacja list json
            var lisjsondeserialize = JsonSerializer.Deserialize<IEnumerable<User>>(jsonUsers);
            Console.WriteLine();

            //serialize user xml
            XmlSerializer serializer = new XmlSerializer(user.GetType());
            using MemoryStream stream = new MemoryStream();
            serializer.Serialize(stream, user);
            stream.Flush();
            var xmlUser = Encoding.UTF8.GetString(stream.ToArray());

            //deserialize user xml
            using TextReader reader = new StringReader(xmlUser);
            var userFromXml = (User)serializer.Deserialize(reader);

            //list serialize xml
            XmlSerializer serializerList = new XmlSerializer(users.GetType(), new Type[] { typeof(User) });
            using MemoryStream streamList = new MemoryStream();
            serializerList.Serialize(streamList, users);
            streamList.Flush();
            var xmlList = Encoding.UTF8.GetString(streamList.ToArray());

            //deserialize list xml
            using TextReader readerList = new StringReader(xmlList);
            var usersFromXml = (IEnumerable<User>)serializerList.Deserialize(readerList);

            //serialize user binary
            var formatter = new BinaryFormatter();

            using var streamBinary = new MemoryStream();
            formatter.Serialize(streamBinary, user);
            streamBinary.Flush();
            streamBinary.Position = 0;
            var binaryUser = streamBinary.ToArray();

            //deserialize user binary
            using var streamBinaryDeserialize = new MemoryStream(binaryUser);
            streamBinaryDeserialize.Seek(0, SeekOrigin.Begin);
            var userFromBinary = (User)formatter.Deserialize(streamBinaryDeserialize);

            //list serialize binary
            using var streamListBinary = new MemoryStream();
            formatter.Serialize(streamListBinary, users);
            streamListBinary.Flush();
            streamListBinary.Position = 0;
            var binaryUsers = streamListBinary.ToArray();

            //deserialize list binary
            using var streamBinaryListDeserialize = new MemoryStream(binaryUsers);
            streamBinaryListDeserialize.Seek(0, SeekOrigin.Begin);
            var usersFromBinary = (IEnumerable<User>)formatter.Deserialize(streamBinaryListDeserialize);
        }
    }
}