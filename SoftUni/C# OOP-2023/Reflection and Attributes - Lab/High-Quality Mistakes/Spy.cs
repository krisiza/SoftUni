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

        public string AnalyzeAccessModifiers(string className)
        {
            Type classType = Type.GetType(className);

            FieldInfo[] fieldInfos = classType.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);

            MethodInfo[] classPublicMethods = classType.GetMethods(BindingFlags.Public | BindingFlags.Instance);

            MethodInfo[] classNonPublicMethods = classType.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);

            StringBuilder stringBuilder = new StringBuilder();


            foreach(var fiel in fieldInfos) 
            {
                stringBuilder.AppendLine($"{fiel.Name} must be private!");
            }

            foreach(var property in classPublicMethods.Where(m => m.Name.StartsWith("get"))) 
            {
                stringBuilder.AppendLine($"{property.Name} have to be public!");
            }

            foreach(var property in classPublicMethods.Where(m => m.Name.StartsWith("set")))
            {
                stringBuilder.AppendLine($"{property.Name} have to be private!");
            }

            return stringBuilder.ToString().Trim();
        }
    }
}
