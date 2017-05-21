using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathEngine.Core;
using MathEngine.Core.Applicables;
using MathEngine.Core.StringFormat.Parse;

namespace Sandbox
{
    class Program
    {
        static void Main(string[] args)
        {
            var parser = new Parser();

            var applicable = new CompositeApplicable(new IApplicable[]
            {
                new TermNormalize(), 
                new NumberAdd()
            });

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "") break;

                var parsed = parser.Parse(input);

                while (applicable.ApplyRecursive(parsed)) ;

                Console.WriteLine(parsed);
                Console.WriteLine();
            }
        }

        static void PrintTree(Term term, int indent, string tab)
        {
            for (int i = 0; i < indent; i++)
            {
                Console.Write(tab);
            }

            Console.WriteLine($"{term.Tag}");

            foreach (var operand in term.Operands)
            {
                PrintTree(operand, indent + 1, tab);
            }
        }
    }
}
