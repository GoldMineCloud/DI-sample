using LinqLib.Sort;

namespace WillSortForFood.Sorters
{
    public class SelectSorter : SorterBase
    {
        protected override SortType sortType
        {
            get { return SortType.Select; }
        }
    }
}