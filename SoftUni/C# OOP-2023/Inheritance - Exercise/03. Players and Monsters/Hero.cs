﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayersAndMonsters
{
    public class Hero
    {
        public Hero(string username, int level)
        {
            Username = username;
            Level = level;
        }

        public string Username { get; set; }

        public int Level { get; set; }

        public override string ToString() 
        {
            StringBuilder stringBuilder= new StringBuilder();

            stringBuilder.Append($"Type: {this.GetType().Name} Username: {this.Username} Level: {this.Level}");

            return stringBuilder.ToString();
        }
    }
}
