using System;

namespace EvolvingPythagoreansTheorem.FitnessTesting
{
    public class ScoreCard : IComparable
    {
        public double Score { get; private set; }
        public string Genome { get; private set; }

        public ScoreCard(string genome,
                     double genomeScore)
        {
            Genome = genome;
            Score = genomeScore;
        }

        public int CompareTo(object obj)
        {
            var typedObj = obj as ScoreCard;
            if (typedObj == null)
                throw new ArgumentException("Must be a score card!");

            return Score.CompareTo(typedObj.Score);
        }
    }
}
