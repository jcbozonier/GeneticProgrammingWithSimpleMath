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
            lifeCycle.Go(new PythagoreanTheoremSolverConfiguration(),
                         (bestGene, score)=>
                         {
                             Console.WriteLine("Best Gene: " + bestGene);
                             Console.WriteLine("Score: " + score);
                         });
        }
    }
}
