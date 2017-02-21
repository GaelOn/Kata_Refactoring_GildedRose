using System;
using System.Collections.Generic;

namespace GildedRose
{

    public class Sulfuras : BaseItem
    {
        public Sulfuras() : base("Sulfuras, Hand of Ragnaros", 0, 80) { }

        public Sulfuras(int sellIn)
            : base("Sulfuras, Hand of Ragnaros", sellIn, 80) { }

        public override void Update() { }
    }

}
