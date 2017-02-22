using System;

namespace GildedRose
{
    public interface IQualityUpdater
    {
        int ComputeQuality(IItem item);
    }

    public class AgedBrieQualityUpdater : IQualityUpdater
    {
        public int ComputeQuality(IItem item)
        {
            return item.Quality + (item.SellIn < 0 ? 2 : 1);
        }
    }

    public class BackstageQualityUpdater : IQualityUpdater
    {
        public int ComputeQuality(IItem item)
        {
            return (new ConcertTicketBuyJustSaveTheDate()).UpdateState(item)
                                                          .ComputeQuality(item);
        }
    }
}
