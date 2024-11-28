using CompressionSharp.Common;

namespace CompressionSharp.Core.Tests;

public class LZWTests
{
    [Fact]
    public void CompressTest()
    {
        var compressed = LZW.Compress(LoremIpsum.Text);
        Assert.Equal(LoremIpsum.Bytes, compressed);
    }
}
