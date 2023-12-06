namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class WarriorTests
    {
        private Warrior warrior;

        [SetUp]
        public void SetUp()
        {
            warrior = new("warrior", 5, 50);
        }

        [Test]
        public void TestWarriorConstructor()
        {
            string expectedName = "warrior";
            int expectedDemage = 5;
            int expectedHP = 50;


            Assert.IsTrue(warrior is not null);
            Assert.AreEqual(expectedName, warrior.Name);
            Assert.AreEqual(expectedDemage, warrior.Damage);
            Assert.AreEqual(expectedHP, warrior.HP);
        }

        [TestCase(" ")]
        [TestCase("         ")]
        [TestCase("")]
        [TestCase(null)]
        public void NameIsNullOrWhiteSpace(string name)
        {
            Assert.Throws<ArgumentException>(
                () => { warrior = new(name, 5, 50); }, "Name should not be empty or whitespace!");
        }


        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-20)]
        public void DamageWithZeroOrNegativeNumber(int damage)
        {
            Assert.Throws<ArgumentException>(
                () => { warrior = new("warrior", damage, 50); }, "Damage value should be positive!");
        }

        [TestCase(-1)]
        [TestCase(-20)]
        public void HPWithNegativeNumber(int hp)
        {
            Assert.Throws<ArgumentException>(
                () => { warrior = new("warrior", 5, hp); }, "HP should not be negative!");
        }


        [TestCase(10)]
        [TestCase(29)]
        [TestCase(30)]
        public void AttackWithHPBelow30(int hp)
        {
           Warrior testWarrior = new("warrior", 5, hp);

            Assert.Throws<InvalidOperationException>(
                () => { testWarrior.Attack(warrior); }, "Your HP is too low in order to attack other warriors!");
        }

        [TestCase(10)]
        [TestCase(29)]
        [TestCase(30)]
        public void AttackWarriorWithHPBelow30(int hp)
        {
            Warrior testWarrior = new("warrior", 5, hp);

            Assert.Throws<InvalidOperationException>(
                () => { warrior.Attack(testWarrior); }, "Enemy HP must be greater than 30 in order to attack him!");
        }

        [Test]
        public void AttackStrongerWarrior()
        {
            Warrior warriorToAttack = new("warrior", 5, 35);
            Warrior strongerWarrior = new("strongerWarrior", 36, 100);

            Assert.Throws<InvalidOperationException>(
                () => {warriorToAttack.Attack(strongerWarrior); }, "You are trying to attack too strong enemy");
        }

        [TestCase(3)]
        [TestCase(1)]
        [TestCase(20)]
        [TestCase(15)]
        public void SuccessfulAttack(int demage)
        {
            Warrior testWarrior = new("warrior", demage, 100);

            int attackeWarriorHp = warrior.HP;
            int testWarriorHp = testWarrior.HP;

            testWarrior.Attack(warrior);

            int expectedHPforAttackedWarrior = attackeWarriorHp - demage;
            int expectedHPforTestWarrior = testWarriorHp - warrior.Damage;

            Assert.AreEqual(expectedHPforAttackedWarrior, warrior.HP);
            Assert.AreEqual(expectedHPforTestWarrior, testWarrior.HP);
        }

        [Test]
        public void SuccessfulAttackKillsWarrior()
        {
            Warrior attacker = new("testWarrior", 51, 100);

            attacker.Attack(warrior);

            Assert.AreEqual(0, warrior.HP);
            Assert.AreEqual(95, attacker.HP);
        }
    }
}