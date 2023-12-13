using GildedRose;
using GildedRoseKata;
using System;

namespace GildedRoseTests
{
    public static class ItemBuilder
    {
        public static StandardItem CreateStandardItem(int quality, int sellIn)
        {
            return new StandardItem(new Item { Name = "standard item", Quality = quality, SellIn = sellIn });
        }

        public static AgedBrieItem CreateAgedBrieItem(int quality, int sellIn)
        {
            return new AgedBrieItem(new Item { Name = "aged brie item", Quality = quality, SellIn = sellIn });
        }
        public static SulfurasItem CreateSulfurasItem(int quality, int sellIn)
        {
            return new SulfurasItem(new Item { Name = "sulfuras item", Quality = quality, SellIn = sellIn });
        }
        public static BackstagePassItem CreateBackstagePassItem(int quality, int sellIn)
        {
            return new BackstagePassItem(new Item { Name = "backstage pass item", Quality = quality, SellIn = sellIn });
        }
    }
}
