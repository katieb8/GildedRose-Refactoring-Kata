using GildedRoseKata;

namespace GildedRose
{
    public class StandardItem : GildedRoseItem
    {
        public StandardItem(Item item) : base(item)
        {
        }

        public override void UpdateQuality()
        {
            var sellIn = Item.SellIn;
            if (sellIn > 0)
            {
                Item.Quality--;
            }
            else
            {
                Item.Quality -= 2;
            }

            if (Item.Quality < 0)
            {
                Item.Quality = 0;
            }
        }
    }
}
