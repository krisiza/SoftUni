using System;
using System.Collections.Generic;
using System.Linq;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories.Contracts;

namespace UniversityCompetition.Repositories
{
    public class StudentRepository : IRepository<IStudent>
    {
        private List<IStudent> students = new List<IStudent>();
        public IReadOnlyCollection<IStudent> Models => students.AsReadOnly();

        public void AddModel(IStudent model) => students.Add(model);

        public IStudent FindById(int id) => students.FirstOrDefault(s => s.Id == id);

        public IStudent FindByName(string name)
        {
            string[] names = name.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            return students.FirstOrDefault(s => s.FirstName == names[0] && s.LastName == names[1]);
        }
    }
}
