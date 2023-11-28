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

        public abstract void UpdateQuality();
    }
}
