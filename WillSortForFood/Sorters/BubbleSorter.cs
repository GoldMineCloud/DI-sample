using LinqLib.Sort;

namespace WillSortForFood.Sorters
{
    public class BubbleSorter : SorterBase 
    {
        protected override SortType sortType
        {
            get { return SortType.Bubble; }
        }
    }
}