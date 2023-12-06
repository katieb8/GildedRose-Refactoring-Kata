using GildedRoseKata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose
{
    public class ConjuredItem :GildedRoseItem
    {
        public ConjuredItem(Item item) : base(item)
        {
        }

        public override void UpdateQuality()
        {
            var sellIn = Item.SellIn;
            if (sellIn > 0)
            {
                Item.Quality-=2;
            }
            else
            {
                Item.Quality -= 4;
            }

            if (Item.Quality < 0)
            {
                Item.Quality = 0;
            }
        }

        public override void UpdateSellIn()
        {
            Item.SellIn--;
        }
    }
}
