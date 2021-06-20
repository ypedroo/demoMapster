using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using Experiments.Dtos;

namespace Experiments
{
    [MemoryDiagnoser, Orderer(SummaryOrderPolicy.FastestToSlowest)]
    public class Benchmark
    {
        [Benchmark]
        public CatDto ManualMap() => MapperExperiments.ManualMapperExperiment();

        [Benchmark]
        public CatDto ExpressMap() => MapperExperiments.ExpressMapperExperiment();

        [Benchmark]
        public CatDto AutoMap() => MapperExperiments.AutoMapperExperiment();

        [Benchmark]
        public CatDto MapsterAdapt() => MapperExperiments.MapsterAdaptExperiment();

        [Benchmark]
        public CatDto MapsterAdaptWithConfiguration() => MapperExperiments.MapsterAdaptWithConfigurationExperiment();

        [Benchmark]
        public Domain.CatDto MapsterCodeGen() => MapperExperiments.MapsterCodegenexperiment();
    }
}