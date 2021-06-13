using BenchmarkDotNet.Running;

namespace Experiments
{
    class Program
    {
        static void Main(string[] args)
        {
           BenchmarkRunner.Run<Benchmark>();
        }
    }
}