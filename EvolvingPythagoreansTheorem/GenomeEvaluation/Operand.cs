using System;
using System.Collections.Generic;

namespace EvolvingPythagoreansTheorem.GenomeEvaluation
{
    public class Operand : IExpression
    {
        readonly List<IExpression> _Operands;
        string _Literal;

        public Operand()
        {
            _Operands = new List<IExpression>();
        }

        public void Add(IExpression operand)
        {
            _Operands.Add(operand);
        }

        public double Evaluate(IDictionary<string, double> variableList)
        {
            switch (_Literal)
            {
                case "+":
                    return _Operands[0].Evaluate(variableList) + _Operands[1].Evaluate(variableList);
                case "-":
                    return _Operands[0].Evaluate(variableList) - _Operands[1].Evaluate(variableList);
                case "*":
                    return _Operands[0].Evaluate(variableList) * _Operands[1].Evaluate(variableList);
                case "/":
                    return _Operands[0].Evaluate(variableList) / _Operands[1].Evaluate(variableList);
                case "r":
                    return Math.Sqrt(_Operands[0].Evaluate(variableList));
                default:
                    return variableList[_Literal];
            }
        }

        public void SetLiteral(string character)
        {
            if (String.IsNullOrEmpty(character))
                throw new ArgumentNullException("The literal can never be null or empty!!!");

            _Literal = character;
        }
    }
}