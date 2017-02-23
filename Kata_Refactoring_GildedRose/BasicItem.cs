using System;
using System.Collections.Generic;

namespace GildedRose
{

    public class BasicItem : BaseItem
    {
        public BasicItem(string name, int sellIn, int quality)
            : base(name, sellIn, quality) { }

        public override void Update()
        {
            UpdateSellIn();
            Quality -= GetSellInModifier();
        }

        protected virtual int GetSellInModifier()
        {
            return SellIn < 0 ? 2 : 1;
        }
    }

}
