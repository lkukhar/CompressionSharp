using BenchmarkDotNet.Attributes;
using CompressionSharp.Core;

namespace CompressionSharp.Benchmarks;

public class LZWBenchmarks
{
    [Benchmark]
    public void Compress() => LZW.Compress(LoremIpsum.Text);
}
