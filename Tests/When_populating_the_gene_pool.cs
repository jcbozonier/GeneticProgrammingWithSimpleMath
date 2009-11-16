using System.Collections.Generic;
using System.Linq;
using EvolvingPythagoreansTheorem.EnvironmentInteractions;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class When_populating_the_gene_pool
    {
        GeneGod God;
        IEnumerable<string> CreatedGenes;
        int RequestedGeneCount;
        string[] GeneGrammar;

        [Test]
        public void The_genes_should_only_contain_charcters_from_the_grammar()
        {
            Assert.That(CreatedGenes.All(x => x.All(y => GeneGrammar.ToList().Contains(y.ToString()))), Is.True);
        }

        [Test]
        public void It_should_create_the_correct_number_of_genes()
        {
            Assert.That(CreatedGenes.Count(), Is.EqualTo(RequestedGeneCount));
        }

        [SetUp]
        public void Setup()
        {
            RequestedGeneCount = 10;
            GeneGrammar = new[] {"a", "b", "c"};
            God = new GeneGod(GeneGrammar, 5);
            Because();
        }

        void Because()
        {
            CreatedGenes = God.CreateCountOfGenes(RequestedGeneCount);
        }
    }
}
