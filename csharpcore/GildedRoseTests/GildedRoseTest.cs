using GildedRose;
using NUnit.Framework;

namespace GildedRoseTests;

public class GildedRoseTest
{
    [Test]
    public void StandardItemQualityDecreasesBy1_WhenSellInNotPassed()
    {
        var standardItem = ItemBuilder.CreateStandardItem(30, 5);
        standardItem.UpdateQuality();
        Assert.AreEqual(29, standardItem.Item.Quality);
    }

    [Test]
    public void StandardItemQualityDecreasesBy2_WhenSellInNotPassed()
    {
        var standardItem = ItemBuilder.CreateStandardItem(10, 0);
        standardItem.UpdateQuality();
        Assert.AreEqual(8, standardItem.Item.Quality);
    }

    [Test]
    public void AgedBrieItemQualityIncreasesBy1_WhenSellInNotPassed()
    {
        var agedBrieItem = ItemBuilder.CreateAgedBrieItem(16, 5);
        agedBrieItem.UpdateQuality();
        Assert.AreEqual(17, agedBrieItem.Item.Quality);
    }

    [Test]
    public void AgedBrieItemQualityIncreasesBy2_WhenSellInHasPassed()
    {
        var agedBrieItem = ItemBuilder.CreateAgedBrieItem(2, -1);
        agedBrieItem.UpdateQuality();
        Assert.AreEqual(4, agedBrieItem.Item.Quality);
    }
}