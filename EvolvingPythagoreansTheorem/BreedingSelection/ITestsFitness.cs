using System.Collections.Generic;

namespace EvolvingPythagoreansTheorem.BreedingSelection
{
    public interface ITestsFitness
    {
        ScoreCards ScoreThese(IEnumerable<string> genomes);
    }
}
