using System;
namespace GildedRose
{
    public class ConjuredItem : BasicItem
    {
        private const string CONJURED = "Conjured ";

        private BasicItem _internalItem;

        public ConjuredItem(string name, int sellIn, int quality)
         : base(name,sellIn,quality)
        {
            if (!name.StartsWith(CONJURED, StringComparison.Ordinal))
            {
                Name = CONJURED + name;
            }
            else
            {
                Name = name;
            }
        }

        protected override int GetSellInModifier()
        {
            return SellIn < 0 ? 4 : 2;
        }
    }
}
