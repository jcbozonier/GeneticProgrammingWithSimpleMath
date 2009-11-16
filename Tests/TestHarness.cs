using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            
            Console.WriteLine(new PythagoreanProblemDescription().ScoreThis("rr++rrb/rr/brrb*rrb+rr/*rrrarrbb++br++*a++*b++a-+"));
        }
    }
}
