using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using LinqLib.Sort;

namespace WillSortForFood.Evaluators
{
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