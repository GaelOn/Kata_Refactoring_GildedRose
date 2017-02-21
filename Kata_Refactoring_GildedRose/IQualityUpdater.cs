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
            if (item.SellIn < 0)
            {
                return 0;
            }

            var temp = item.Quality + 1;
            if (item.SellIn < 10)
            {
                temp += 1;
            }
            if (item.SellIn < 5)
            {
                temp += 1;
            }
            return temp;
        }
    }

}
