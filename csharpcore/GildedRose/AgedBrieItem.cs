using System.Text;
using GildedRoseKata;

namespace GildedRose
{
    public class AgedBrieItem : GildedRoseItem
    {
        public AgedBrieItem(Item item) : base(item)
        {
        }

        public override void UpdateQuality()
        {
            var sellIn = Item.SellIn;
            if (sellIn > 0)
            {
                Item.Quality++;
            }
            else
            {
                Item.Quality += 2;
            }
        }

        public override void UpdateSellIn()
        {
            Item.SellIn--;
        }
    }
}
