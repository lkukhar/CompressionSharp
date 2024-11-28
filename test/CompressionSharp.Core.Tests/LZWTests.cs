namespace CompressionSharp.Core.Tests;

public class LZWTests
{
    [Fact]
    public void CompressTest()
    {
        var text = "Foo bar baz";
        var compressed = LZW.Compress(text);
        var expected = new List<byte> { 70, 111, 111, 32, 98, 97, 114, 3, 97, 122 };
        Assert.Equal(expected, compressed);
    }
}
