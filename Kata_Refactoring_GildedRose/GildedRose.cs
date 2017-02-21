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
                // quality updated
                if (Items[i].Name != "Aged Brie" &&
                    Items[i].Name != "Backstage passes to a TAFKAL80ETC concert")
                {
                    //UpdateQualityOfStandardItem(Items[i]);
                    Items[i].Update();
                }
                else if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
                {
                    UpdateSpecialButNotLegendaryItem(Items[i]);

                    if (Items[i].Name == "Backstage passes to a TAFKAL80ETC concert")
                    {
                        UpdateBackstageQuality(Items[i]);
                    }
                }

                // sellin update, diamond never die, neither Sulfuras ;)
                if (Items[i].Name == "Aged Brie" ||
                    Items[i].Name == "Backstage passes to a TAFKAL80ETC concert")
                //if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
                {
                    Items[i].SellIn = Items[i].SellIn - 1;
                }

                // quality update once again
                if (Items[i].SellIn < 0)
                {
                    if (Items[i].Name != "Aged Brie" &&
                        Items[i].Name != "Backstage passes to a TAFKAL80ETC concert")
                    {
                        //UpdateQualityOfStandardItem(Items[i]);
                    }
                    else 
                    if (Items[i].Name == "Backstage passes to a TAFKAL80ETC concert")
                    {
                        Items[i].Quality = 0;
                    }
                    else if (Items[i].Name == "Aged Brie")
                    {
                        UpdateSpecialButNotLegendaryItem(Items[i]);
                    }
                }
            }
        }

        private void UpdateQualityOfStandardItem(IItem item)
        {
            if (item.Quality > 0)
            {
                item.Quality = item.Quality - 1;
            }
        }

        private void UpdateBackstageQuality(IItem item)
        {
            if (item.SellIn < 11 && item.Quality < 50)
            {
                AddOneQualityPoint(item);
            }

            if (item.SellIn < 6 && item.Quality < 50)
            {
                AddOneQualityPoint(item);
            }
        }

        private void UpdateSpecialButNotLegendaryItem(IItem item)
        {
            if (item.Quality < 50)
            {
                AddOneQualityPoint(item);
            }
        }

        private void AddOneQualityPoint(IItem item)
        {
            item.Quality += 1;
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
        public int SellIn  { get; set; }

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

}
