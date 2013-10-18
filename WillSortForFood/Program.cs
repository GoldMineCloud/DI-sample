using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using Autofac.Builder;
using LinqLib.Sort;
using WillSortForFood.Evaluators;
using WillSortForFood.Sorters;

namespace WillSortForFood
{
    class Program
    {
        static void Main(string[] args)
        {
            #region DI
            var builder = new ContainerBuilder();
            builder.RegisterType<DependencyInjectionSortingEvaluator>().As<ISortingEvaluator>();
            builder.RegisterType<MergeSorter>().As<ISorter>();
            var container = builder.Build();

            //var evaluator = container.Resolve<ISortingEvaluator>();
            //var result = evaluator.EvaluateOn(ArrayOfRandomIntegers(1000));
            //Print(result);
            #endregion

            #region no-DI

            var evaluator = new SortingEvaluator();
            var result = evaluator.EvaluateOn(ArrayOfRandomIntegers(10000));
            Print(result);

            #endregion

            #region ServiceLocation
            //ISortingEvaluator sortingEvaluator = new ServiceLocatorSortingEvaluator(container);
            //var result = sortingEvaluator.EvaluateOn(ArrayOfRandomIntegers(10000));
            //Print(result);

            #endregion

            #region for-fun

            //ISortingEvaluator sortingEvaluator = new DependencyInjectionSortingEvaluator(new BubbleSorter());
            //var resultB = sortingEvaluator.EvaluateOn(Enumerable.Range(0, 100).Reverse());
            //Print(resultB);

            //const int n = 10000;
            //new []
            //{
            //    Evaluate(n, SortType.Bubble),
            //    Evaluate(n, SortType.Heap),
            //    Evaluate(n, SortType.Insert),
            //    Evaluate(n, SortType.Merge),
            //    Evaluate(n, SortType.Quick),
            //    Evaluate(n, SortType.Select),
            //    Evaluate(n, SortType.Shell)
            //}
            //.OrderBy(x => x.TimeInMs)
            //.ToList()
            //.ForEach(Print);

            #endregion
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

            Console.Write(", first elemnent is {0}, last is {1}",
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
