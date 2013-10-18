using System;
using System.Collections.Generic;
using System.Linq;
using LinqLib.Sort;
using WillSortForFood.Evaluators;
using WillSortForFood.Sorters;

namespace WillSortForFood
{
    class Program
    {
        static void Main(string[] args)
        {
            //SortingEvaluator evaluator = new SortingEvaluator();
            //IEnumerable<int> items = Enumerable.Range(0, 10000).Reverse();
            //var result = evaluator.Sort(items);
            //Print(result);

            //ISortingEvaluator sortingEvaluator = new BetterSortingEvaluator(new BubbleSorter());
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
        }

        private static EvaluationResult Evaluate(int n, SortType sortType)
        {
            var rnd = new Random((int)DateTime.Now.Ticks);

            var items = Enumerable.Range(0, n)
                .Select(x => rnd.Next(int.MaxValue));
            return new BetterSortingEvaluator(new YouPickSorter(sortType))
                .EvaluateOn(items);
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
    }
}
