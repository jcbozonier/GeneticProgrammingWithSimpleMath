using EvolvingPythagoreansTheorem.EnvironmentInteractions;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class When_mutating_a_gene_that_does_mutate
    {
        GeneMutator Mutator;
        string TheGene;
        string TheMutatedGene;
        int MaxGeneSize;

        [Test]
        public void It_should_NOT_match_the_gene_offered_for_mutation()
        {
            Assert.That(TheMutatedGene, Is.Not.EqualTo(TheGene));
        }

        [Test]
        public void It_should_be_twice_as_long()
        {
            Assert.That(TheMutatedGene.Length, Is.EqualTo(TheGene.Length * 2));
        }

        [Test]
        public void It_should_be_somewhat_randomized()
        {
            Assert.That(TheMutatedGene.IndexOf(TheGene), Is.Not.EqualTo(0));
        }

        [Test]
        public void It_should_not_have_a_copy_of_itself_at_its_tail()
        {
            Assert.That(TheMutatedGene.LastIndexOf(TheGene), Is.Not.EqualTo(3));
        }

        [SetUp]
        public void Context()
        {
            TheGene = "+xy";
            MaxGeneSize = 5;
            Mutator = new GeneMutator(new[] { "+", "-", "/", "*", "r", "a", "b" }, 1, MaxGeneSize);
            Because();
        }

        void Because()
        {
            TheMutatedGene = Mutator.Mutate(TheGene);
        }
    }

    [TestFixture]
    public class When_mutating_a_gene_that_does_not_mutate
    {
        GeneMutator Mutator;
        string TheGene;
        string TheMutatedGene;
        int MaxGeneSize;

        [Test]
        public void It_should_match_the_gene_offered_for_mutation()
        {
            Assert.That(TheMutatedGene, Is.EqualTo(TheGene));
        }

        [SetUp]
        public void Context()
        {
            TheGene = "+xy";
            MaxGeneSize = 4;
            Mutator = new GeneMutator(new[] { "+", "-", "/", "*", "r", "a", "b" }, 0, MaxGeneSize);
            Because();
        }

        void Because()
        {
            TheMutatedGene = Mutator.Mutate(TheGene);
        }
    }
}
