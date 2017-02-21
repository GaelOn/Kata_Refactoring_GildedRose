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
            IList<IItem> Items = new List<IItem> { new Item("foo", 0, 0) };
			GildedRose app = new GildedRose(Items);
			app.UpdateQuality();
			Assert.AreEqual("foo", Items[0].Name);
            Assert.AreEqual(-1, Items[0].SellIn);
            Assert.AreEqual(0, Items[0].Quality);
		}

        [Test()]
        public void fooItem_outdated()
        {
            IList<IItem> Items = new List<IItem> { new Item("foo", -1, 1) };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual("foo", Items[0].Name);
            Assert.AreEqual(-2, Items[0].SellIn);
            Assert.AreEqual(0, Items[0].Quality);
        }

        [Test()]
        public void Aged_Brie()
        {
            IList<IItem> Items = new List<IItem> { new SpecialItem(new AgedBrieToken(), 10, 1 ) };
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
        public void Aged_Brie_outdated()
        {
            IList<IItem> Items = new List<IItem> { new SpecialItem(new AgedBrieToken(), 0, 2) };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual("Aged Brie", Items[0].Name);
            Assert.AreEqual(-1, Items[0].SellIn);
            Assert.AreEqual(4, Items[0].Quality);
        }

        [Test()]
        public void Aged_Brie_Higthest_Quality()
        {
            IList<IItem> Items = new List<IItem> { new SpecialItem(new AgedBrieToken(), 10, 50) };
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
            IList<IItem> Items = new List<IItem> { new SpecialItem(new AgedBrieToken(), -1, 50) };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual("Aged Brie", Items[0].Name);
            Assert.AreEqual(-2, Items[0].SellIn);
            Assert.AreEqual(50, Items[0].Quality);
        }

        [Test()]
        public void wow_Sulfuras_outdated()
        {
            IList<IItem> Items = new List<IItem> { new Sulfuras(-1) };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual("Sulfuras, Hand of Ragnaros", Items[0].Name);
            Assert.AreEqual(-1, Items[0].SellIn);
            Assert.AreEqual(80, Items[0].Quality);
        }

        [Test()]
        public void wow_Sulfuras()
        {
            IList<IItem> Items = new List<IItem> { new Sulfuras(10) };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual("Sulfuras, Hand of Ragnaros", Items[0].Name);
            Assert.AreEqual(10, Items[0].SellIn);
            Assert.AreEqual(80, Items[0].Quality);
        }

        [Test()]
        public void Backstage()
        {
            IList<IItem> Items = new List<IItem> { new SpecialItem(new BackstageToken(), 15, 1) };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual("Backstage passes to a TAFKAL80ETC concert", Items[0].Name);
            Assert.AreEqual(14, Items[0].SellIn);
            Assert.AreEqual(2, Items[0].Quality);
        }

        [Test()]
        public void Backstage_Close_To_Date()
        {
            IList<IItem> Items = new List<IItem> { new SpecialItem(new BackstageToken(), 3, 30) };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual("Backstage passes to a TAFKAL80ETC concert", Items[0].Name);
            Assert.AreEqual(2, Items[0].SellIn);
            Assert.AreEqual(33, Items[0].Quality);
        }

        [Test()]
        public void Backstage_outdated()
        {
            IList<IItem> Items = new List<IItem> { new SpecialItem(new BackstageToken(), -1, 50) };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual("Backstage passes to a TAFKAL80ETC concert", Items[0].Name);
            Assert.AreEqual(-2, Items[0].SellIn);
            Assert.AreEqual(0, Items[0].Quality);
        }

        [Test()]
        public void Conjured_man_Cake_SellIn_0()
        {
            IList<IItem> Items = new List<IItem> { new Item("Conjured Mana Cake", 0, 3) };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual("Conjured Mana Cake", Items[0].Name);
            Assert.AreEqual(-1, Items[0].SellIn);
            Assert.AreEqual(1, Items[0].Quality);
        }
    }
}

