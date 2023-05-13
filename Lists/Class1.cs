using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortedList_exercies
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.Title = "SortedList";
            var people = new SortedList<string, Person>
            {
                {"trump", new Person { Name = "Donald Trump", DateOfBirth = new DateTime(1990, 1, 1), Email = "trump@gmail.com", Phone = "01234.567.890"} },
                {"putin", new Person { Name = "Vladimir Putin", DateOfBirth = new DateTime(1990, 1, 2), Email = "putin@gmail.com", Phone = "01234.567.890"} },
                {"macron", new Person { Name = "Emmanuel Macron", DateOfBirth = new DateTime(1990, 1, 3), Email = "macron@gmail.com", Phone = "01234.567.890"} },
                {"merkel", new Person { Name = "Angela Merkel", DateOfBirth = new DateTime(1990, 1, 4), Email = "merkel@gmail.com", Phone = "01234.567.890"} },
            };

            //people[key] tương đương với people.Value
            //duyệt qua sortedList qua key
            foreach (var key in people.Keys) WriteLine($"-{people[key].Name}");
            
            //duyệt qua sortedList qua value
            foreach (var p in people)
            {
                WriteLine($"-{p.Value.Name}, born {p.Value.DateOfBirth.ToShortDateString()}, contact: {p.Value.Email}, {p.Value.Phone}");
            }

            //kiếm chỉ số thông qua khóa
            WriteLine($"chỉ số của Putin trong danh sách: {people.IndexOfKey("Putin")}");
            ReadKey();
        }
     
        }

    }
    class Person
    {
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
