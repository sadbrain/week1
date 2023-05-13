using System;
using static System.Console;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace P01_Binary
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
                DateOfBirth = new DateTime(1990, 12, 30)
            };
            Console.WriteLine("Original object:");
            Print(student);
            Save(student);
            var nva = Load();
            Console.WriteLine("Deserialized object:");
            Print(nva);
            Console.ReadKey();
        }
        static void Print(Student student)
        {
            Console.WriteLine($"Id: {student.Id}\r\nFirst Name: {student.FirstName}\r\nLast Name: {student.LastName}\r\nDate of birth: {student.DateOfBirth.ToShortDateString()}");
        }
        static void Save(Student student)
        {
            using (var stream = File.OpenWrite("data.xml"))
            {
                // tạo adapter stream loại viết văn bản 
                var writer = new StreamWriter(stream) { AutoFlush = true};
                //tạo một đối tượng của class JsonSerializer
                var seriallized = new JsonSerializer();
                //gọi hàm thực hiện việc chuyển đổi obj => mảng byte
                //hàm này nhận hai tham số TextWriter and obj
                seriallized.Serialize(writer, student);
            }
        }
        static Student Load()
        {
            Student student;
            using (var stream = File.OpenRead("data.xml"))
            {
                // tạo adapter stream loại đọc văn bản 
                var reader = new StreamReader(stream);
                //tạo một đối tượng của class JsonSerializer
                var serializer = new JsonSerializer();
                //gọi hàm thực hiện việc chuyển đổi mảng byte => obj
                //hàm này nhận hai tham số TextReader and type of obj trả về obj
                student = serializer.Deserialize(reader, typeof(Student)) as Student;
            }
            return student;
        }
    }
}