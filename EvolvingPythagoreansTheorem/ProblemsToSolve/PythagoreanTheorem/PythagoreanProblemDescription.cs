using System;
using System.Collections.Generic;
using EvolvingPythagoreansTheorem.GenomeEvaluation;
using EvolvingPythagoreansTheorem.ProblemInterfaces;

namespace EvolvingPythagoreansTheorem.ProblemsToSolve.PythagoreanTheorem
{
    public class PythagoreanProblemDescription : ICanScore
    {
        IDictionary<string, double> _Parameters;

        public double ScoreThis(string genome)
        {
            var genomeEvaluator = new GenomeConverter().Convert(genome);
            _Parameters = new Dictionary<string, double>() {{"a", 0.0}, {"b", 0.0}};

            var score = _GetScoreByInferenceOfRules(genomeEvaluator);
            //var score = _GetScoreByEvaluatingClosenessToRealDeal(genomeEvaluator);

            return score;
        }

        public double Evaluate(IEvaluatable node, int a, int b)
        {
            _Parameters["a"] = a;
            _Parameters["b"] = b;

            return node.Evaluate(_Parameters);
        }

        double _GetScoreByEvaluatingClosenessToRealDeal(IEvaluatable node)
        {
            var aggregateResult = 0.0;

            for(var a=100; a < 105; a++)
            {
                for(var b=100; b<105; b++)
                {
                    var geneResult = Evaluate(node, a, b);
                    var actualResult = Math.Sqrt(a.Squared() + b.Squared());

                    aggregateResult += - Math.Abs(geneResult - actualResult);
                }
            }

            return aggregateResult / 100;
        }

        double _GetScoreByInferenceOfRules(IEvaluatable genomeEvaluator) {
            var score = 0.0;

            // Hypoteneuse must be longer than leg a
            {
                var a = 6;
                var b = 9;
                var c = Evaluate(genomeEvaluator, a, b);

                score += c > a ? .16 : 0;
            }

            // Hypoteneuse must be longer than leg b
            {
                var a = 1;
                var b = 20;
                var c = Evaluate(genomeEvaluator, a, b);

                score += c > b ? .16 : 0;
            }

            // Hypoteneuse must be shorter than leg a + leg b
            {
                var a = 3;
                var b = 4;
                var c = Evaluate(genomeEvaluator, a, b);

                score += c < a + b ? .16 : 0;
            }

            // Hypoteneuse is a if b == 0
            {
                var a = 3;
                var b = 0;
                var c = Evaluate(genomeEvaluator, a, b);

                score += c == a ? .16 : 0;
            }

            // Hypoteneuse is b if a == 0
            {
                var a = 0;
                var b = 4;
                var c = Evaluate(genomeEvaluator, a, b);

                score += c == b ? .16 : 0;
            }

            // Hypoteneuse is 0 if a == 0 && b == 0
            {
                var a = 0;
                var b = 0;
                var c = Evaluate(genomeEvaluator, a, b);

                score += c == b ? .16 : 0;
            }

            // Hypoteneuse is a*sqrt(2) if a == b
            {
                var a = 1;
                var b = a;
                var c = Evaluate(genomeEvaluator, a, b);

                score += -Math.Abs(2*a.Squared() - c.Squared());
            }

            if (double.IsInfinity(score))
                score = double.MinValue;
            return score;
        }
    }
}