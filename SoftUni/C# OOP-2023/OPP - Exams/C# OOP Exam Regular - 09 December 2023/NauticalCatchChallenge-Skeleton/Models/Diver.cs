using NauticalCatchChallenge.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NauticalCatchChallenge.Models
{
    public abstract class Diver : IDiver
    {
        private string name;
        private int oxygenLevel;
        private List<string> catchList;
        private double competitionPoints;

        protected Diver(string name, int oxygenLevel)
        {
            Name = name;
            OxygenLevel = oxygenLevel;
            CompetitionPoints = 0;
            HasHealthIssues = false;

            catchList = new List<string>();
        }

        public string Name
        {
            get => name;
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Diver's name cannot be null or empty.");
                }

                name = value;
            }
        }
        public int OxygenLevel
        {
            //Check
            get => oxygenLevel;
            protected set
            {
                if (value <= 0)
                {
                    value = 0;
                    if (HasHealthIssues == false)
                        UpdateHealthStatus();
                }

                oxygenLevel = value;
            }
        }

        public IReadOnlyCollection<string> Catch => catchList.AsReadOnly();

        public double CompetitionPoints
        {
            //Check hier
            get => Math.Round(competitionPoints, 1);
            private set
            {
                competitionPoints = value;
            }
        }

        public bool HasHealthIssues { get; private set; }

        public void Hit(IFish fish)
        {
            OxygenLevel -= fish.TimeToCatch;
            catchList.Add(fish.Name);
            competitionPoints += fish.Points;
        }

        public abstract void Miss(int TimeToCatch);

        public abstract void RenewOxy();


        public void UpdateHealthStatus()
        {
            if (HasHealthIssues)
                HasHealthIssues = false;
            else
                HasHealthIssues = true;
        }

        public override string ToString()
            => $"Diver [ Name: {Name}, Oxygen left: {OxygenLevel}, Fish caught: {catchList.Count}, Points earned: {CompetitionPoints} ]";
    }
}
