using System.Collections.Generic;

namespace EvolvingPythagoreansTheorem.BreedingSelection
{
    public class BreedingSelectionProcess
    {
        readonly ITestsFitness _FitnessTester;

        public BreedingSelectionProcess(ITestsFitness fitnessTester)
        {
            _FitnessTester = fitnessTester;
        }

        public IEnumerable<string> ChooseTopPercentage(IEnumerable<string> genes, double percentageToBreed)
        {
            var genesToBreed = _FitnessTester.ScoreThese(genes).GetTop(percentageToBreed);
            return genesToBreed;
        }
    }
}
