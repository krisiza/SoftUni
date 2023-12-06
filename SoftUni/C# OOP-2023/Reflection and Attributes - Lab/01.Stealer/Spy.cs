using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Stealer
{
    public class Spy
    {
        public string StealFieldInfo(string className, params string[] fields)
        {
            Type classType = Type.GetType(className);

            FieldInfo[] fielsInfo = classType.GetFields(BindingFlags.Instance | BindingFlags.Static
                | BindingFlags.Public | BindingFlags.NonPublic);

            StringBuilder sb = new StringBuilder();

            Object classInstance = Activator.CreateInstance(classType, new object[] { });

            sb.Append($"Class under investigation: {classInstance}");

            foreach (FieldInfo fiel in fielsInfo.Where(f => fields.Contains(f.Name)))
            {
                sb.Append($"{fiel.Name} = {fiel.GetValue(classInstance)}");
            }

            return sb.ToString().Trim();

        }
    }
}
