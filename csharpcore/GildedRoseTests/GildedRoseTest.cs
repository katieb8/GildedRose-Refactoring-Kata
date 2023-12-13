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
    public void StandardItemQualityDecreasesBy2_WhenSellInHasPassed()
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

    [Test] // This is failing! gets to 52??
    public void AgedBrieItemQualityIsNeverOver50()
    {
        var agedBrieItem = ItemBuilder.CreateAgedBrieItem(50, -36);
        agedBrieItem.UpdateQuality();
        Assert.AreEqual(50, agedBrieItem.Item.Quality);
    }

    [Test]
    public void SulfurasItemQualityNeverDecreases()
    {
        var sulfurasItem = ItemBuilder.CreateSulfurasItem(10, -1);
        sulfurasItem.UpdateQuality();
        Assert.AreEqual(10, sulfurasItem.Item.Quality);
    }

    [Test]
    public void BackstagePassItemQualityIncreasesBy2_WhenSellInLessThan10Days()
    {
        var backstagePassItem = ItemBuilder.CreateBackstagePassItem(16, 9);
        backstagePassItem.UpdateQuality();
        Assert.AreEqual(18, backstagePassItem.Item.Quality);
    }

    [Test]
    public void BackstagePassItemQualityIncreasesBy3_WhenSellInLessThan5Days()
    {
        var backstagePassItem = ItemBuilder.CreateBackstagePassItem(16, 4);
        backstagePassItem.UpdateQuality();
        Assert.AreEqual(19, backstagePassItem.Item.Quality);
    }

    [Test]
    public void BackstagePassItemQualityIs0_WhenSellInHasPassed()
    {
        var backstagePassItem = ItemBuilder.CreateBackstagePassItem(10, -1);
        backstagePassItem.UpdateQuality();
        Assert.AreEqual(0, backstagePassItem.Item.Quality);
    }

}