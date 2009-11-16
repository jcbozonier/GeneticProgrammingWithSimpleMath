using System;
using System.Collections.Generic;
using System.Linq;
using EvolvingPythagoreansTheorem.BreedingSelection;
using EvolvingPythagoreansTheorem.ProblemsToSolve.PythagoreanTheorem;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class When_fitness_testing_a_genome_that_goes_to_infinity
    {
        IEnumerable<string> Genes;
        string PythagoreanGenome;
        BreedingSelectionProcess BreederSelector;

        [Test]
        public void It_should_return_the_best_fit()
        {
            Assert.That(Genes.Single(), Is.EqualTo(PythagoreanGenome));
        }

        [SetUp]
        public void Setup()
        {
            BreederSelector = new BreedingSelectionProcess(new PythagoreanProblemDescription());
            PythagoreanGenome = "r+**aabb";
            Genes = new[] { "/ab", PythagoreanGenome };
            Because();
        }

        void Because()
        {
            Genes = BreederSelector.ChooseTopNPerformers(Genes, 1);
        }
    }

    [TestFixture]
    public class When_fitness_testing_genomes
    {
        IEnumerable<string> Genes;
        string PythagoreanGenome;
        BreedingSelectionProcess BreederSelector;

        [Test]
        public void It_should_return_the_best_fit()
        {
            Assert.That(Genes.Single(), Is.EqualTo(PythagoreanGenome));
        }

        [SetUp]
        public void Setup()
        {
            BreederSelector = new BreedingSelectionProcess(new PythagoreanProblemDescription());
            PythagoreanGenome = "r+**aabb";
            Genes = new[] { "+ab", PythagoreanGenome };
            Because();
        }

        void Because()
        {
            Genes = BreederSelector.ChooseTopNPerformers(Genes, 1);
        }
    }
}
