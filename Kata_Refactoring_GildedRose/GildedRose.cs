using System.Collections.Generic;

namespace GildedRose
{
	class GildedRose
	{
		IList<Item> Items;
		public GildedRose(IList<Item> Items) 
		{
			this.Items = Items;
		}
		
		public void UpdateQuality()
		{
			for (var i = 0; i < Items.Count; i++)
			{
                // quality updated
				if (Items[i].Name != "Aged Brie" && 
                    Items[i].Name != "Backstage passes to a TAFKAL80ETC concert" &&
                    Items[i].Name != "Sulfuras, Hand of Ragnaros")
				{
                    UpdateQualityOfStandardItem(Items[i]);
				}
                else if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
				{
                    UpdateSpecialButNotLegendaryItem(Items[i]);

                    if (Items[i].Name == "Backstage passes to a TAFKAL80ETC concert")
                    {
                        UpdateBackstageQuality(Items[i]);
                    }
				}
				
                // sellin update
				if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
				{
					Items[i].SellIn = Items[i].SellIn - 1;
				}
				
				if (Items[i].SellIn < 0)
				{
					if (Items[i].Name != "Aged Brie")
					{
						if (Items[i].Name != "Backstage passes to a TAFKAL80ETC concert")
						{
							if (Items[i].Quality > 0)
							{
								if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
								{
									Items[i].Quality = Items[i].Quality - 1;
								}
							}
						}
						else
						{
							Items[i].Quality = Items[i].Quality - Items[i].Quality;
						}
					}
					else
					{
						if (Items[i].Quality < 50)
						{
							Items[i].Quality = Items[i].Quality + 1;
						}
					}
				}
			}
		}

        private void UpdateQualityOfStandardItem(Item item)
        {
            if (item.Quality > 0)
            {
                item.Quality = item.Quality - 1;
            }
        }

        private void UpdateBackstageQuality(Item item)
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

        private void UpdateSpecialButNotLegendaryItem(Item item)
        {
            if (item.Quality < 50)
            {
                AddOneQualityPoint(item);
            }
        }

        private void AddOneQualityPoint(Item item)
        {
            item.Quality += 1;
        }
	}
	
	public class Item
	{
		public string Name { get; set; }
		
		public int SellIn { get; set; }
		
		public int Quality { get; set; }
	}
	
}
