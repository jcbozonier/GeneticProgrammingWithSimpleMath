using System.Collections.Generic;

namespace EvolvingPythagoreansTheorem.GenomeEvaluation
{
    public interface IEvaluatable
    {
        double Evaluate(IDictionary<string, double> variableList);
        int GetOperableGeneLength();
    }
}