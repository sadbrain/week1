using System;
using static System.Console;
using System.Linq;
using System.Collections.Generic;


namespace ArrayList_Exercies
{
    public class Contact
    {
        public int Age { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
    }
    class LINQ
    {
        static void Main(string[] args)
        {
            //tạo một list chưa thông tin liên hệ
            var contacts = new List<Contact>
            {
                new Contact{ Age = 11, FirstName = "Trump", LastName = "Donald", Address = "Ha Noi"},
                new Contact{ Age = 21, FirstName = "Omaba", LastName = "Barrack", Address = "Sai Gon"},
                new Contact{ Age = 31, FirstName = "Bush", LastName = "George", Address = "Ha Noi"},
                new Contact{ Age = 41, FirstName = "Bill", LastName = "Clinton", Address = "Da Nang"},
                new Contact{ Age = 51, FirstName = "Reagan", LastName = "Ronald", Address = "Da Nang"},
                new Contact{ Age = 61, FirstName = "Jimmy", LastName = "Carter", Address = "Sai Gon"},
                new Contact{ Age = 71, FirstName = "Gerald", LastName = "Ford", Address = "Ha Noi"},
                new Contact{ Age = 81, FirstName = "Nixon", LastName = "Richard", Address = "Ha Noi"},
            };

            //select các Contact có Address = Ha Noi
            //sử dụng hàm where có 2 overload 
            //1 tiếp nhận một biến delegate (contact) => bool
            //2 như trên nhưng có thêm int để lấy chỉ mục
            //kết quả biên trả về true thì contact được thêm vào danh sách kết quả

            // lọc ra các các contact có address là Ha Noi
            var hn = contacts.Where(c => c.Address == "Ha Noi");
            foreach (var result in hn) WriteLine($"first name: {result.FirstName} last name: {result.LastName} address: {result.Address} age: {result.Age}");

            WriteLine("------------------------------------------------");
            //lọc ra contact có vị trí lẽ
            var oldLocation = contacts.Where((c,i) => i % 2 != 0);
            foreach (var result in oldLocation) WriteLine($"first name: {result.FirstName} last name: {result.LastName} address: {result.Address} age: {result.Age}");
            WriteLine("------------------------------------------------");

            //hàm select có tác dụng lọc và biến đổi obj sang dạng khác
            //thay vì biến nhận kết quả danh sách nhận hết giá trị contact, thì ở đây nó chỉ có thể nhận age, full name
            //lọc ra những contact có age < 50, và hiển thị fullName 
            var young = contacts.Where(c => c.Age < 50)
                                .Select(c => new { FullName = $"{c.FirstName} {c.LastName}", c.Age });  
            foreach (var result in young) WriteLine($"age: {result.Age} full name: {result.FullName}");


        }
    }
}
