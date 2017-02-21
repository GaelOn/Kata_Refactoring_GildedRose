using System;
using System.Collections.Generic;

namespace GildedRose
{
	class Program
	{
		public static void Main(string[] args)
		{
			System.Console.WriteLine("OMGHAI!");

            IList<IItem> Items = new List<IItem>{
                new Item("+5 Dexterity Vest", 10, 20),
                new SpecialItem(new AgedBrieToken(), 2, 0),
                new Item("Elixir of the Mongoose", 5, 7),
                new Sulfuras(0),
                new Sulfuras(-1),
                new SpecialItem(new BackstageToken(), 15, 20),
                new SpecialItem(new BackstageToken(), 10, 49),
                new SpecialItem(new BackstageToken(), 5, 49),
				// this conjured item does not work properly yet
                new Item ("Conjured Mana Cake", 3, 6)
			};

			var app = new GildedRose(Items);

			
			for (var i = 0; i < 31; i++)
			{
				System.Console.WriteLine("-------- day " + i + " --------");
				System.Console.WriteLine("name, sellIn, quality");
				for (var j = 0; j < Items.Count; j++)
				{
					System.Console.WriteLine(Items[j].Name + ", " + Items[j].SellIn + ", " + Items[j].Quality);
				}
				System.Console.WriteLine("");
				app.UpdateQuality();
			}

		}

	}
}
