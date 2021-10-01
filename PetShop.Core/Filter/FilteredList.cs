using System.Collections.Generic;

namespace PetShop.Core.Filter
{
    public class FilteredList<T>
    {
        public List<T> List { get; set; }
        public int TotalCount { get; set; }
    }
}