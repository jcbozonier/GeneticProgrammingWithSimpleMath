using System;
using System.Collections.Generic;
using System.Linq;

namespace EvolvingPythagoreansTheorem.BreedingSelection
{
    public class ScoreCards
    {
        readonly IEnumerable<ScoreCard> _Scores;

        public ScoreCards(IEnumerable<string> genomes, ICanScore genomeScorer)
        {
            _Scores = genomes.Select(genome => new ScoreCard(genome, genomeScorer.ScoreThis(genome)));
        }

        public string GetBestGene()
        {
            return _Scores.Max(x => x).Genome;
        }

        public IEnumerable<string> GetTop(int numberToKeep)
        {
            var orderedScores = _Scores.OrderByDescending(x => x.Score);

            return orderedScores
                .Take(numberToKeep)
                .Select(x=>x.Genome)
                .ToArray();
        }
    }
}