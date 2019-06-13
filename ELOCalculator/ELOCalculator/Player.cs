using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELOCalculator
{
    public class Player
    {
        public int Experience { get; private set; }

        public double Rating { get; private set; }

        public Player(double rating = 1500, int experience = 0)
        {
            Rating = rating;
            Experience = experience;
        }

        // Note - when calculating changes, you measure this *including* the just-played match's length
        public double ExperienceFactor
        {
            get
            {
                return Math.Max(1, 5 - (Experience / 100.0));
            }
        }

        public void WinAgainst(Player opponent, int matchLength)
        {
            double d = Math.Abs(Rating - opponent.Rating);
            double exponent = d * Math.Sqrt(matchLength) / 2000;
            double probUpset = 1 / (1 + Math.Pow(10, exponent));
            if (Rating <= opponent.Rating)
            {
                Experience += matchLength;
                Rating += 4 * ExperienceFactor * Math.Sqrt(matchLength) * (1 - probUpset);
            }
            else
            {
                Experience += matchLength;
                Rating += 4 * ExperienceFactor * Math.Sqrt(matchLength) * (probUpset);
            }
        }

        public void LoseAgainst(Player opponent, int matchLength)
        {
            double d = Math.Abs(Rating - opponent.Rating);
            double exponent = d * Math.Sqrt(matchLength) / 2000;
            double probUpset = 1 / (1 + Math.Pow(10, exponent));
            if (Rating <= opponent.Rating)
            {
                Experience += matchLength;
                Rating -= 4 * ExperienceFactor * Math.Sqrt(matchLength) * (probUpset);
            }
            else
            {
                Experience += matchLength;
                Rating -= 4 * ExperienceFactor * Math.Sqrt(matchLength) * (1 - probUpset);
            }
        }
    }
}
