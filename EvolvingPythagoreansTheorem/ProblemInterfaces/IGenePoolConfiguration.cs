using System.Collections.Generic;

namespace EvolvingPythagoreansTheorem.ProblemInterfaces
{
    public interface IGenePoolConfiguration
    {
        IEnumerable<string> GeneGrammar { get; }
        int GenerationRunCount { get; }
        int KeepTheTopNPerformersEachGeneration { get; }
        int MaximumGeneLength { get; }
        int PopulationSizeToMaintain { get; }
        double ProbabilityOfMutation { get; }
        double StopIfScoreIsAtLeastThisHigh { get; }
        ICanScore GetProblemDescription();
    }
}