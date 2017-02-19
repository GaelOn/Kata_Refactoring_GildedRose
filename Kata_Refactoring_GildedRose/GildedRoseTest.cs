using System;
using NUnit.Framework;
using System.Collections.Generic;

namespace GildedRose
{
	[TestFixture()]
	public class GildedRoseTest
	{
		[Test()]
		public void fooItem() 
        {
			IList<Item> Items = new List<Item> { new Item{Name = "foo", SellIn = 0, Quality = 0} };
			GildedRose app = new GildedRose(Items);
			app.UpdateQuality();
			Assert.AreEqual("foo", Items[0].Name);
            Assert.AreEqual(-1, Items[0].SellIn);
            Assert.AreEqual(0, Items[0].Quality);
		}

        [Test()]
        public void fooItem_outdated()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = -1, Quality = 1 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual("foo", Items[0].Name);
            Assert.AreEqual(-2, Items[0].SellIn);
            Assert.AreEqual(0, Items[0].Quality);
        }

        [Test()]
        public void Aged_Brie()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 10, Quality = 1 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual("Aged Brie", Items[0].Name);
            Assert.AreEqual(9, Items[0].SellIn);
            Assert.AreEqual(2, Items[0].Quality);
            app.UpdateQuality();
            Assert.AreEqual(8, Items[0].SellIn);
            Assert.AreEqual(3, Items[0].Quality);
        }

        [Test()]
        public void Aged_Brie_Higthest_Quality()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 10, Quality = 50 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual("Aged Brie", Items[0].Name);
            Assert.AreEqual(9, Items[0].SellIn);
            Assert.AreEqual(50, Items[0].Quality);
            app.UpdateQuality();
            Assert.AreEqual(8, Items[0].SellIn);
            Assert.AreEqual(50, Items[0].Quality);
        }

        [Test()]
        public void Aged_Brie_Higthest_Quality_outdated()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = -1, Quality = 50 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual("Aged Brie", Items[0].Name);
            Assert.AreEqual(-2, Items[0].SellIn);
            Assert.AreEqual(50, Items[0].Quality);
        }

        [Test()]
        public void wow_Sulfuras_outdated()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual("Sulfuras, Hand of Ragnaros", Items[0].Name);
            Assert.AreEqual(-1, Items[0].SellIn);
            Assert.AreEqual(80, Items[0].Quality);
        }

        [Test()]
        public void wow_Sulfuras()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 10, Quality = 80 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual("Sulfuras, Hand of Ragnaros", Items[0].Name);
            Assert.AreEqual(10, Items[0].SellIn);
            Assert.AreEqual(80, Items[0].Quality);
        }

        [Test()]
        public void Backstage()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 1 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual("Backstage passes to a TAFKAL80ETC concert", Items[0].Name);
            Assert.AreEqual(14, Items[0].SellIn);
            Assert.AreEqual(2, Items[0].Quality);
        }

        [Test()]
        public void Backstage_Close_To_Date()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 3, Quality = 30 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual("Backstage passes to a TAFKAL80ETC concert", Items[0].Name);
            Assert.AreEqual(2, Items[0].SellIn);
            Assert.AreEqual(33, Items[0].Quality);
        }

        [Test()]
        public void Backstage_outdated()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = -1, Quality = 50 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual("Backstage passes to a TAFKAL80ETC concert", Items[0].Name);
            Assert.AreEqual(-2, Items[0].SellIn);
            Assert.AreEqual(0, Items[0].Quality);
        }
	}
}

