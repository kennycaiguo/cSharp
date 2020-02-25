using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mylib;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Class1 c = new Class1();
            //c.doWork(hello);
            c.doTime(c.writeTime);
        }

        public static void hello()
        {
            Console.WriteLine("hello,pussy!!!");
            Console.ReadKey();
        }
    }
}
