namespace GildedRose
{
    public interface ISpecialItemToken : IFactory<IQualityUpdater>
    {
        string Name { get; }
    }

    public interface IFactory<out TOut>
    {
        TOut Create();
    }

    public class AgedBrieToken : ISpecialItemToken
    {
        public string Name
        {
            get { return "Aged Brie"; }
        }

        IQualityUpdater IFactory<IQualityUpdater>.Create()
        {
            return new AgedBrieQualityUpdater();
        }
    }

    public class BackstageToken : ISpecialItemToken
    {
        public string Name
        {
            get { return "Backstage passes to a TAFKAL80ETC concert"; }
        }

        IQualityUpdater IFactory<IQualityUpdater>.Create()
        {
            return new BackstageQualityUpdater();
        }
    }
}
