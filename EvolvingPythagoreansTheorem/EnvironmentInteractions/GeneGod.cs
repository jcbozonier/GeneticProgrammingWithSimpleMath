using System;
using System.Collections.Generic;
using System.Linq;

namespace EvolvingPythagoreansTheorem.EnvironmentInteractions
{
    public class GeneGod
    {
        readonly string[] _GeneGrammar;
        readonly Random _Randomizer;

        public GeneGod(IEnumerable<string> geneGrammar)
        {
            _GeneGrammar = geneGrammar.ToArray();
            _Randomizer = new Random(DateTime.Now.Millisecond);
        }

        public IEnumerable<string> CreateCountOfGenes(int countToCreate)
        {
            return 0.Until(countToCreate).Select(x => GetRandomizedMutantGene()).ToArray();
        }

        string GetRandomizedMutantGene()
        {

            var maxGeneLength = _Randomizer.Next(3, 100);
            return 0.Until(maxGeneLength)
                    .Select(x => _GeneGrammar[_Randomizer.Next(0, _GeneGrammar.Length)])
                    .Aggregate((x, y) => x + y);
        }
    }
}
