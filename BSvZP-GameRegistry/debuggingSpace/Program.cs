using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace debuggingSpace
{
    public class A
    {
        public int m;

        public A()
        {
            m = 22;
        }
    }


    public class B
    {
        public A bsA;

        public B( ref A a )
        {
            bsA = a;
            changeA();
        }

        private void changeA()
        {
            bsA.m = -99;
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            A a = new A();
            Console.WriteLine("a.m = {0}", a.m);
            B b = new B(ref a);
            Console.WriteLine("a.m = {0}", a.m);
            Console.Read();


        }
    }
}
