using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YachtKlub
{
    public class ExceptionToConsole
    {
        public ExceptionToConsole(Exception ex)
        {
            Console.WriteLine("#########################");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("STACK TRACE:");
            Console.WriteLine();
            Console.WriteLine(ex.StackTrace);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("EX TO STRING:");
            Console.WriteLine();
            Console.WriteLine(ex.ToString());
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("INNER EX:");
            Console.WriteLine();
            Console.WriteLine(ex.InnerException);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("MESSAGE:");
            Console.WriteLine();
            Console.WriteLine(ex.Message);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("DATA:");
            Console.WriteLine();
            Console.WriteLine(ex.Data);
            Console.WriteLine();
            Console.WriteLine("#########################");
        }
    }
}
