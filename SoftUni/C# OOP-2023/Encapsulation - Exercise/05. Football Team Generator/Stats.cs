using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncapsulationExercise
{
    public class Stats
    {
        private int endurance;

        private int sprint;

        private int dribble;

        private int passing;

        private int shooting;

        public Stats(int endurance, int sprint, int dribble, int passing, int shooting)
        {
            Endurance = endurance;
            Sprint = sprint;
            Dribble = dribble;
            Passing = passing;
            Shooting = shooting;
        }

        private int Endurance
        {
            get => endurance; 
            set 
            { 
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException($"Endurance should be between 0 and 100.");
                }

                endurance = value; 
            }
        }

        private int Sprint
        {
            get => sprint;

            set 
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException($"Sprint should be between 0 and 100.");
                }

                sprint = value; 
            }
        }

        private int Dribble
        {
            get => dribble;

            set 
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException($"Dribble should be between 0 and 100.");
                }

                dribble = value; 
            }
        }

        private int Passing
        {
            get => passing; 

            set 
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException($"Passing should be between 0 and 100.");
                }

                passing = value; 
            }
        }

        private int Shooting
        {
            get => shooting; 

            set 
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException($"Shooting should be between 0 and 100.");
                }

                shooting = value; 
            }
        }

        public double SkillLevel => CalculateSkillLevel(Endurance, Sprint, Dribble, Passing, Shooting);

        private double CalculateSkillLevel(int endcureance, int sprint, int dribble, int passing, int shooting)
        {
            List<int> skillLevels = new List<int> { endcureance, sprint, dribble, passing, shooting };

            return skillLevels.Average();
        }

    }
}
