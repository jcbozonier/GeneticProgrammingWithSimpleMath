using System;
using System.Collections.Generic;
using System.Linq;
using EvolvingPythagoreansTheorem.ProblemInterfaces;

namespace EvolvingPythagoreansTheorem.EnvironmentInteractions
{
    public class GeneLifeCycle
    {
        public string Go(IGenePoolConfiguration configuration, Action<string, double> statusReport)
        {
            var probabilityOfMutation = configuration.ProbabilityOfMutation;
            var generationsToRunFor = configuration.GenerationRunCount;
            var maxGeneSize = configuration.MaximumGeneLength;
            var populationSizeToMaintain = configuration.PopulationSizeToMaintain;
            var keepTopNPerformers = configuration.KeepTheTopNPerformersEachGeneration;

            var god = new GeneGod(configuration.GeneGrammar, maxGeneSize);
            var breedingSelector = new BreedingSelection.BreedingSelectionProcess(configuration.GetProblemDescription());
            var mutator = new GeneMutator(configuration.GeneGrammar, probabilityOfMutation, maxGeneSize);
            var grotto = new GeneGrotto(maxGeneSize);

            
            var population = god.CreateCountOfGenes(populationSizeToMaintain);
            var veryBestGene = "";

            foreach (var generation in 0.Until(generationsToRunFor))
            {
                population = breedingSelector.ChooseTopNPerformers(population, keepTopNPerformers);
                veryBestGene = population.First();

                var topScore = configuration.GetProblemDescription().ScoreThis(veryBestGene);
                statusReport(veryBestGene, topScore);
                if(topScore >= configuration.StopIfScoreIsAtLeastThisHigh)
                    break;

                while(population.Count() < populationSizeToMaintain)
                {
                    population = grotto.GetItOn(population);
                    population = population.Select(x => mutator.Mutate(x));
                }

                population = _RemoveSurplusOrganisms(populationSizeToMaintain, population);

                
            }

            return veryBestGene;
        }

        static IEnumerable<string> _RemoveSurplusOrganisms(int populationSizeToMaintain,
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
