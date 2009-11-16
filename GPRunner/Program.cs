using System;
using EvolvingPythagoreansTheorem.EnvironmentInteractions;
using EvolvingPythagoreansTheorem.ProblemsToSolve.PythagoreanTheorem;

namespace GPRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            new GeneLifeCycle()
                    .Go(new PythagoreanTheoremSolverConfiguration(),
                        (bestGene,
                         score) =>
                        {
                            Console.WriteLine("Best Gene: " + bestGene);
                            Console.WriteLine("Score: " + score);
                        });
            Console.Read();
        }
    }
}
