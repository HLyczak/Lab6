using System;
using System.Collections.Generic;

namespace Lab6
{
    internal class Users
    {
        public static IEnumerable<User> Get()
        {
            List<User> users = new List<User>();
            users.Add(new User() { Name = "Adam", Role = "ADMIN", Age = 35, Marks = null, CreatedAt = new DateTime(2000, 01, 20) });
            users.Add(new User() { Name = "Elżbieta", Role = "ADMIN", Age = 40, Marks = null, CreatedAt = new DateTime(2022, 01, 20) });
            users.Add(new User() { Name = "Marek", Role = "ADMIN", Age = 50, Marks = null, CreatedAt = new DateTime(2020, 06, 20) });

            users.Add(new User() { Name = "Stefan", Role = "MODERATOR", Age = 50, Marks = null, CreatedAt = new DateTime(2010, 01, 20) });
            users.Add(new User() { Name = "Róża", Role = "MODERATOR", Age = 65, Marks = null, CreatedAt = new DateTime(2020, 04, 20) });
            users.Add(new User() { Name = "Grzegorz", Role = "MODERATOR", Age = 55, Marks = null, CreatedAt = new DateTime(2022, 03, 20) });
            users.Add(new User() { Name = "Andrzej", Role = "MODERATOR", Age = 45, Marks = null, CreatedAt = new DateTime(2022, 04, 20) });

            users.Add(new User() { Name = "Erwin", Role = "TEACHER", Age = 35, Marks = null, CreatedAt = new DateTime(2020, 06, 20), RemovedAt = new DateTime(2022, 06, 20) });
            users.Add(new User() { Name = "Aleksandra", Role = "TEACHER", Age = 55, Marks = null, CreatedAt = new DateTime(2020, 01, 20) });
            users.Add(new User() { Name = "Erwin", Role = "TEACHER", Age = 30, Marks = null, CreatedAt = new DateTime(2020, 06, 20) });

            users.Add(new User() { Name = "Dominik", Role = "STUDENT", Age = 15, Marks = new int[] { 1, 3, 5 }, CreatedAt = new DateTime(2020, 06, 20) });
            users.Add(new User() { Name = "Nina", Role = "STUDENT", Age = 15, Marks = new int[] { 1, 5, 5 }, CreatedAt = new DateTime(2020, 06, 20) });
            users.Add(new User() { Name = "Dawids", Role = "STUDENT", Age = 10, Marks = new int[] { 5, 5, 5 }, CreatedAt = new DateTime(2020, 06, 20) });
            users.Add(new User() { Name = "Marcin", Role = "STUDENT", Age = 11, Marks = new int[] { 3, 3 }, CreatedAt = new DateTime(2020, 06, 20) });
            users.Add(new User() { Name = "Damian", Role = "STUDENT", Age = 16, Marks = new int[] { 5, 3 }, CreatedAt = new DateTime(2020, 06, 20) });
            users.Add(new User() { Name = "Jolanta", Role = "STUDENT", Age = 12, Marks = new int[] { 5, 5, 2 }, CreatedAt = new DateTime(2020, 06, 20) });
            users.Add(new User() { Name = "Sara", Role = "STUDENT", Age = 12, Marks = new int[] { 3, 5, }, CreatedAt = new DateTime(2020, 06, 20) });
            users.Add(new User() { Name = "Kamila", Role = "STUDENT", Age = 6, Marks = new int[] { 4, 1 }, CreatedAt = new DateTime(2020, 06, 20) });
            users.Add(new User() { Name = "Dawid", Role = "STUDENT", Age = 14, Marks = new int[] { 5, 4, 3 }, CreatedAt = new DateTime(2022, 06, 20), RemovedAt = new DateTime(2022, 06, 20) });
            users.Add(new User() { Name = "Paulina", Role = "STUDENT", Age = 10, Marks = new int[] { 1, 4, 2 }, CreatedAt = new DateTime(2020, 12, 20) });
            users.Add(new User() { Name = "Stefan", Role = "STUDENT", Age = 15, Marks = new int[] { 4, 1, 2 }, CreatedAt = new DateTime(2020, 06, 20) });

            return users;
        }
    }
}