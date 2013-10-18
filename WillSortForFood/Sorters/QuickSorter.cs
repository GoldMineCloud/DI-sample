using LinqLib.Sort;

namespace WillSortForFood.Sorters
{
    public class QuickSorter : SorterBase
    {
        protected override SortType sortType
        {
            get { return SortType.Quick; }
        }
    }
}