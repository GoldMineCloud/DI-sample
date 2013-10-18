using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace WillSortForFood
{
    class BetterSortingEvaluator : ISortingEvaluator
    {
        private readonly ISorter sorter;

        public BetterSortingEvaluator(ISorter sorter)
        {
            this.sorter = sorter;
        }

        public EvaluationResult EvaluateOn(IEnumerable<int> items)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            int[] sortedItems = sorter.Sort(items).ToArray();

            stopwatch.Stop();

            return new EvaluationResult(sorter.AlgorithmName)
            {
                TimeInMs = stopwatch.ElapsedMilliseconds,
                SortedItems = sortedItems
            };
        }
    }
}