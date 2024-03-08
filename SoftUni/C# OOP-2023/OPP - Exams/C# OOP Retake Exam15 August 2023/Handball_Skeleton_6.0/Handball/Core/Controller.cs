using Handball.Core.Contracts;
using Handball.Models;
using Handball.Models.Contracts;
using Handball.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Handball.Core
{
    public class Controller : IController
    {
        private TeamRepository teams;
        private PlayerRepository players;

        public Controller()
        {
            teams = new TeamRepository();
            players = new PlayerRepository();
        }
        public string LeagueStandings()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine("***League Standings***");

            foreach (ITeam team in teams.Models.OrderByDescending(t => t.PointsEarned)
                                               .ThenByDescending(t => t.OverallRating)
                                               .ThenBy(t => t.Name))
            {
                stringBuilder.AppendLine(team.ToString());
            }

            return stringBuilder.ToString().Trim();
        }

        public string NewContract(string playerName, string teamName)
        {
            IPlayer foundPlayer = players.GetModel(playerName);
            ITeam foundTeam = teams.GetModel(teamName);

            if (foundPlayer == null)
            {
                return $"Player with the name {playerName} does not exist in the {nameof(PlayerRepository)}.";
            }

            if (foundTeam == null)
            {
                return $"Team with the name {teamName} does not exist in the {nameof(TeamRepository)}.";
            }

            if (foundPlayer.Team != null)
            {
                return $"Player {playerName} has already signed with {foundPlayer.Team}.";
            }

            foundPlayer.JoinTeam(teamName);
            foundTeam.SignContract(foundPlayer);

            return $"Player {playerName} signed a contract with {teamName}.";
        }

        public string NewGame(string firstTeamName, string secondTeamName)
        {
            ITeam firstTeam = teams.GetModel(firstTeamName);
            ITeam secondTeam = teams.GetModel(secondTeamName);

            ITeam winner = null;
            ITeam loser = null;

            if (firstTeam.OverallRating > secondTeam.OverallRating)
            {
                winner = firstTeam;
                loser = secondTeam;
            }
            else if (secondTeam.OverallRating > firstTeam.OverallRating)
            {
                winner = secondTeam;
                loser = firstTeam;
            }

            if (winner != null)
            {
                winner.Win();
                loser.Lose();

                return $"Team {winner.Name} wins the game over {loser.Name}!";
            }
            else
            {
                //they are equal
                firstTeam.Draw();
                secondTeam.Draw();

                return $"The game between {firstTeamName} and {secondTeamName} ends in a draw!";
            }

        }

        public string NewPlayer(string typeName, string name)
        {
            if (typeName != nameof(Goalkeeper) && typeName != nameof(CenterBack) && typeName != nameof(ForwardWing))
            {
                return $"{typeName} is invalid position for the application.";
            }

            IPlayer foundPlayer = players.GetModel(name);

            if (foundPlayer != null)
            {
                return $"{name} is already added to the {nameof(PlayerRepository)} as {foundPlayer.GetType().Name}.";
            }

            if (typeName == nameof(Goalkeeper))
                players.AddModel(new Goalkeeper(name));
            else if (typeName == nameof(CenterBack))
                players.AddModel(new CenterBack(name));
            else
                players.AddModel(new ForwardWing(name));

            return $"{name} is filed for the handball league.";
        }

        public string NewTeam(string name)
        {
            ITeam foundTeam = teams.GetModel(name);

            if (foundTeam != null)
            {
                return $"{name} is already added to the {nameof(TeamRepository)}.";
            }

            teams.AddModel(new Team(name));
            return $"{name} is successfully added to the {nameof(TeamRepository)}.";
        }

        public string PlayerStatistics(string teamName)
        {
            ITeam foundTeam = teams.GetModel(teamName);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"***{teamName}***");

            foreach (IPlayer player in foundTeam.Players.OrderByDescending(p => p.Rating)
                                                        .ThenBy(p => p.Name))
            {
                sb.AppendLine(player.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
