using BenchmarkDotNet.Running;

namespace CompressionSharp.Benchmarks;

public static class Program
{
    public static void Main(string[] args)
    {
        BenchmarkRunner.Run<LZWBenchmarks>();
    }
}
