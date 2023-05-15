// See https://aka.ms/new-console-template for more information
using System;
using static System.Console;

using System.IO;
using System.Xml.Serialization;

namespace Serialization_exercise
{

    [Serializable]
    public class Student
    {
        public int Id { get; set; } = 1;
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public DateTime DateOfBirth { get; set; } = DateTime.Now;
    }
    class Program
    {
        static void Main(string[] args)
        {
            var student = new Student
            {
                Id = 1,
                FirstName = "Nguyen Van",
                LastName = "A",
                DateOfBirth = new DateTime(2004, 1, 6)
            };
            WriteLine("Original object:");
            Print(student);
            Save(student);
            var nva = Load();
            WriteLine("Deserialized object:");
            Print(nva);
            Console.ReadKey();
        }

        static void Print(Student student)
        {
            WriteLine($"Id: {student.Id}\r\nFirst Name: {student.FirstName}\r\nLast Name: {student.LastName}\r\nDate of birth: {student.DateOfBirth.ToShortDateString()}");
        }

        // chuyển object sang dạng xml và lưu vào stream
        static void Save(Student student)
        {
            using (var stream = File.OpenWrite("data.xml"))// tạo fileStream để ghi
            {
                // chuyển object sang dạng xml và lưu vào stream
                XmlSerializer serializer = new XmlSerializer(typeof(Student));
                serializer.Serialize(stream, student);
            }

        }

        //đọc xml và biến đổi object
        static Student Load()
        {
            Student student;
            using (var stream = File.OpenRead("data.xml"))// mở fileStream để đọc
            {
                var serializer = new XmlSerializer(typeof(Student));
                student = serializer.Deserialize(stream) as Student;
            }
            return student;
        }
    }
}
