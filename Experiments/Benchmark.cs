using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using Experiments.Domain;
using Experiments.Dtos;

namespace Experiments
{
    [MemoryDiagnoser, Orderer(SummaryOrderPolicy.FastestToSlowest)]
    public class Benchmark
    {
        [Benchmark]
        public CatDtoWritten ManualMap() => MapperExperiments.ManualMapperExperiment();

        [Benchmark]
        public CatDtoWritten ExpressMap() => MapperExperiments.ExpressMapperExperiment();

        [Benchmark]
        public CatDtoWritten AutoMap() => MapperExperiments.AutoMapperExperiment();

        [Benchmark]
        public CatDtoWritten MapsterAdapt() => MapperExperiments.MapsterAdaptExperiment();

        [Benchmark]
        public CatDtoWritten MapsterAdaptWithConfiguration() => MapperExperiments.MapsterAdaptWithConfigurationExperiment();

        [Benchmark]
        public Domain.CatDto MapsterCodeGen() => MapperExperiments.MapsterCodegenexperiment();
    }
}