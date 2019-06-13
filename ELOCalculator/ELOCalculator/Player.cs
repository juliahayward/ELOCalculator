using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELOCalculator
{
    public class Player
    {
        public int Experience { get; }

        public double Rating { get; }

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
    }
}
