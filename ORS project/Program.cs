using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;
namespace ORS_project
{
    class Program
    {
        static void Main(string[] args)
        {
            Solver solve = new Solver();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(@"
                    _______________________________________
                                SIMPLEX GENERATOR ver 1.2   
                    _______________________________________
            ");
            Console.ResetColor();

            Console.WriteLine("Enter the name of the output File");
            string ouputfile = Console.ReadLine();

            solve.Reader();// method for reading the input textfile
            solve.SubSolver();
            solve.SolverCal();
            solve.Display(ouputfile);

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;// looking cool code
            Console.WriteLine("Solving ..");
            Console.ResetColor();
            Thread.Sleep(1000);
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Solving ....");
            Console.ResetColor();
            Thread.Sleep(1000);
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Solving ......");
            Console.ResetColor();
            Thread.Sleep(1000);
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Solving .........");
            Console.ResetColor();
            Thread.Sleep(1000);
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("Solving ............");
            Console.ResetColor();
            Thread.Sleep(1000);
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Solving Complete");
            Thread.Sleep(1000);
            Console.Clear();
            Console.ResetColor();
            Console.WriteLine("SOLUTION CREATED");
            Console.WriteLine("--------^|^------- PRESS ANY KEY ------^|^-------------");
            Console.ReadKey();
        }
    }

}