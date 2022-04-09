using System;
using System.Collections.Generic;
using System.Linq;

namespace VSG_Test
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = 8;

            var a = new List<int>();

            for (int i = num; i > 0; i--)
            {
                num = num * i;
            }



            Console.WriteLine(num);
        }
    }
}
