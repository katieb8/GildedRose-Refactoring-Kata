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
        //foreach (var item in _items)
        //{
        //    item.UpdateQuality();
        //    item.Item.SellIn--;
        //}

        for (var i = 0; i < _items.Count; i++)
        {
            if (_items[i] is StandardItem)
            {
                _items[i].UpdateQuality();
                _items[i].Item.SellIn--;
            }
            else
            {
                if (!IsAgedBrie(i) && !IsBackstagePasses(i) && !IsSulfuras(i) && QualityGreaterThan0(i))
                {
                    _items[i].Item.Quality--;
                }
                else
                {
                    IncreaseQualityForSpecialProducts(i);
                }

                if (!IsSulfuras(i))
                {
                    _items[i].Item.SellIn--;
                }

                if (!WithinSellByDate(i))
                {
                    AdjustQualityIfPassedSellByDate(i);
                };
            }


        }
    }

    private bool WithinSellByDate(int item)
    {
        return _items[item].Item.SellIn >= 0;
    }

    private void AdjustQualityIfPassedSellByDate(int item)
    {
        if (!IsAgedBrie(item))
        {
            if (!IsBackstagePasses(item))
            {
                if (_items[item].Item.Quality <= 0) return;
                if (!IsSulfuras(item))
                {
                    _items[item].Item.Quality--;
                }
            }
            else
            {
                _items[item].Item.Quality = 0;
            }
        }
        else
        {
            if (QualityLessThan50(item))
            {
                _items[item].Item.Quality++;
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
            _items[item].Item.Quality++;
        }
    }

    private void IncreaseQualityForBackstagePasses(int item)
    {
        if (_items[item].Item.SellIn <= 5)
        {
            _items[item].Item.Quality += 3;
        }
        else if (_items[item].Item.SellIn <= 10)
        {
            _items[item].Item.Quality += 2;
        }
        else
        {
            _items[item].Item.Quality += 1;
        }
    }

    private void EnsureItemQualityDoesNotExceed50(int item)
    {
        if (QualityEqualToOrGreaterThan50(item))
        {
            _items[item].Item.Quality = 50;
        }
    }

    private bool QualityEqualToOrGreaterThan50(int item)
    {
        return _items[item].Item.Quality >= 50;
    }

    private bool QualityLessThan50(int item)
    {
        return _items[item].Item.Quality < 50;
    }

    private bool QualityGreaterThan0(int item)
    {
        return _items[item].Item.Quality > 0;
    }

    private bool IsSulfuras(int item)
    {
        return _items[item] is SulfurasItem;
    }

    private bool IsBackstagePasses(int item)
    {
        return _items[item] is BackstagePassItem;
    }

    private bool IsAgedBrie(int item)
    {
        return _items[item] is AgedBrieItem;
    }
}