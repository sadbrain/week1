using System;
using System.Reflection;
using static System.Console;
using System.Reflection;
namespace Attribute_Exercise
{
     //Đánh dấu custom attribute này được sử dụng bởi những class
    [AttributeUsage(AttributeTargets.Class)]
    //Tạo một attribute có tên là MyCustomAttribute có mộ thuộc tính là Description
    public class MyCustomAttribute : Attribute
    {
        public string Description { get; set; }
        public int num;


        public MyCustomAttribute(string description)
        {

            Description = description;
        }
    }
    // cách sử dụng custom attribute
    [MyCustom("This is a costum attribute")]

    public class MyClass
    {
        static void Main(string[] args)
        {


            //lấy thông tin attribute trong lúc runtime bằng cách sử dụng reflection
            //class type cung cấp các phương thức láy thông tin của các kiểu dữ liệu
            //cụ thể ở đây trả về class  MyCustomAttribute hay còn là custom attribute
            //mỗi phương thức trả về một hay một mảng đối tượng lưu trữ thông tin của mỗi thành viên trong kiễu dữ liệu
            Type type = typeof(MyClass);
            //type.GetCustomAttributes(typeof(MyCustomAttribute), true)[0] trả về custom attribute của MyClass
            MyCustomAttribute attribute = (MyCustomAttribute) type.GetCustomAttributes(typeof(MyCustomAttribute), true)[0];
            WriteLine(attribute.Description); 
          

        }
    }
}
