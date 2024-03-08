using Handball.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handball.Models
{
    public class Team : ITeam
    {
        private string name;
        private List<IPlayer> players;

        public Team(string name)
        {
            Name = name;
            PointsEarned = 0;

            players = new List<IPlayer>();
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Team name cannot be null or empty.");
                }

                name = value;
            }

        }

        public int PointsEarned { get; private set; }

        public double OverallRating => FoundTeamReatingAverage();

        private double FoundTeamReatingAverage()
        {
            if (Players.Any())
                return Math.Round(Players.Average(p => p.Rating), 2);
            else
                return 0;
        }

        public IReadOnlyCollection<IPlayer> Players => players.AsReadOnly();

        public void Draw()
        {
            PointsEarned += 1;
            IPlayer goalKeeper = players.First(p => p.GetType().Name == nameof(Goalkeeper));
            goalKeeper.IncreaseRating();
        }

        public void Lose()
        {
            foreach (IPlayer player in players)
            {
                player.DecreaseRating();
            }
        }

        public void SignContract(IPlayer player) => players.Add(player);

        public void Win()
        {
            PointsEarned += 3;

            foreach (IPlayer player in players)
            {
                player.IncreaseRating();
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Team: {Name} Points: {PointsEarned}");
            sb.AppendLine($"--Overall rating: {OverallRating}");

            List<string> names = new();

            foreach (IPlayer player in players)
            {
                names.Add(player.Name);
            }

            if (names.Count > 0)
                sb.AppendLine($"--Players: {string.Join(", ", names)}");
            else
                sb.AppendLine($"--Players: none");

            return sb.ToString().Trim();
        }
    }
}
