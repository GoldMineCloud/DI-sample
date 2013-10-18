using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Autofac;
using Autofac.Core;
using Autofac.Features;
using Autofac.Util;
using Autofac.Builder;
using LinqLib.Sort;
using WillSortForFood.Evaluators;
using WillSortForFood.Sorters;

namespace WillSortForFood
{
    public class Something
    {
        public Something(
            MergeSorter sorterA, 
            BubbleSorter sorterB,
            QuickSorter sorterC,
            SomeSorter sorterD)
        {
            Console.WriteLine(sorterA.AlgorithmName);
            Console.WriteLine(sorterB.AlgorithmName);
            Console.WriteLine(sorterC.AlgorithmName);
            Console.WriteLine(sorterD.AlgorithmName);
        }
    }

    public class SomeSorter : ISorter
    {
        private readonly BubbleSorter sorter;

        public SomeSorter(BubbleSorter sorter)
        {
            this.sorter = sorter;
        }

        public string AlgorithmName { get { return "custom " + sorter.AlgorithmName; } }
        public int[] Sort(IEnumerable<int> items)
        {
            return sorter.Sort(items);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<DependencyInjectionSortingEvaluator>().As<ISortingEvaluator>();
            builder.RegisterType<ShelSorter>().As<ISorter>();
            builder.RegisterType<Something>();

            //registers all types that end with "Sorter"
            var currentAssembly = Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(currentAssembly)
                .Where(t => t.Name.EndsWith("Sorter"));
            var container = builder.Build();

            container.Resolve<Something>();

            //for fun
            const int n = 10000;
            new[]
            {
                Evaluate(n, SortType.Bubble),
                Evaluate(n, SortType.Heap),
                Evaluate(n, SortType.Insert),
                Evaluate(n, SortType.Merge),
                Evaluate(n, SortType.Quick),
                Evaluate(n, SortType.Select),
                Evaluate(n, SortType.Shell)
            }
            .OrderBy(x => x.TimeInMs)
            .ToList()
            .ForEach(Print);
        }

        private static EvaluationResult Evaluate(int n, SortType sortType)
        {
            return new DependencyInjectionSortingEvaluator(new YouPickSorter(sortType))
                .EvaluateOn(ArrayOfRandomIntegers(n));
        }

        private static void Print(EvaluationResult result)
        {
            var initialColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("'{0}' ", result.SortingAlgorithmName);
            Console.ForegroundColor = initialColor;
            Console.Write("took");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(" {0}ms", result.TimeInMs);
            Console.ForegroundColor = initialColor;

            Console.Write(", first element is {0}, last is {1}",
                result.SortedItems.First(),
                result.SortedItems.Last());

            Console.WriteLine();
        }

        private static IEnumerable<int> ArrayOfRandomIntegers(int n)
        {
            var rnd = new Random((int) DateTime.Now.Ticks);
            return Enumerable.Range(0, n)
                .Select(x => rnd.Next(int.MaxValue));
        }
    }
}
