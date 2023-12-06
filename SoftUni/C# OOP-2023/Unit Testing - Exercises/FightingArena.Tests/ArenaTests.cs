namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using static System.Net.Mime.MediaTypeNames;

    [TestFixture]
    public class ArenaTests
    {
        private Warrior warrior;
        private Arena arena;

        [SetUp]
        public void SetUp()
        {
            warrior = new("warrior", 5, 50);
            arena = new();
        }

        [Test]
        public void TestConstructor()
        {
            Assert.IsNotNull(arena is not null);
            Assert.IsNotNull(arena.Warriors);
        }

        [Test]
        public void TestWarriorsCount()
        {
            Assert.AreEqual(0, arena.Warriors.Count);

            arena.Enroll(warrior);

            Assert.IsTrue(1 == arena.Warriors.Count);
        }

        [Test]
        public void EnrollWarriorSuccessfuly()
        {
            arena.Enroll(warrior);

            Assert.AreEqual(1, arena.Count);
            CollectionAssert.Contains(arena.Warriors, warrior);
        }

        [Test]
        public void EnrollManyWarriorsSuccessfuly()
        {
            List<Warrior> warriors = new() { new Warrior("warrior1", 10, 100), new Warrior("warrior2", 10, 100),
            new Warrior("warrior23", 10, 100), new Warrior("warrior3", 10, 100),
            new Warrior("warrior4", 10, 100), new Warrior("warrior5", 10, 100),
            new Warrior("warrior6", 10, 100), new Warrior("warrior7", 10, 100),
            new Warrior("warrior8", 10, 100), new Warrior("warrior9", 10, 100),};

            foreach (Warrior warrior in warriors)
            {
                arena.Enroll(warrior);
            }

            Assert.AreEqual(warriors, arena.Warriors);
        }

        [Test]
        public void EnrollAlreadyEnrolledWarrior()
        {
            arena.Enroll(warrior);

            Assert.Throws<InvalidOperationException>(
                () => { arena.Enroll(warrior); }, "Warrior is already enrolled for the fights!");
        }


        [TestCase("defender")]
        [TestCase(" ")]
        public void AttackMissingWarrior(string defenderName)
        {
            arena.Enroll(warrior);

            Assert.Throws<InvalidOperationException>(()
                =>
            { arena.Fight(warrior.Name, defenderName); }, $"There is no fighter with name {defenderName} enrolled for the fights!");
        }

        [TestCase("defender")]
        [TestCase(" ")]
        public void MissingWarriorAttacsDefender(string attackerName)
        {
            arena.Enroll(warrior);

            Assert.Throws<InvalidOperationException>(()
                =>
            { arena.Fight(attackerName, warrior.Name); }, $"There is no fighter with name {attackerName} enrolled for the fights!");
        }

        [TestCase("defender")]
        [TestCase(" ")]
        public void MissingAttackerAttacksMissingDefender(string defenderName)
        {
            Assert.Throws<InvalidOperationException>(()
                =>
            { arena.Fight(warrior.Name, defenderName); }, $"There is no fighter with name {defenderName} enrolled for the fights!");
        }

        [Test]
        public void FightIsSuccessful()
        {
            Warrior defender = new("defender", 4, 40);

            arena.Enroll(warrior);
            arena.Enroll(defender);

            int attackerHp = warrior.HP;
            int defenderHp = defender.HP;

            arena.Fight(warrior.Name, defender.Name);

            int expectedHPforAttacker = attackerHp - defender.Damage;
            int expectedHPforDefender = defenderHp - warrior.Damage;

            Assert.AreEqual(expectedHPforAttacker, warrior.HP);
            Assert.AreEqual(expectedHPforDefender, defender.HP);
        }
    }
}
