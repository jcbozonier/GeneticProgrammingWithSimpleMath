using System;
using System.Collections.Generic;
using System.Linq;
using EvolvingPythagoreansTheorem.ProblemsToSolve.PythagoreanTheorem;

namespace EvolvingPythagoreansTheorem.EnvironmentInteractions
{
    public class GeneLifeCycle
    {
        public string Go(Action<string, double> statusReport)
        {
            var configuration = new ProblemConfiguration();
            var generationsToRunFor = 1000;
            var maxGeneSize = 25;
            var god = new GeneGod(configuration.GeneGrammar, maxGeneSize);

            var breedingSelector = new BreedingSelection.BreedingSelectionProcess(configuration.GetProblemDescription());
            var mutator = new GeneMutator(configuration.GeneGrammar, .20, maxGeneSize);
            var grotto = new GeneGrotto(maxGeneSize);

            var populationSizeToMaintain = 500;
            var population = god.CreateCountOfGenes(populationSizeToMaintain);

            var veryBestGene = "";

            foreach (var generation in 0.Until(generationsToRunFor))
            {
                var bestGenes = breedingSelector.ChooseTopNPerformers(population, 10);
                veryBestGene = bestGenes.First();

                statusReport(veryBestGene,
                             configuration.GetProblemDescription().ScoreThis(veryBestGene));

                population = bestGenes;

                while(population.Count() < populationSizeToMaintain)
                {
                    population = grotto.GetItOn(population);
                    population = population.Select(x => mutator.Mutate(x));
                }
                population = _RemoveSurplusOrganisms(populationSizeToMaintain, population);

                if(population.All(x=>x == veryBestGene))
                    break;
            }

            return veryBestGene;
        }

        IEnumerable<string> _RemoveSurplusOrganisms(int populationSizeToMaintain,
                                            IEnumerable<string> population) {
            if(population.Count() > populationSizeToMaintain)
            {
                var populace = population.ToList();
                var numberToRemove = populace.Count - populationSizeToMaintain;
                var indexDistance = populace.Count/numberToRemove;
                var indicesToRemove = 0.Until(numberToRemove).Select(x => x*indexDistance);
                indicesToRemove.Reverse().ForEach(populace.RemoveAt);

                population = populace;
            }
            return population;
                                            }
    }
}
