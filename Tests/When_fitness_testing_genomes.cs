using EvolvingPythagoreansTheorem.FitnessTesting;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class When_fitness_testing_genomes
    {
        PythagoreanContest TheContest;
        string[] Genomes;
        string PythagoreanGenome;
        ScoreCards TheScoreCards;

        [Test]
        public void It_should_return_the_best_fit()
        {
            Assert.That(TheScoreCards.GetBestGene(), Is.EqualTo(PythagoreanGenome));
        }

        [SetUp]
        public void Setup()
        {
            TheContest = new PythagoreanContest();
            PythagoreanGenome = "r+**aabb";
            Genomes = new[] { "+ab", PythagoreanGenome};
            Because();
        }

        void Because()
        {
            TheScoreCards = TheContest.ScoreThese(Genomes);
        }
    }
}
