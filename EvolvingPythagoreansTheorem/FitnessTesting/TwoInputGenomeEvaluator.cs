using System.Collections.Generic;
using EvolvingPythagoreansTheorem.GenomeEvaluation;

namespace EvolvingPythagoreansTheorem.FitnessTesting
{
    public class TwoInputGenomeEvaluator
    {
        readonly IEvaluatable _GenomeAst;

        public TwoInputGenomeEvaluator(string genome)
        {
            _GenomeAst = new GenomeConverter().Convert(genome);
        }

        public double Evaluate(int a, int b)
        {
            return _GenomeAst.Evaluate(new Dictionary<string, double>() { { "a", a }, { "b", b } });
        }
    }
}
