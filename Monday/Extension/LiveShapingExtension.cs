using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Monday.Extension
{
    public static class LiveShapingExtension
    {
        public static void EnableLiveSorting(this ICollectionView collectionView)
        {
            #region Check Arguments

            if (collectionView is null)
            {
                throw new ArgumentNullException(nameof(collectionView));
            }

            if (!(collectionView is ICollectionViewLiveShaping liveShaping))
            {
                throw new ArgumentNullException(
                    "Cannot cast CollectionView to CollectionViewLiveShaping to enable live sorting");
            }

            #endregion

            IEnumerable<string> sortProperties =
                collectionView.SortDescriptions.Select(x => x.PropertyName);

            foreach (var item in sortProperties)
            {
                liveShaping.LiveSortingProperties.Add(item);
            }

            liveShaping.IsLiveSorting = true;
        }
    }
}