namespace GildedRose
{
    public class Item
    {
        public string Name { get; set; }

        public int SellIn { get; set; }

        public int Quality { get; set; }
    }

    public class IItemAdapter
    {
        IItem _internalItem;

        public IItemAdapter(Item item)
        {
            _internalItem = ToIItem(item);
        }
        public IItemAdapter UpdateQuality()
        {
            _internalItem.Update();
            return this;
        }

        public Item GetItem()
        {
            return FromIItem(_internalItem);
        }

        public static Item UpdateQuality(Item item)
        {
            var adapter = (new IItemAdapter(item));
            return adapter.UpdateQuality().GetItem();
        }

        public static IItem ToIItem(Item item)
        {
            switch (item.Name)
            {
                case "Sulfuras, Hand of Ragnaros":
                    return new Sulfuras(item.SellIn);
                case "Aged Brie":
                    return new SpecialItem(new AgedBrieToken(), item.SellIn, item.Quality);
                case "Backstage passes to a TAFKAL80ETC concert":
                    return new SpecialItem(new BackstageToken(), item.SellIn, item.Quality);
                default:
                    if (item.Name.StartsWith("Conjured", System.StringComparison.Ordinal))
                    {
                        return new ConjuredItem(item.Name, item.SellIn, item.Quality);
                    }
                    return new BasicItem(item.Name, item.SellIn, item.Quality);
            }
        }

        public static Item FromIItem(IItem item)
        {
            return new Item()
            {
                Name = item.Name,
                SellIn = item.SellIn,
                Quality = item.Quality
            };
        }

    }
}
