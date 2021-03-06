﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EvolvingPythagoreansTheorem.EnvironmentInteractions
{
    public class GeneGrotto
    {
        readonly int _MaxGeneSize;
        static Random _Randomizer = new Random(DateTime.Now.Millisecond);

        public GeneGrotto(int maxGeneSize)
        {
            _MaxGeneSize = maxGeneSize;
        }

        public IEnumerable<string> GetItOn(IEnumerable<string> genes)
        {
            return genes.SelectMany(x => genes.Select(y => _BreedWith(x, y, _MaxGeneSize)));
        }

        static string _BreedWith(string geneA,
                                 string geneB,
                                 int maxGeneSize)
        {
            var newGene = new StringBuilder();
            var geneToSwapFirst = _Randomizer.Next(0, 1);

            for (var i = 0; i < geneA.Length; i++)
            {
                if(i < geneB.Length)
                    if (i % 2 == geneToSwapFirst)
                        newGene.Append(geneA[i]);
                    else
                        newGene.Append(geneB[i]);
                else
                    newGene.Append(geneA[i]);
            }

            return _TruncateToMaxGeneSize(newGene.ToString(), maxGeneSize);
        }

        static string _TruncateToMaxGeneSize(string gene,
                                             int size)
        {
            return gene.Length <= size
                           ? gene
                           : gene.Remove(size - 1);
        }
    }
}
