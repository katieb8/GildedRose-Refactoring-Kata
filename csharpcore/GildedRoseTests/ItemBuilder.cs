using GildedRose;
using GildedRoseKata;

namespace GildedRoseTests
{
    public static class ItemBuilder
    {
        public static StandardItem CreateStandardItem(int quality, int sellIn)
        {
            return new StandardItem(new Item { Name = "standard item", Quality = quality, SellIn = sellIn });
        }
    }
}
