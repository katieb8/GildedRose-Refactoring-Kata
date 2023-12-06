using GildedRose;
using System.Collections.Generic;

namespace GildedRoseKata;

public class GildedRose
{
    private readonly IList<GildedRoseItem> _items;

    public GildedRose(IList<GildedRoseItem> items)
    {
        _items = items;
    }

    public void UpdateQuality()
    {
        foreach (var item in _items)
        {
            item.UpdateQuality();
            item.UpdateSellIn();
        }
    }
}