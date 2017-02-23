using NUnit.Framework;
using System.Collections.Generic;

namespace GildedRose
{
    [TestFixture()]
    public class GildedRoseRefactoredTest
    {
        [Test()]
        public void fooItem()
        {
            var Items = new BasicItem("foo", 0, 0);
            Items.Update();
            Assert.AreEqual("foo", Items.Name);
            Assert.AreEqual(-1, Items.SellIn);
            Assert.AreEqual(0, Items.Quality);
        }

        [Test()]
        public void fooItem_outdated()
        {
            var Items = new BasicItem("foo", -1, 1);
            Items.Update();
            Assert.AreEqual("foo", Items.Name);
            Assert.AreEqual(-2, Items.SellIn);
            Assert.AreEqual(0, Items.Quality);
        }

        [Test()]
        public void Aged_Brie()
        {
            var Items = new SpecialItem(new AgedBrieToken(), 10, 1);
            Items.Update();
            Assert.AreEqual("Aged Brie", Items.Name);
            Assert.AreEqual(9, Items.SellIn);
            Assert.AreEqual(2, Items.Quality);
            Items.Update();
            Assert.AreEqual(8, Items.SellIn);
            Assert.AreEqual(3, Items.Quality);
        }

        [Test()]
        public void Aged_Brie_outdated()
        {
            var Items = new SpecialItem(new AgedBrieToken(), 0, 2);
            Items.Update();
            Assert.AreEqual("Aged Brie", Items.Name);
            Assert.AreEqual(-1, Items.SellIn);
            Assert.AreEqual(4, Items.Quality);
        }

        [Test()]
        public void Aged_Brie_Higthest_Quality()
        {
            var Items = new SpecialItem(new AgedBrieToken(), 10, 50);
            Items.Update();
            Assert.AreEqual("Aged Brie", Items.Name);
            Assert.AreEqual(9, Items.SellIn);
            Assert.AreEqual(50, Items.Quality);
            Items.Update();
            Assert.AreEqual(8, Items.SellIn);
            Assert.AreEqual(50, Items.Quality);
        }

        [Test()]
        public void Aged_Brie_Higthest_Quality_outdated()
        {
            var Items = new SpecialItem(new AgedBrieToken(), -1, 50);
            Items.Update();
            Assert.AreEqual("Aged Brie", Items.Name);
            Assert.AreEqual(-2, Items.SellIn);
            Assert.AreEqual(50, Items.Quality);
        }

        [Test()]
        public void wow_Sulfuras_outdated()
        {
            var Items = new Sulfuras(-1);
            Items.Update();
            Assert.AreEqual("Sulfuras, Hand of Ragnaros", Items.Name);
            Assert.AreEqual(-1, Items.SellIn);
            Assert.AreEqual(80, Items.Quality);
        }

        [Test()]
        public void wow_Sulfuras()
        {
            var Items = new Sulfuras(10);
            Items.Update();
            Assert.AreEqual("Sulfuras, Hand of Ragnaros", Items.Name);
            Assert.AreEqual(10, Items.SellIn);
            Assert.AreEqual(80, Items.Quality);
        }

        [Test()]
        public void Backstage()
        {
            var Items = new SpecialItem(new BackstageToken(), 15, 1);
            Items.Update();
            Assert.AreEqual("Backstage passes to a TAFKAL80ETC concert", Items.Name);
            Assert.AreEqual(14, Items.SellIn);
            Assert.AreEqual(2, Items.Quality);
        }

        [Test()]
        public void Backstage_Close_To_Date()
        {
            var Items = new SpecialItem(new BackstageToken(), 3, 30);
            Items.Update();
            Assert.AreEqual("Backstage passes to a TAFKAL80ETC concert", Items.Name);
            Assert.AreEqual(2, Items.SellIn);
            Assert.AreEqual(33, Items.Quality);
        }

        [Test()]
        public void Backstage_outdated()
        {
            var Items =new SpecialItem(new BackstageToken(), -1, 50);
            Items.Update();
            Assert.AreEqual("Backstage passes to a TAFKAL80ETC concert", Items.Name);
            Assert.AreEqual(-2, Items.SellIn);
            Assert.AreEqual(0, Items.Quality);
        }

        [Test()]
        public void Conjured_man_Cake_SellIn_0()
        {
            var Items = new ConjuredItem("Conjured Mana Cake", 0, 3);
            Items.Update();
            Assert.AreEqual("Conjured Mana Cake", Items.Name);
            Assert.AreEqual(-1, Items.SellIn);
            Assert.AreEqual(0, Items.Quality);
        }

        [Test()]
        public void Conjured_man_Cake()
        {
            var Items = new ConjuredItem("Conjured Mana Cake", 5, 3);
            Items.Update();
            Assert.AreEqual("Conjured Mana Cake", Items.Name);
            Assert.AreEqual(4, Items.SellIn);
            Assert.AreEqual(1, Items.Quality);
        }

        [Test()]
        public void Conjured_man_Cake_outdated()
        {
            var Items = new ConjuredItem("Conjured Mana Cake", -2, 10);
            Items.Update();
            Assert.AreEqual("Conjured Mana Cake", Items.Name);
            Assert.AreEqual(-3, Items.SellIn);
            Assert.AreEqual(6, Items.Quality);
        }
    }
}

