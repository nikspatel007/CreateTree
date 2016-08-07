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
            string sample = "(id,created,employee(id,firstname,employeeType(id), lastname),location)";
            var parser = new Parser(sample);
            parser.Parse().WriteInOrder();
            Console.ReadLine();
        }
    }
}
