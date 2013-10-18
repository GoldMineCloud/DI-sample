using LinqLib.Sort;

namespace WillSortForFood.Sorters
{
    public class HeapSorter : SorterBase
    {
        protected override SortType sortType
        {
            get { return SortType.Heap; }
        }
    }
}