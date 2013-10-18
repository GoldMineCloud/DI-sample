using LinqLib.Sort;

namespace WillSortForFood.Sorters
{
    public class YouPickSorter : SorterBase
    {
        private SortType pickedByYouSorter { get; set; }

        public YouPickSorter(SortType sortType)
        {
            pickedByYouSorter = sortType;
        }

        protected override SortType sortType
        {
            get { return pickedByYouSorter; }
        }
    }
}