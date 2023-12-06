using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefiningClasses
{
    public class DateModifier
    {
		public double CalculateDifferenceInDays(string firstDate, string secondDate)
		{
			DateTime firstDateTime = DateTime.Parse(firstDate);
			DateTime secondDateTime = DateTime.Parse(secondDate);

			var difference = Math.Abs((firstDateTime - secondDateTime).TotalDays);

            return difference;
		}
	}
}
