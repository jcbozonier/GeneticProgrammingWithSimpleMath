namespace EvolvingPythagoreansTheorem.GenomeEvaluation
{
    public class SymbolReader
    {
        readonly string _Genome;
        int _CurrentIndex = -1;

        public SymbolReader(string genome)
        {
            _Genome = genome;
        }

        public string ReadNextSymbol()
        {
            _CurrentIndex++;
            return _Genome[_CurrentIndex].ToString();
        }
    }
}