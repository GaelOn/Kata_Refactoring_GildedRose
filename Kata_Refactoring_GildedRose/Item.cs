using System;
using System.Collections.Generic;

namespace GildedRose
{

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

}
