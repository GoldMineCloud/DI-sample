using System.Collections.Generic;
using System.Linq;
using LinqLib.Sort;

namespace WillSortForFood.Sorters
{
    public abstract class SorterBase : ISorter
    {
        protected abstract SortType sortType { get; }
        
        public string AlgorithmName
        {
            get { return sortType.ToString(); }
        }

        public int[] Sort(IEnumerable<int> items)
        {
            return items.OrderBy(x => x, sortType).ToArray();
        }
    }
}