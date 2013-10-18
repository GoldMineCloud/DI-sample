using LinqLib.Sort;

namespace WillSortForFood.Sorters
{
    public class ShelSorter : SorterBase
    {
        protected override SortType sortType
        {
            get { return SortType.Shell; }
        }
    }
}