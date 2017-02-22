namespace GildedRose
{

    public class SpecialItem : BaseItem
    {
        private IQualityUpdater _qualityUpdater;

        public SpecialItem(ISpecialItemToken token, int sellIn, int quality)
            : base(token.Name, sellIn, quality)
        {
            _qualityUpdater = (token as IFactory<IQualityUpdater>).Create();
        }

        public override void Update()
        {
            UpdateSellIn();
            Quality = _qualityUpdater.ComputeQuality(this);
        }
    }

}
