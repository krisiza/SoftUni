using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncapsulationExercise
{
    public class Player
    {
		private string name;
		private Stats stats;

        public Player( string name,Stats stats)
        {
            Name = name;
            Stats = stats;
        }

        public Stats Stats
		{
			get => stats;

			set 
			{ 
				stats = value; 
			}
		}


		public string Name
		{
			get => name; 

			set 
			{
				if(value == null || value == string.Empty || value == " ")
				{
					throw new ArgumentException("A name should not be empty.");
				}

				name = value; 
			}
		}


	}
}
