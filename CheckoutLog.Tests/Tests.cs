using Xunit;
using CheckoutLog;

public class Tests
{
    [Fact]
    public void CleanEntry_RemovesExtraSpaces()
    {
        var result = CheckoutProcessor.CleanEntry("  Book   123  ");

        Assert.Equal("Book 123", result);
    }

    [Fact]
    public void SaveAndReadEntry_Works()
    {
        var path = Path.GetTempFileName();

        CheckoutProcessor.SaveEntry("Book 123", path);

        Assert.Equal("Book 123", CheckoutProcessor.ReadEntry(path));

        File.Delete(path);
    }

    [Fact]
    public void AppendEntry_AddsNewEntry()
    {
        var path = Path.GetTempFileName();

        CheckoutProcessor.SaveEntry("First", path);
        CheckoutProcessor.AppendEntry("Second", path);

        var content = CheckoutProcessor.ReadEntry(path);

        Assert.Contains("First", content);
        Assert.Contains("Second", content);

        File.Delete(path);
    }
}