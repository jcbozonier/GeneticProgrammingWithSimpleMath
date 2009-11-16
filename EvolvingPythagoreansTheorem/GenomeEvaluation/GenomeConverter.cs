using System.Collections.Generic;

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
                if(symbolReader.IsEndOfSymbols())
                    break;

                var symbol = symbolReader.ReadNextSymbol();
                var theOperator = _GetOperator(symbol);
                node.SetLiteral(symbol);
                node.SetOperator(theOperator);

                var childrenToCreateCount = _GetNumberOfChildrenFor(theOperator);

                for(var i=0; i<childrenToCreateCount; i++)
                {
                    var operand = new Operand();
                    node.Add(operand);
                    childrenForNextLevel.Add(operand);
                }
            }

            return childrenForNextLevel;
        }

        static readonly Dictionary<string, Operators> _OperatorLookup = new Dictionary<string, Operators>()
                                                               {
                                                                       {"*", Operators.Multiply},
                                                                       {"/", Operators.Divide},
                                                                       {"+", Operators.Plus},
                                                                       {"-", Operators.Minus},
                                                                       {"r", Operators.Sqrt}
                                                               };

        static Operators _GetOperator(string symbol)
        {
            return _OperatorLookup.ContainsKey(symbol)
                           ? _OperatorLookup[symbol]
                           : Operators.Operand;
        }

        static int _GetNumberOfChildrenFor(Operators symbol)
        {
            switch(symbol)
            {
                case Operators.Multiply:
                case Operators.Divide:
                case Operators.Plus:
                case Operators.Minus:
                    return 2;
                case Operators.Sqrt:
                    return 1;
                default:
                    return 0;
            }
        }
    }
}