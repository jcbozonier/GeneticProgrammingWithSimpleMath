using System;
using EvolvingPythagoreansTheorem.EnvironmentInteractions;

namespace GPRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            new GeneLifeCycle().Go((bestGene,
                          score) =>
                         {
                             Console.WriteLine("Best Gene: " + bestGene);
                             Console.WriteLine("Score: " + score);
                         });
            Console.Read();
        }
    }
}
