using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EvolvingPythagoreansTheorem.EnvironmentInteractions;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class When_mating_genes
    {
        GeneGrotto TheGeneGrotto;
        string[] TheGenes;
        IEnumerable<string> BabyGenes;

        [Test]
        public void Each_gene_should_be_different()
        {
            Assert.That(BabyGenes.Intersect(BabyGenes).Count(), Is.EqualTo(4));
        }

        [Test]
        public void It_should_create_a_gene_cross_product_result()
        {
            Assert.That(BabyGenes.Count(), Is.EqualTo(4));
        }

        [SetUp]
        public void Context()
        {
            TheGenes = new[] {"+ab", "-cd"};
            TheGeneGrotto = new GeneGrotto();
            BabyGenes = TheGeneGrotto.GetItOn(TheGenes);
        }
    }
}
