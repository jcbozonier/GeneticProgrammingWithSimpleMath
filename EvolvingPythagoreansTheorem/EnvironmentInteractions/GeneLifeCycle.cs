using System.Linq;
using EvolvingPythagoreansTheorem.ProblemsToSolve.PythagoreanTheorem;

namespace EvolvingPythagoreansTheorem.EnvironmentInteractions
{
    public class GeneLifeCycle
    {
        public string Go()
        {
            var configuration = new ProblemConfiguration();
            var generationsToRunFor = 5000;
            var maxGeneSize = 50;
            var god = new GeneGod(configuration.GeneGrammar, maxGeneSize);

            var breedingSelector = new BreedingSelection.BreedingSelectionProcess(configuration.GetProblemDescription());
            var mutator = new GeneMutator(configuration.GeneGrammar, .10, maxGeneSize);
            var grotto = new GeneGrotto(maxGeneSize);

            var populationSizeToMaintain = 100;
            var population = god.CreateCountOfGenes(populationSizeToMaintain);

            var veryBestGene = "";

            foreach (var generation in 0.Until(generationsToRunFor))
            {
                population = population.Select(x => mutator.Mutate(x)).ToList();
                var bestGenes = breedingSelector.ChooseTopNPerformers(population, populationSizeToMaintain);
                veryBestGene = bestGenes.First();

                if(bestGenes.All(x=>x==veryBestGene))
                    break;

                population = grotto.GetItOn(bestGenes);
            }

            return veryBestGene;
        }
    }
}
