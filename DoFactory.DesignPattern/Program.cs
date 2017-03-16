using System;
using System.Collections.Generic;
using System.Linq;

namespace DoFactory.DesignPattern
{
    public class Program
    {
        public static void Main()
        {
            var examples = GetExamples();
            ShowPatternNames(examples);

            Console.WriteLine("Show Pattern");
            var pattern = string.Empty;
            while (pattern.ToLower() != "quit")
            {
                pattern = Console.ReadLine();
                if (string.IsNullOrEmpty(pattern))
                {
                    Console.WriteLine("Invalid Selection");
                    continue;
                }

                var example = examples.FirstOrDefault(c => c.PatternName.ToUpper().Contains(pattern.ToUpper()));
                if (example == null)
                {
                    Console.WriteLine("Invalid Selection");
                    continue;
                }

                Console.WriteLine("");
                Console.WriteLine($"Showing Pattern {example.PatternName}");
                example.Show();
                Console.WriteLine("---------------------------------------------------");
            }
        }

        private static void ShowPatternNames(List<IPatternExample> examples)
        {
            Console.WriteLine("Select Pattern");
            foreach (var example in examples)
            {
                Console.Write(" ");
                Console.Write(example.PatternName);
                Console.WriteLine();
            }
        }

        public static List<IPatternExample> GetExamples()
        {
            var patterns = new List<IPatternExample>();
            var type = typeof(IPatternExample);
            var types =
                AppDomain.CurrentDomain.GetAssemblies()
                    .SelectMany(s => s.GetTypes())
                    .Where(p => type.IsAssignableFrom(p) && !p.IsInterface);
            foreach (var concreteType in types)
            {
                patterns.Add((IPatternExample) Activator.CreateInstance(concreteType));
            }

            return patterns;
        }
    }
}
