using System;
using EvolvingPythagoreansTheorem.EnvironmentInteractions;
using EvolvingPythagoreansTheorem.ProblemsToSolve.PythagoreanTheorem;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class TestHarness
    {
        [Ignore]
        [Test]
        public void RunSimulation()
        {
            var lifeCycle = new GeneLifeCycle();
            var bestGene = lifeCycle.Go();
            Console.WriteLine("Best Gene: " + bestGene);
            Console.WriteLine("Score: " + new PythagoreanProblemDescription().ScoreThis(bestGene));
        }
    }
}
