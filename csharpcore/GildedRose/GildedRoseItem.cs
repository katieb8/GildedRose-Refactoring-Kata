using GildedRoseKata;

namespace GildedRose
{
    public abstract class GildedRoseItem
    {
        public Item Item;

        protected GildedRoseItem(Item item)
        {
            Item = item;
        }

        protected void UpdateQualityIfOver50()
        {
            if (Item.Quality > 50)
            {
                Item.Quality = 50;
            }
        }

        public abstract void UpdateQuality();
        public abstract void UpdateSellIn();
    }
}
