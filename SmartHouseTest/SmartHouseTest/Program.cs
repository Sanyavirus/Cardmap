using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using SmartHouseTest.TcpClient;

namespace SmartHouseTest
{

    class Program
    {
        interface IFuckingTest
        {
            void Test();
        }
        interface ITest
        {
            void Test();
        }

        class Derived : TcpClient.Base, ITest, IFuckingTest
        {
            public int X = 5;
            public void Test()
            {
                base.Test();
                Console.WriteLine("Test from Derived {0}", X);
            }
        }
        public class Base : ITest, IFuckingTest
        {
            public int X = 2;
            public void Test()
            {
                Console.WriteLine("Test from Base {0}", X);
            }
        }
        static void Main(string[] args)
        {
            IFuckingTest f = new Derived();
            f.Test();
            Console.ReadKey();
        }
    }
}
