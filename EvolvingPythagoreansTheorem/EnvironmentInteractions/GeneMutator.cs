using System;
using System.Collections.Generic;
using System.Linq;

namespace EvolvingPythagoreansTheorem.EnvironmentInteractions
{
    public class GeneMutator
    {
        readonly string[] _GeneGrammar;
        readonly double _MutationProbability;

        public GeneMutator(IEnumerable<string> geneGrammar, double mutationProbability)
        {
            _GeneGrammar = geneGrammar.ToArray();
            _MutationProbability = mutationProbability;
        }

        public string Mutate(string gene)
        {
            var rdm = new Random(DateTime.Now.Millisecond);
            var chosenNumber = rdm.Next(1, 1000) / 1000.0;

            if (chosenNumber > _MutationProbability)
                return gene;

            var randomGrammarIndexer = new Random(DateTime.Now.Millisecond);
            var randomizedMutantGene = 0.Until(gene.Length)
                    .Select(x => _GeneGrammar[randomGrammarIndexer.Next(0, _GeneGrammar.Length)])
                    .Aggregate((x, y) => x + y);

            return _Mix(gene, randomizedMutantGene);
        }

        static string _Mix(string gene, string mutantGene)
        {
            var mutatedGene = "";
            for (var i = 0; i < gene.Length; i++)
            {
                mutatedGene += gene[i].ToString() + mutantGene[i].ToString();
            }

            return mutatedGene;
        }
    }
}