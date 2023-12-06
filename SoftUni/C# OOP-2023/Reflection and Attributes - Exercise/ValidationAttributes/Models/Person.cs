
using ValidationAttributes.Attributes;

namespace ValidationAttributes.Models
{
    public class Person
    {
        private const int MinAge = 12;
        private const int MaxAge = 90;
        public Person(string fullname, int age)
        {
            FullName = fullname;
            Age = age;
        }

        [MyRequired]
        public string FullName { get; set; }

        [MyRange(MinAge, MaxAge)]
        public int Age { get; set; }
    }
}
