using GildedRoseKata;

namespace GildedRose
{
    public class BackstagePassItem : GildedRoseItem
    {
        public BackstagePassItem(Item item) : base(item)
        {
        }

        public override void UpdateQuality()
        {
            if (Item.SellIn <= 0)
            {
                Item.Quality = 0;
            }
            else if (Item.SellIn <= 5)
            {
                Item.Quality += 3;
            }
            else if (Item.SellIn <= 10)
            {
                Item.Quality += 2;
            }
            else
            {
                Item.Quality += 1;
            }

            UpdateQualityIfOver50();
        }

        public override void UpdateSellIn()
        {
            Item.SellIn--;
        }
    }
}