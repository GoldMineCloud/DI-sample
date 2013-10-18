using System.Collections.Generic;

namespace WillSortForFood.Sorters
{
    internal interface ISorter
    {
        string AlgorithmName { get; }
        int[] Sort(IEnumerable<int> items);
    }
}