using System.Collections.Generic;
using System.Diagnostics;
using WillSortForFood.Sorters;

namespace WillSortForFood.Evaluators
{
    class ServiceLocatorSortingEvaluator : ISortingEvaluator
    {
        private readonly dynamic container;

        public ServiceLocatorSortingEvaluator(dynamic container)
        {
            this.container = container;
        }

        public EvaluationResult EvaluateOn(IEnumerable<int> items)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            var sorter = (ISorter)container.Resolve<ISorter>();
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