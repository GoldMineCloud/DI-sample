using System.Collections.Generic;
using System.Diagnostics;
using Autofac;
using WillSortForFood.Sorters;

namespace WillSortForFood.Evaluators
{
    class ServiceLocatorSortingEvaluator : ISortingEvaluator
    {
        private readonly IContainer container;

        public ServiceLocatorSortingEvaluator(IContainer container)
        {
            this.container = container;
        }

        public EvaluationResult EvaluateOn(IEnumerable<int> items)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            var sorter = container.Resolve<ISorter>();
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