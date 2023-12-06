using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncapsulationExercise
{
    public class Dough
    {
        private string flourType;

        private string bakingTechnique;

        private double weight;
    
        public Dough(string fourType, string bakingTechnique, double weight)
        {
            FourType = fourType;
            BakingTechnique = bakingTechnique;
            Weight = weight;         
        }

        public string FourType
        {
            get => flourType;

            private set
            {
                string temp = value.ToLower();

                if (temp == "white" || temp == "wholegrain")
                {
                    flourType = value;
                }
                else
                {
                    throw new Exception("Invalid type of dough.");
                }
            }
        }

        public string BakingTechnique
        {
            get => bakingTechnique;

            private set
            {
                string temp = value.ToLower();

                if (temp == "crispy" || temp == "chewy" || temp == "homemade")
                {
                    bakingTechnique = value;
                }
                else
                {
                    throw new Exception("Invalid type of dough.");
                }
            }
        }
        public double Weight
        {
            get { return weight; }

            private set
            {
                if(value < 1 || value > 200)
                {
                    throw new Exception("Dough weight should be in the range[1..200].");
                }

                weight = value;
            }
        }

        public double DoughCalories => CalculateCalories(FourType, BakingTechnique, Weight);

        private double CalculateCalories(string flourType, string bakingTechnique, double weight)
        {
            double flourModifier = 0;
            double bakingModifier = 0;

            if (flourType.ToLower() == "white")
                flourModifier = 1.5;
            else
                flourModifier = 1;

            if (bakingTechnique.ToLower() == "crispy")
                bakingModifier = 0.9;
            else if (bakingTechnique.ToLower() == "chewy")
                bakingModifier = 1.1;
            else
                bakingModifier = 1;

            return (2 * weight) * flourModifier * bakingModifier;
        }
    }
}
