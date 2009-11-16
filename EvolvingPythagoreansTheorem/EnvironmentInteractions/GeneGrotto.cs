using System.Collections.Generic;
using System.Linq;

namespace EvolvingPythagoreansTheorem.EnvironmentInteractions
{
    public class GeneGrotto
    {
        public IEnumerable<string> GetItOn(IEnumerable<string> genes)
        {
            return genes.SelectMany(x => genes.Select(y => _BreedWith(x, y))).ToArray();
        }

        static string _BreedWith(string geneA, string geneB)
        {
            var newGene = "";
            for (var i = 0; i < geneA.Length; i++)
            {
                newGene += _GetChar(i, geneA) + _GetChar(i, geneB);
            }

            return newGene;
        }

        static string _GetChar(int i, string geneA)
        {
            return i >= geneA.Length
                           ? ""
                           : geneA[i].ToString();
        }
    }
}
