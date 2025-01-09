﻿using Homies.Data;
using Microsoft.AspNetCore.Identity;

namespace Homies.Models
{
    public class EventInfoViewModel
    {
        public EventInfoViewModel(int id, string name, DateTime start, string type, string organiser)
        {
            Id = id;
            Name = name;
            Type = type;
            Organiser = organiser;
            Start = start.ToString(DataConstants.EventCreatedOnFormat);
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public string Start { get; set; }

        public string Type { get; set; }

        public string Organiser { get; set; }
    }
}
