using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefiningClasses
{
    public class Family
    {
		private List<Person> people;

        public Family()
        {
            People = new List<Person>();
        }

        public List<Person> People
		{
			get { return people; }
			set { people = value; }
		}

		public void AddMember(Person member)
		{
			People.Add(member);
		}
		public Person GetOldestMember()
		{
			int max = int.MinValue;

			foreach (Person person in People) 
			{
				if(person.Age > max)
					max = person.Age;
			}

			Person member = People.FirstOrDefault(x => x.Age == max);

			return member;
		}
	}
}
