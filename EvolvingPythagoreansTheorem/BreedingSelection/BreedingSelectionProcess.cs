using System.Collections.Generic;
using EvolvingPythagoreansTheorem.ProblemInterfaces;

namespace EvolvingPythagoreansTheorem.BreedingSelection
{
    public class BreedingSelectionProcess
    {
        readonly ICanScore _FitnessTester;

        public BreedingSelectionProcess(ICanScore fitnessTester)
        {
            _FitnessTester = fitnessTester;
        }

        public IEnumerable<string> ChooseTopNPerformers(IEnumerable<string> genes, int numberToKeep)
        {
            var genesToBreed = new ScoreCards(genes, _FitnessTester).GetTop(numberToKeep);
            return genesToBreed;
        }
    }
}
