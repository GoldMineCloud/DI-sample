using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using LinqLib.Sort;
using WillSortForFood.Sorters;

namespace WillSortForFood.Evaluators
{
    class SortingEvaluator : ISortingEvaluator
    {
        

        public EvaluationResult EvaluateOn(IEnumerable<int> items)
        {
            var sorter = new BubbleSorter(); //evil =)

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            int[] sortedItems = sorter.Sort(items);

            stopwatch.Stop();

            return new EvaluationResult(sorter.AlgorithmName)
            {
                TimeInMs = stopwatch.ElapsedMilliseconds,
                SortedItems = sortedItems
            };
        }
    }
}