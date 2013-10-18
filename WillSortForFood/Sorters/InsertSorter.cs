﻿using LinqLib.Sort;

namespace WillSortForFood.Sorters
{
    public class InsertSorter : SorterBase
    {
        protected override SortType sortType
        {
            get { return SortType.Insert; }
        }
    }
}