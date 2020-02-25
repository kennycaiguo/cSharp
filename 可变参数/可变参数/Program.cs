using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 可变参数
{
    class Program
    {
        static void Main(string[] args)
        {
            int maxnum = max(1, 2, 3,4, 5000,100);
            Console.WriteLine("最大值是:" + maxnum);
            Console.WriteLine("=============================");
            int sum = sumAny(100, 99, 44, 55, 66);
            Console.WriteLine("总和值是:" + sum);
            Console.ReadKey();
        }

        public static int max(params int[] nums){
            int maxnum = nums[0];
            foreach (int i in nums)
            {
                if (i > maxnum) {
                    maxnum = i;
                }
            }
            return maxnum;
        }

        public static int sumAny(params int[] nums)
        {
            int sum = 0;
            foreach (int i in nums)
            {
                 
                   sum += i;
                
            }
            return sum;
        }

        
        

         
    }
}
