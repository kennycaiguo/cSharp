using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lambda
{
    class Program
    {
        static void Main(string[] args)
        {
          //(1)no parameters,no return value
            //Mydelegate md = () =>
            //{
            //    Console.WriteLine("lambda wothout parameters");
            //    Console.ReadKey();
            //};

            //md();

            //(2)one param,no return value
            //Mydelegate2 md2 = s => {
            //    Console.WriteLine("upper case:" +s.ToUpper());
            //    Console.ReadKey();
            //};

            //md2("hello world of pussoies");

            //(3)one param,has return value
            //strDelegate sd = s1 => {
            //    return s1.ToUpper();
            //};
            //string result = sd("hello world of pussoies");
            //Console.WriteLine("upper case:" + result);
            //    Console.ReadKey();

            //(4)2or more params,with return values
            //addDelegate ad = (x, y) => {
            //    return x + y;
            //};
            //int result = ad(100, 200);
            //Console.WriteLine("result is :" + result);
            //Console.ReadKey();

            //(5)以可变参数作为lanbda函数的参数，有返回值
            paramDelegate pd=(int[] ints)=>{
                int sum=0;
                foreach(int i in ints){
                 sum+=i;
                }
                return sum;
            };

            int result = pd(11, 22, 33, 44,55,66,1000);
            Console.WriteLine("result is :" + result);
            Console.ReadKey();
        }
    }
    public delegate void Mydelegate();
    public delegate void Mydelegate2(string s);
    public delegate string strDelegate(string s1);

    public delegate int addDelegate(int a,int b);
    public delegate int paramDelegate(params int[] ints);
}
