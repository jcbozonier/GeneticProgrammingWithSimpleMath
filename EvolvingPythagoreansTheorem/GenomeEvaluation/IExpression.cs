namespace EvolvingPythagoreansTheorem.GenomeEvaluation
{
    public interface IExpression : IEvaluatable
    {
        void Add(IExpression expression);
        void SetLiteral(string character);
        void SetOperator(Operators symbol);
    }
}