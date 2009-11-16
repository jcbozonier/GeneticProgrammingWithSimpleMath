using System;
using System.Collections.Generic;
using System.Linq;

namespace EvolvingPythagoreansTheorem.EnvironmentInteractions
{
    public class GeneGrotto
    {
        readonly int _MaxGeneSize;

        public GeneGrotto(int maxGeneSize)
        {
            _MaxGeneSize = maxGeneSize;
        }

        public IEnumerable<string> GetItOn(IEnumerable<string> genes)
        {
            return genes.SelectMany(x => genes.Select(y => _BreedWith(x, y, _MaxGeneSize))).ToArray();
        }

        static string _BreedWith(string geneA,
                                 string geneB,
                                 int maxGeneSize)
        {
            var newGene = "";
            for (var i = 0; i < geneA.Length; i++)
            {
                newGene += _GetChar(i, geneA) + _GetChar(i, geneB);
            }

            return _TruncateToMaxGeneSize(newGene, maxGeneSize);
        }

        static string _TruncateToMaxGeneSize(string gene,
                                             int size)
        {
            return gene.Length <= size
                           ? gene
                           : gene.Remove(size - 1);
        }

        static string _GetChar(int i, string geneA)
        {
            return i >= geneA.Length
                           ? ""
                           : geneA[i].ToString();
        }
    }
}
