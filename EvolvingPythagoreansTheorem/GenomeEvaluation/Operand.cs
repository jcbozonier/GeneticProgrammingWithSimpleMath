using System;
using System.Collections.Generic;

namespace EvolvingPythagoreansTheorem.GenomeEvaluation
{
    public enum Operators
    {
        Plus, Minus, Multiply, Divide, Sqrt, Operand, None
    }

    public class Operand : IExpression
    {
        readonly List<IExpression> _Operands;
        Operators _Operator = Operators.None;
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
            switch (_Operator)
            {
                case Operators.Plus:
                    return _Operands[0].Evaluate(variableList) + _Operands[1].Evaluate(variableList);
                case Operators.Minus:
                    return _Operands[0].Evaluate(variableList) - _Operands[1].Evaluate(variableList);
                case Operators.Multiply:
                    return _Operands[0].Evaluate(variableList) * _Operands[1].Evaluate(variableList);
                case Operators.Divide:
                    return _Operands[0].Evaluate(variableList) / _Operands[1].Evaluate(variableList);
                case Operators.Sqrt:
                    return Math.Sqrt(_Operands[0].Evaluate(variableList));
                default:
                    return _Operator != Operators.None ? variableList[_Literal] : 0.0;
            }
        }

        public int GetOperableGeneLength()
        {
            throw new NotImplementedException();
        }

        public void SetLiteral(string character)
        {
            if (String.IsNullOrEmpty(character))
                throw new ArgumentNullException("The literal can never be null or empty!!!");

            _Literal = character;
        }

        public void SetOperator(Operators theOperator)
        {
            _Operator = theOperator;
        }
    }
}