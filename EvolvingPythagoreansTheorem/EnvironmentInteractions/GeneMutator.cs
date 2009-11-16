using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EvolvingPythagoreansTheorem.EnvironmentInteractions
{
    public class GeneMutator
    {
        static Random _Randomizer = new Random(DateTime.Now.Millisecond);
        readonly string[] _GeneGrammar;
        readonly double _MutationProbability;
        int _MaxGeneSize;

        public GeneMutator(IEnumerable<string> geneGrammar,
                           double mutationProbability,
                           int size)
        {
            _GeneGrammar = geneGrammar.ToArray();
            _MutationProbability = mutationProbability;
            _MaxGeneSize = size;
        }

        public string Mutate(string gene)
        {
            if (!_ShouldMutate())
                return gene;

            var randomGrammarIndexer = new Random(DateTime.Now.Millisecond);
            var randomizedMutantGene = 0.Until(gene.Length)
                    .Select(x => _GeneGrammar[randomGrammarIndexer.Next(0, _GeneGrammar.Length)])
                    .Aggregate((x, y) => x + y);

            return _Mix(gene, randomizedMutantGene);
        }

        string _Mix(string gene, string mutantGene)
        {
            var mutatedGene = new StringBuilder();
            for (var i = 0; i < gene.Length; i++)
            {
                if(_ShouldMutate())
                    mutatedGene.Append(mutantGene[i]);
                else
                    mutatedGene.Append(gene[i]);
            }

            return _ShouldMutate()
                           ? mutatedGene.ToString()
                           : mutatedGene.ToString() + mutatedGene;
        }

        bool _ShouldMutate()
        {
            var rdm = _Randomizer;
            var chosenNumber = rdm.Next(1, 1000) / 1000.0;

            return chosenNumber <= _MutationProbability;
        }
    }
}