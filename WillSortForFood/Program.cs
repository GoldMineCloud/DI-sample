using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqLib.Sort;

namespace WillSortForFood
{
    class Program
    {
        static void Main(string[] args)
        {

            SortingEvaluator evaluator = new SortingEvaluator();
            var result = evaluator.Sort(Enumerable.Range(0, 1000).Reverse());

            Print(result);
        }

        private static void Print(EvaluationResult result)
        {
            var initialColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("");

            Console.WriteLine("'{0}' took {1}ms, first elemnent is {2}, last is {3}",
                result.SortingAlgorithmName,
                result.TimeInMs,
                result.SortedItems.First(),
                result.SortedItems.Last());
        }
    }

    interface ISortingEvaluator
    {
        EvaluationResult EvaluateOn(IEnumerable<int> items);
    }

    internal interface ISorter
    {
        string AlgorithmName { get; }
        int[] Sort(IEnumerable<int> items);
    }

    class SortingEvaluator
    {
        public EvaluationResult Sort(IEnumerable<int> items)
        {
            const SortType sortType = SortType.Select;

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            int[] sortedItems = items.OrderBy(x => x, sortType).ToArray();

            stopwatch.Stop();

            return new EvaluationResult(sortType.ToString())
            {
                TimeInMs = stopwatch.ElapsedMilliseconds,
                SortedItems = sortedItems
            };
        }
    }
}
