using System.Collections.Generic;

namespace GildedRoseKata;

public class GildedRose
{
    private readonly IList<Item> _items;

    public GildedRose(IList<Item> items)
    {
        _items = items;
    }

    public void UpdateQuality()
    {
        for (var i = 0; i < _items.Count; i++)
        {
            if (!IsAgedBrie(i) && !IsBackstagePasses(i) && !IsSulfuras(i) && QualityGreaterThan0(i))
            {
                _items[i].Quality--;
            }
            else
            {
                IncreaseQualityForSpecialProducts(i);
            }

            if (!IsSulfuras(i))
            {
                _items[i].SellIn--;
            }

            if (!WithinSellByDate(i))
            {
                AdjustQualityIfPassedSellByDate(i);
            };

        }
    }

    private bool WithinSellByDate(int item)
    {
        return _items[item].SellIn >= 0;
    }

    private void AdjustQualityIfPassedSellByDate(int item)
    {
        if (!IsAgedBrie(item))
        {
            if (!IsBackstagePasses(item))
            {
                if (_items[item].Quality <= 0) return;
                if (!IsSulfuras(item))
                {
                    _items[item].Quality--;
                }
            }
            else
            {
                _items[item].Quality = 0;
            }
        }
        else
        {
            if (QualityLessThan50(item))
            {
                _items[item].Quality++;
            }
        }
    }

    private void IncreaseQualityForSpecialProducts(int item)
    {
        if (QualityEqualToOrGreaterThan50(item)) return;
        if (IsBackstagePasses(item))
        {
            IncreaseQualityForBackstagePasses(item);

            EnsureItemQualityDoesNotExceed50(item);
        }
        else
        {
            _items[item].Quality++;
        }
    }

    private void IncreaseQualityForBackstagePasses(int item)
    {
        if (_items[item].SellIn <= 5)
        {
            _items[item].Quality += 3;
        }
        else if (_items[item].SellIn <= 10)
        {
            _items[item].Quality += 2;
        }
        else
        {
            _items[item].Quality += 1;
        }
    }

    private void EnsureItemQualityDoesNotExceed50(int item)
    {
        if (QualityEqualToOrGreaterThan50(item))
        {
            _items[item].Quality = 50;
        }
    }

    private bool QualityEqualToOrGreaterThan50(int item)
    {
        return _items[item].Quality >= 50;
    }

    private bool QualityLessThan50(int item)
    {
        return _items[item].Quality < 50;
    }

    private bool QualityGreaterThan0(int item)
    {
        return _items[item].Quality > 0;
    }

    private bool IsSulfuras(int item)
    {
        return _items[item].Name == "Sulfuras, Hand of Ragnaros";
    }

    private bool IsBackstagePasses(int item)
    {
        return _items[item].Name == "Backstage passes to a TAFKAL80ETC concert";
    }

    private bool IsAgedBrie(int item)
    {
        return _items[item].Name == "Aged Brie";
    }
}