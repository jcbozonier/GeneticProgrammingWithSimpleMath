using System;
using System.Collections.Generic;
using EvolvingPythagoreansTheorem.ProblemInterfaces;

namespace EvolvingPythagoreansTheorem.ProblemsToSolve.PythagoreanTheorem
{
    public class PythagoreanTheoremSolverConfiguration : IGenePoolConfiguration
    {
        public PythagoreanTheoremSolverConfiguration()
        {
            GeneGrammar = new[] { "+", "-", "/", "*", "r", "a", "b" };
            GenerationRunCount = 1000000;
            MaximumGeneLength = 15;
            ProbabilityOfMutation = .25;
            PopulationSizeToMaintain = 625;
            KeepTheTopNPerformersEachGeneration = 5;
            StopIfScoreIsAtLeastThisHigh = 1.032;
        }

        public IEnumerable<string> GeneGrammar{ get; private set; }
        public int GenerationRunCount { get; private set; }
        public int KeepTheTopNPerformersEachGeneration { get; private set; }
        public int MaximumGeneLength { get; private set; }
        public int PopulationSizeToMaintain { get; private set; }
        public double ProbabilityOfMutation { get; private set; }
        public double StopIfScoreIsAtLeastThisHigh { get; private set; }
        public ICanScore GetProblemDescription()
        {
            return new PythagoreanProblemDescription(MaximumGeneLength);
        }
    }
}