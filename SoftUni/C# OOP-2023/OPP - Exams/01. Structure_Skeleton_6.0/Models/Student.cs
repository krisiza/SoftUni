using System;
using System.Collections.Generic;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Utilities.Messages;

namespace UniversityCompetition.Models
{
    public class Student : IStudent
    {
        private string firstname;
        private string lastname;
        private IUniversity university;
        private List<int> coveredExams;

        public Student(int studentId, string firstName, string lastName) 
        {
            Id = studentId;
            FirstName = firstName;
            LastName = lastName;

            coveredExams = new List<int>();
        }

        public int Id {get;private set;}

        public string FirstName
        {
            get => firstname;

            private set 
            {
                if(string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.NameNullOrWhitespace);
                }

                firstname = value;
            }
        }

        public string LastName
        {
            get => lastname;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.NameNullOrWhitespace);
                }

                lastname = value;
            }
        }

        public IReadOnlyCollection<int> CoveredExams => coveredExams.AsReadOnly();

        public IUniversity University => university;

        public void CoverExam(ISubject subject) => coveredExams.Add(subject.Id);

        public void JoinUniversity(IUniversity university) => this.university = university;
    }
}
