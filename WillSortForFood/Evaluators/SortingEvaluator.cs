﻿using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using LinqLib.Sort;
using WillSortForFood.Sorters;

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