using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using UniversityCompetition.Core.Contracts;
using UniversityCompetition.Models;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories;
using UniversityCompetition.Repositories.Contracts;
using UniversityCompetition.Utilities.Messages;

namespace UniversityCompetition.Core
{
    public class Controller : IController
    {
        private IRepository<ISubject> subjects;
        private IRepository<IStudent> students;
        private IRepository<IUniversity> universities;

        public Controller()
        {
            subjects = new SubjectRepository();
            students = new StudentRepository();
            universities = new UniversityRepository();
        }

        public string AddSubject(string subjectName, string subjectType)
        {
            if (subjectType != nameof(TechnicalSubject) && subjectType != nameof(EconomicalSubject) && subjectType != nameof(HumanitySubject))
            {
                return String.Format(OutputMessages.SubjectTypeNotSupported, subjectType);
            }

            if (subjects.FindByName(subjectName) != null)
            {
                return String.Format(OutputMessages.AlreadyAddedSubject, subjectName);
            }

            int subjectID = subjects.Models.Count + 1;

            if (subjectType == nameof(TechnicalSubject))
                subjects.AddModel(new TechnicalSubject(subjectID, subjectName));
            if (subjectType == nameof(HumanitySubject))
                subjects.AddModel(new HumanitySubject(subjectID, subjectName));
            if (subjectType == nameof(EconomicalSubject))
                subjects.AddModel(new EconomicalSubject(subjectID, subjectName));

            return String.Format(OutputMessages.SubjectAddedSuccessfully, subjectType, subjectName, subjects.GetType().Name);
        }

        public string AddUniversity(string universityName, string category, int capacity, List<string> requiredSubjects)
        {
            if (universities.FindByName(universityName) != null)
            {
                return String.Format(OutputMessages.AlreadyAddedUniversity, universityName);
            }

            List<ISubject> foundSubjectIds = new();

            foreach (var repSubject in subjects.Models)
            {
                foreach (var subject in requiredSubjects)
                {
                    if (repSubject.Name == subject)
                        foundSubjectIds.Add(repSubject);
                }
            }

            List<int> requiredSubjectsInt = new List<int>();

            foreach (var s in foundSubjectIds)
            {
                requiredSubjectsInt.Add(s.Id);
            }


            int universityId = universities.Models.Count + 1;
            universities.AddModel(new University(universityId, universityName, category, capacity, requiredSubjectsInt));


            return String.Format(OutputMessages.UniversityAddedSuccessfully, universityName, universities.GetType().Name);
        }

        public string AddStudent(string firstName, string lastName)
        {
            string name = firstName + " " + lastName;
            if (students.FindByName(name) != null)
            {
                return String.Format(OutputMessages.AlreadyAddedStudent, firstName, lastName);
            }

            int studentId = students.Models.Count() + 1;
            students.AddModel(new Student(studentId, firstName, lastName));

            return String.Format(OutputMessages.StudentAddedSuccessfully, firstName, lastName, students.GetType().Name);
        }


        public string TakeExam(int studentId, int subjectId)
        {
            IStudent student = students.FindById(studentId);
            ISubject subject = subjects.FindById(subjectId);

            if (student == null)
            {
                return String.Format(OutputMessages.InvalidStudentId);
            }
            else if (subject == null)
            {
                return String.Format(OutputMessages.InvalidSubjectId);
            }
            else
            {
                var exam = student.CoveredExams.FirstOrDefault(e => e == subjectId);

                if (exam != default)
                {
                    return String.Format(OutputMessages.StudentAlreadyCoveredThatExam, student.FirstName, student.LastName, subject.Name);
                }
                else
                {
                    student.CoverExam(subject);
                    return String.Format(OutputMessages.StudentSuccessfullyCoveredExam, student.FirstName, student.LastName, subject.Name);
                }
            }
        }

        public string ApplyToUniversity(string studentName, string universityName)
        {
            IStudent student = students.FindByName(studentName);
            IUniversity university = universities.FindByName(universityName);

            string[] names = studentName.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (student == null)
            {
                return String.Format(OutputMessages.StudentNotRegitered, names[0], names[1]);
            }
            else if (university == null)
            {
                return String.Format(OutputMessages.UniversityNotRegitered, universityName);
            }

            bool hasAll = university.RequiredSubjects.All(itm2 => student.CoveredExams.Contains(itm2));

            if (!hasAll)
            {
                return String.Format(OutputMessages.StudentHasToCoverExams, studentName, universityName);
            }

            if (student.University != null && student.University.Name == universityName)
            {
                return String.Format(OutputMessages.StudentAlreadyJoined, names[0], names[1], universityName);
            }

                student.JoinUniversity(university);
                return String.Format(OutputMessages.StudentSuccessfullyJoined, names[0], names[1], universityName);         
        }

        public string UniversityReport(int universityId)
        {
            IUniversity university = universities.FindById(universityId);
            if (university != null)
            {
                StringBuilder stringBuilder = new StringBuilder();

                stringBuilder.AppendLine($"*** {university.Name} ***");
                stringBuilder.AppendLine($"Profile: {university.Category}");

                List<IStudent> students = this.students.Models
                    .Where(s => s.University == university)
                    .ToList();

                stringBuilder.AppendLine($"Students admitted: {students.Count}");
                stringBuilder.AppendLine($"University vacancy: {university.Capacity - students.Count}");

                return stringBuilder.ToString().Trim();
            }

            return null;
        }
    }
}
