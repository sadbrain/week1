// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace ConsoleApp
{
    class workWithFile
    {
        static void Main(string[] args)
        {

            //work with file

            //check path to file
            Console.WriteLine(Directory.Exists(@"C:\Program Files"));
            //get Name Folder in path to file
            Console.WriteLine(Path.GetDirectoryName(@"""C:\cmder\bin\Readme.md"""));
            //get name file, không lấy phần mở rộng and path
            Console.WriteLine(Path.GetFileNameWithoutExtension(@"""C:\cmder\bin\Readme.md"""));
            //lây phần mở rộng của file
            Console.WriteLine(Path.GetExtension(@"""C:\cmder\bin\Readme.md"""));



            //read and write in stream

            //Khởi tạo file stream

            FileStream fs = new FileStream("data1.bin", FileMode.Create);
            /*  một số cách khởi tạo khác
            FileStream fs = File.OpenRead("Readme.md");
            FileStream fs = File.OpenWrite("Readme.md");
            FileStream fs = File.Create("Readme.md"); */

            //write data into fileStream
            int i = 1234;
            string str = "Hello World";
            fs.Write(BitConverter.GetBytes(i), 0, 4);
            fs.Write(Encoding.UTF8.GetBytes(str), 0, Encoding.UTF8.GetByteCount(str));
            fs.Flush();
            fs.Close();
      
            //read data into filesteam
            fs = new FileStream("data1.bin", FileMode.OpenOrCreate, FileAccess.Read);
            //tao mảng đêm nhân giá trị từ filestream
            var buffer = new byte[4];
            fs.Read(buffer, 0, 4);
            int num = BitConverter.ToInt32(buffer, 0);
            Console.WriteLine($"num = {num}");

            int length = (int) fs.Length - 4;
            buffer = new byte[length];
            fs.Read(buffer, 0, length);
            string str2 = Encoding.UTF8.GetString(buffer);
            fs.Close();
            Console.WriteLine($"str = {str}");


            //read and write but use stream adapter 

            FileStream fs3 = new FileStream("data2.bin", FileMode.Create, FileAccess.ReadWrite);
            BinaryWriter bWriter = new BinaryWriter(fs3);
            bWriter.Write(1234);
            StreamWriter sWriter = new StreamWriter(fs3);
            sWriter.Write("Hello Majorise");
            sWriter.Flush();
            fs3.Close();

            fs3 = new FileStream("data2.bin", FileMode.OpenOrCreate, FileAccess.Read );
            BinaryReader binaryReader = new BinaryReader(fs3);
            var num2 = binaryReader.ReadInt32();
            StreamReader sReader = new StreamReader(fs3);
            var str3 = sReader.ReadToEnd();
            Console.WriteLine($"num : {num}");
            Console.WriteLine($"str : {str}");
            fs3.Close();

            Console.WriteLine(123);



        }
    }
}
