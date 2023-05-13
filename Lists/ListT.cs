using System;
using static System.Console;

using System.Collections;
using System.Collections.Generic;



namespace ListT_Exercise
{
    class Person
    {
        public int Age { get; set; }
        public string Name { get; set; }
        public Country Country { get; set; }
    }
    enum Country
    {
        RU, VI, UK, US, DE, FR
    }
    class ListT
    {
        static void Main(string[] args)
        {

            var people = new List<Person>
            {
                new Person { Name = "Donald Trump", Age = 18, Country = Country.US },
                new Person { Name = "Vladimir Putin", Age = 19, Country = Country.RU },
                new Person { Name = "Angela Merkel", Age = 20, Country = Country.DE },
                new Person { Name = "Emmanuel Macron", Age = 21, Country = Country.FR },

            };

            Print(people);
            WriteLine("thêm nhiều phần tử");
            people.AddRange(new[] {
                new Person {Name = "Majorise" ,Age = 21,  Country = Country.US },
                new Person {Name = "hint", Age = 20, Country = Country.US}
            });
            Print(people);
            WriteLine("Xóa phần tử 5 và 6");
            people.RemoveRange(4,2);
            Print(people);

            WriteLine("chèn nhiều phần tử tại vị trí thứ 2");
            people.InsertRange(2, new[] {
                new Person {Name = "Majorise" ,Age = 21,  Country = Country.US },
                new Person {Name = "hint", Age = 20, Country = Country.US}
            });
            Print(people);


        }

        //hàm in danh sách
        static void Print(List<Person> people)
        {
            foreach(Person p in people) WriteLine($"- {p.Name}, {p.Age} years old, from {p.Country}");

        }
    }
}




