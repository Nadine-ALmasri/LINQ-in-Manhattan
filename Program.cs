using System;
using System.IO;



namespace LINQ_in_Manhattan
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, welcome to my application!");
            Neighborhood.ReadInfo("Neighborhoods.json");
        }
    }
}