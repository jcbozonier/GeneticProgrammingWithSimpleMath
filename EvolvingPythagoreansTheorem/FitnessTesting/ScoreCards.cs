using System.Collections.Generic;
using System.Linq;

namespace EvolvingPythagoreansTheorem.FitnessTesting
{
    public class ScoreCards
    {
        readonly IEnumerable<ScoreCard> _Scores;

        public ScoreCards(IEnumerable<ScoreCard> scores)
        {
            _Scores = scores.ToArray();
        }

        public string GetBestGene()
        {
            return _Scores.Max(x => x).Genome;
        }
    }
}
