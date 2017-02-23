namespace GildedRose
{
    public interface IItem
    {
        string Name { get; }

        int SellIn { get; }

        int Quality { get; }

        void Update();
    }

    public abstract class BaseItem : IItem
    {
        protected BaseItem() { }
        private int _quality;

        protected BaseItem(string name, int sellIn, int quality)
        {
            Name = name;
            SellIn = sellIn;
            _quality = quality;
        }

        public string Name { get; protected set; }
        public int Quality
        {
            get { return _quality; }
            protected set
            {
                _quality = value < 0 ? 0 : value > 50 ? 50 : value;
            }
        }
        public int SellIn { get; protected set; }

        public abstract void Update();

        protected void UpdateSellIn()
        {
            SellIn -= 1;
        }
    }
}
