﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace EvolvingPythagoreansTheorem.BreedingSelection
{
    public class ScoreCards
    {
        readonly IEnumerable<ScoreCard> _Scores;

        public ScoreCards(IEnumerable<string> genomes, ICanScore genomeScorer)
        {
            _Scores = genomes.Select(genome => new ScoreCard(genome, genomeScorer.ScoreThis(genome))).ToArray();
        }

        public string GetBestGene()
        {
            return _Scores.Max(x => x).Genome;
        }

        public IEnumerable<string> GetTop(double percentageToBreed)
        {
            var geneCount = _Scores.Count();
            var numberOfGenesToBreed = (geneCount*percentageToBreed).Ceiling();

            var orderedScores = _Scores.OrderByDescending(x => x.Score);

            return orderedScores
                .Take(numberOfGenesToBreed)
                .Select(x=>x.Genome)
                .ToArray();
        }
    }
}