using System;

namespace Program 
{
    class Prog
    {
        enum XD
        {
            Iwo,
            Marek,
            Knur=2
        }
        public static void Main(string[] args)
        {
            Console.WriteLine(XD.Knur);
        }
    }
}