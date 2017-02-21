using System;
using System.Collections.Generic;

namespace GildedRose
{
    class GildedRose
    {
        IList<IItem> Items;
        public GildedRose(IList<IItem> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                Items[i].Update();
            }
        }
    }

    public interface IItem
    {
        string Name { get; set; }

        int SellIn { get; set; }

        int Quality { get; set; }

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

        public string Name { get; set; }
        public int Quality
        {
            get { return _quality; }
            set
            {
                _quality = value < 0 ? 0 : value > 50 ? 50 : value;
            }
        }
        public int SellIn { get; set; }

        public abstract void Update();

        protected void UpdateSellIn()
        {
            SellIn -= 1;
        }
    }

    public class Item : BaseItem
    {
        public Item() { }

        public Item(string name, int sellIn, int quality)
            : base(name, sellIn, quality) { }

        public override void Update()
        {
            UpdateSellIn();
            Quality -= GetSellInModifier();
        }

        private int GetSellInModifier()
        {
            return SellIn < 0 ? 2 : 1;
        }
    }

    public class Sulfuras : BaseItem
    {
        public Sulfuras() : base("Sulfuras, Hand of Ragnaros", 0, 80) { }

        public Sulfuras(int sellIn)
            : base("Sulfuras, Hand of Ragnaros", sellIn, 80) { }

        public override void Update() { }
    }

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
        public string Name { get { return "Aged Brie"; } }

        IQualityUpdater IFactory<IQualityUpdater>.Create()
        {
            return new AgedBrieQualityUpdater();
        }
    }

    public class BackstageToken : ISpecialItemToken
    {
        public string Name { get { return "Backstage passes to a TAFKAL80ETC concert"; } }

        IQualityUpdater IFactory<IQualityUpdater>.Create()
        {
            return new BackstageQualityUpdater();
        }
    }

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

    public class SpecialItem : BaseItem
    {
        private IQualityUpdater _qualityUpdater;

        public SpecialItem() { }

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
