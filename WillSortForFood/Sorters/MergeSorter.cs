using LinqLib.Sort;

namespace WillSortForFood.Sorters
{
    public class MergeSorter : SorterBase
    {
        protected override SortType sortType
        {
            get { return SortType.Merge; }
        }
    }
}