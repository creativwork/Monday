using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Monday.Helper
{
    public static class CollectionExtension
    {
        public static void AddRange<T>(this ObservableCollection<T> collection, IEnumerable<T> items)
            => items.ToList().ForEach(collection.Add);

        public static void AddRangeCleared<T>(this ObservableCollection<T> collection, IEnumerable<T> items)
        {
            collection.Clear();
            items.ToList().ForEach(collection.Add);
        }
    }
}