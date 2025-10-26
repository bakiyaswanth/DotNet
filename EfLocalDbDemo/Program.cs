using System;
using System.Linq;
using EfLocalDbDemo.Data;

class Program
{
    static void Main()
    {
        using (var context = new AppDbContext())
        {
            context.Database.EnsureCreated(); // Creates DB if not exists

            context.Users.Add(new User { Id = 1,Name = "Alice" });
            context.SaveChanges();

            var people = context.Users.ToList();
            foreach (var person in people)
            {
                Console.WriteLine($"ID: {person.Id}, Name: {person.Name}");
            }
        }
    }
}
