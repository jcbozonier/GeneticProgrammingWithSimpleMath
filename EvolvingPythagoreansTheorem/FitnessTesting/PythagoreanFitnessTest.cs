using System;
using System.Collections.Generic;
using System.Linq;

namespace EvolvingPythagoreansTheorem.FitnessTesting
{
    public class PythagoreanContest
    {
        public ScoreCards ScoreThese(IEnumerable<string> genomes)
        {
            return new ScoreCards(genomes
                                          .Select(genome =>
                                                  new ScoreCard(genome,
                                                                _ScoreGenome(
                                                                        new TwoInputGenomeEvaluator(genome)))));
        }

        static double _ScoreGenome(TwoInputGenomeEvaluator genomeEvaluator)
        {
            var score = 0.0;

            // Hypoteneuse must be longer than leg a
            {
                var a = 6;
                var b = 9;
                var c = genomeEvaluator.Evaluate(a, b);

                score += c > a ? 1 : 0;
            }

            // Hypoteneuse must be longer than leg b
            {
                var a = 1;
                var b = 20;
                var c = genomeEvaluator.Evaluate(a, b);

                score += c > b ? 1 : 0;
            }

            // Hypoteneuse must be shorter than leg a + leg b
            {
                var a = 3;
                var b = 4;
                var c = genomeEvaluator.Evaluate(a, b);

                score += c < a + b ? 1 : 0;
            }

            // Hypoteneuse is a if b == 0
            {
                var a = 3;
                var b = 0;
                var c = genomeEvaluator.Evaluate(a, b);

                score += c == a ? 1 : 0;
            }

            // Hypoteneuse is b if a == 0
            {
                var a = 0;
                var b = 4;
                var c = genomeEvaluator.Evaluate(a, b);

                score += c == b ? 1 : 0;
            }

            // Hypoteneuse is 0 if a == 0 && b == 0
            {
                var a = 0;
                var b = 0;
                var c = genomeEvaluator.Evaluate(a, b);

                score += c == b ? 1 : 0;
            }

            // Hypoteneuse is a*sqrt(2) if a == b
            {
                var a = 48;
                var b = a;
                var c = genomeEvaluator.Evaluate(a, b);

                score -= Math.Abs(c.Squared() - 2 * a.Squared());
            }

            return score;
        }
    }
}
