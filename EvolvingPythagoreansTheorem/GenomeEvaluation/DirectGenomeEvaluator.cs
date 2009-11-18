using System;
using System.Collections.Generic;

namespace EvolvingPythagoreansTheorem.GenomeEvaluation
{
    public class DirectGenomeEvaluator : IEvaluatable
    {
        readonly string _Genome;

        public DirectGenomeEvaluator(string gene)
        {
            _Genome = gene;
        }

        public int GetGeneLength()
        {
            return _Genome.Length;
        }

        public double Evaluate(IDictionary<string, double> variableList)
        {
            var operandQueue = new Queue<double>();

            var indexValidAt = _GetIndexToCalculateTo(_Genome);

            if (indexValidAt < 0)
                return double.NaN;

            for (var i = indexValidAt; i >= 0; i--)
            {
                var theCharacter = _Genome[i];
                if (!_IsOperator(theCharacter))
                    operandQueue.Enqueue(variableList[theCharacter.ToString()]);
                else
                {
                    if(_GetNumberOfChildrenFor(theCharacter) > operandQueue.Count)
                        return double.NaN;
                    switch (theCharacter)
                    {
                        case '*':
                            operandQueue.Enqueue(operandQueue.Dequeue() * operandQueue.Dequeue());
                            break;
                        case '/':
                            operandQueue.Enqueue(operandQueue.Dequeue() / operandQueue.Dequeue());
                            break;
                        case '-':
                            operandQueue.Enqueue(operandQueue.Dequeue() - operandQueue.Dequeue());
                            break;
                        case '+':
                            operandQueue.Enqueue(operandQueue.Dequeue() + operandQueue.Dequeue());
                            break;
                        case 'r':
                            operandQueue.Enqueue(Math.Sqrt(operandQueue.Dequeue()));
                            break;
                        default:
                            throw new NotImplementedException("This is NOT an operator!!! '" + theCharacter + "'");
                    }

                }

            }
            
            return operandQueue.Dequeue();
        }

        public int GetOperableGeneLength()
        {
            return _GetIndexToCalculateTo(_Genome) + 1;
        }

        static int _GetIndexToCalculateTo(string genome) {
            var genomeLength = genome.Length;
            var indexValidAt = genomeLength - 1;
            var currentScore = 1;
            for (var i = 0; i < genomeLength; i++ )
            {
                var theCharacter = genome[i];
                currentScore += _GetNumberOfChildrenFor(theCharacter) - 1;

                if(currentScore == 0)
                {
                    indexValidAt = i;
                    break;
                }
            }
            return indexValidAt;
        }

        static int _GetNumberOfChildrenFor(char symbol)
        {
            switch (symbol)
            {
                case '*':
                case '/':
                case '+':
                case '-':
                    return 2;
                case 'r':
                    return 1;
                default:
                    return 0;
            }
        }

        static bool _IsOperator(char character)
        {
            return character == '+' ||
                   character == '-' ||
                   character == '*' ||
                   character == '/' ||
                   character == 'r';
        }
    }
}
