﻿namespace UniversityCompetition.Models
{
    public class TechnicalSubject : Subject
    {
        private const double subjectRate = 1.3;
        public TechnicalSubject(int id, string name) 
            : base(id, name, subjectRate)
        {
        }
    }
}
