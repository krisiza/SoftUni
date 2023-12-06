using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncapsulationExercise
{
    public class Team
    {
        private string name;

        private int rating;

        private List<Player> players;

        public Team(string name)
        {
            Name = name;
            players = new List<Player>();
        }

        public string Name
        {
            get => name;

            set
            {
                if (value == null || value == string.Empty || value == " ")
                {
                    throw new ArgumentNullException("A name should not be empty.");
                }

                name = value;
            }
        }

        public List<Player> Players => players;

        public int Rating => (int)Math.Round(players.Average(x => x.Stats.SkillLevel));

        public void AddPlayer(Player player)
        {
            players.Add(player);
        }

        public void RemovePlayer(Player player)
        {
            players.Remove(player);
        }
    }
}
