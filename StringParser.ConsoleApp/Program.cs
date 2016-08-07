using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StringParser.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "(id,created,employee(id,firstname,employeeType(id), lastname),location)";
            var parser = new Parser(input).Parse();

            Console.WriteLine("---------------Input---------------------" + Environment.NewLine);
            Console.WriteLine(input + Environment.NewLine);
            
            Console.WriteLine("---------UnOrdered Output--------------");
            Console.WriteLine(parser.ToString());


            Console.WriteLine("---------Ordered Output--------------");
            parser.WriteInOrder();

            Console.ReadLine();
        }
    }
}
