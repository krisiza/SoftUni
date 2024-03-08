using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Xml.Linq;

namespace FootballTeam.Tests
{
    public class Tests
    {
        private List<FootballPlayer> players;
        private FootballTeam team;

        [SetUp]
        public void Setup()
        {
            //"Goalkeeper" && value != "Midfielder" && value != "Forward"
            players = new List<FootballPlayer>()
            {
                new FootballPlayer("Neymar", 13, "Goalkeeper"),
                new FootballPlayer("Messi", 5, "Goalkeeper"),
                new FootballPlayer("Ronaldo", 7, "Forward"),
                new FootballPlayer("Berbatov", 21, "Midfielder"),
                new FootballPlayer("Bojinkata", 1, "Midfielder"),
            };

            team = new FootballTeam("Barcelona", 15);
        }

        [Test]
        public void TestConst()
        {
            Assert.NotNull(team);
            Assert.That("Barcelona" == team.Name);
            Assert.That(team.Players.Count, Is.EqualTo(0));
            Assert.AreEqual(15, team.Capacity);
        }

        [TestCase(null)]
        [TestCase("")]
        public void NameCanNotBeNullOrEmpty(string name)
        {
            Assert.Throws<ArgumentException>(
                () => new FootballTeam(name, 50), "Name cannot be null or empty!");
        }

        [TestCase(0)]
        [TestCase(14)]
        [TestCase(-10)]
        public void CapacityCanNotBeLessThan15(int capacity)
        {
            Assert.Throws<ArgumentException>(
               () => new FootballTeam("Barcelona", capacity), "Capacity min value = 15");
        }

        [Test]
        public void AddPlayerWhenNoMorePositonsAreAviable()
        {
            for (int i = 0; i < 3; i++)
            {
                foreach (var player in players)
                {
                    team.AddNewPlayer(player);
                }
            }

            string test = team.AddNewPlayer(new FootballPlayer("aaa", 4, "Goalkeeper"));
            string expected = "No more positions available!";

            Assert.That(test == expected);
            Assert.AreEqual(15, team.Players.Count);
        }

        [Test]
        public void AddPlayersSuccessfully()
        {
            foreach (var player in players)
            {
                string test = team.AddNewPlayer(player);
                string expected = $"Added player {player.Name} in position {player.Position} with number {player.PlayerNumber}";

                Assert.That(test == expected);
            }

            Assert.AreEqual(players.Count, team.Players.Count);
        }

        [Test]
        public void AddOnePlayerSuccessfully()
        {
            FootballPlayer player = new FootballPlayer("aaa", 5, "Goalkeeper");
            string test = team.AddNewPlayer(player);
            string expected = $"Added player {player.Name} in position {player.Position} with number {player.PlayerNumber}";

            Assert.That(test == expected);
            Assert.AreEqual(1, team.Players.Count);
        }

        [TestCase("Ronaldo")]
        [TestCase("Neymar")]
        [TestCase("Bojinkata")]
        [TestCase("Berbatov")]
        [TestCase("Messi")]
        public void SuccessfullyPickedPlayersList(string name)
        {
            foreach (var player in players)
            {
                team.AddNewPlayer(player);     
            }

            FootballPlayer playerTest = team.PickPlayer(name);

            Assert.NotNull(playerTest);
        }

        [Test]
        public void SuccessfullyPickedOnePlayer()
        {
            FootballPlayer playe = new FootballPlayer("aaa", 5, "Goalkeeper");
            team.AddNewPlayer(playe);
            FootballPlayer playerTest = team.PickPlayer("aaa");

            Assert.NotNull(playerTest);
            Assert.That("aaa" == playerTest.Name);
        }

        [TestCase("Ronaldo")]
        [TestCase("Neymar")]
        [TestCase("Bojinkata")]
        [TestCase("Berbatov")]
        [TestCase("Messi")]
        public void PickPlayerFail(string name)
        {
            FootballPlayer playerTest = team.PickPlayer("aaa");
            Assert.IsNull(playerTest);
        }

        [Test]
        public void CheckPlayerScore()
        {
            FootballPlayer player = new FootballPlayer("aaa", 5, "Goalkeeper");
            team.AddNewPlayer(player);

            string test = team.PlayerScore(5);
            string expected = $"{player.Name} scored and now has {player.ScoredGoals} for this season!";

            Assert.That(1 == player.ScoredGoals);
            Assert.That(expected == test);
        }
    }
}