﻿using GildedRose;
using GildedRoseKata;
using System;
using System.Collections.Generic;

namespace GildedRoseTests;

public static class TextTestFixture
{
    public static void Main(string[] args)
    {
        Console.WriteLine("OMGHAI!");

        var items = new List<GildedRoseItem>()
        {
            new StandardItem(new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20}),
            new AgedBrieItem(new Item {Name = "Aged Brie", SellIn = 2, Quality = 0}),
            new StandardItem(new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7}),
            new SulfurasItem(new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80}),
            new SulfurasItem(new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80}),
            new BackstagePassItem(new Item
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = 15,
                Quality = 20
            }),
            new BackstagePassItem(new Item
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = 10,
                Quality = 49
            }),
            new BackstagePassItem(new Item
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = 5,
                Quality = 49
            }),
            new ConjuredItem( // this conjured item does not work properly yet
                new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 16})
        };


        var app = new GildedRoseKata.GildedRose(items);

        int days = 18;
        if (args.Length > 0)
        {
            days = int.Parse(args[0]) + 1;
        }

        for (var i = 0; i < days; i++)
        {
            Console.WriteLine("-------- day " + i + " --------");
            Console.WriteLine("name, sellIn, quality");
            for (var j = 0; j < items.Count; j++)
            {
                Console.WriteLine(items[j].Item.Name + ", " + items[j].Item.SellIn + ", " + items[j].Item.Quality);
            }
            Console.WriteLine("");
            app.UpdateQuality();
        }
    }
}