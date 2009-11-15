using System.Collections.Generic;
using System.Linq;

namespace EvolvingPythagoreansTheorem.GenomeEvaluation
{
    public class GenomeConverter
    {
        public IEvaluatable Convert(string genome)
        {
            var symbolReader = new SymbolReader(genome);

            var root = new Operand();
            var fillList = new List<IExpression> {root};

            while(fillList.Count > 0)
                fillList = _FillErUp(fillList, symbolReader);

            return root;
        }

        static List<IExpression> _FillErUp(IEnumerable<IExpression> nodes, SymbolReader symbolReader)
        {
            var childrenForNextLevel = new List<IExpression>();

            foreach(var node in nodes)
            {
                var symbol = symbolReader.ReadNextSymbol();
                node.SetLiteral(symbol);
                var childrenToCreateCount = _GetNumberOfChildrenFor(symbol);

                var childrenNodes = 0.Until(childrenToCreateCount)
                        .Select(x => new Operand())
                        .ToArray();
                childrenNodes.ForEach(node.Add);
                childrenNodes.ForEach(childrenForNextLevel.Add);
            }

            return childrenForNextLevel;
        }

        static int _GetNumberOfChildrenFor(string symbol)
        {
            switch(symbol)
            {
                case "*":
                case "/":
                case "+":
                case "-":
                    return 2;
                case "r":
                    return 1;
                default:
                    return 0;
            }
        }
    }
}