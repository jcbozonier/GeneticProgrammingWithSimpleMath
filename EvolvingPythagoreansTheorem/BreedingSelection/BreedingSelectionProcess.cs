using System.Collections.Generic;

namespace EvolvingPythagoreansTheorem.BreedingSelection
{
    public class BreedingSelectionProcess
    {
        readonly ICanScore _FitnessTester;

        public BreedingSelectionProcess(ICanScore fitnessTester)
        {
            _FitnessTester = fitnessTester;
        }

        public IEnumerable<string> ChooseTopPercentage(IEnumerable<string> genes, double percentageToBreed)
        {
            var genesToBreed = new ScoreCards(genes, _FitnessTester).GetTop(percentageToBreed);
            return genesToBreed;
        }
    }
}
