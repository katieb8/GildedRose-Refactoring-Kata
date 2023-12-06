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
}