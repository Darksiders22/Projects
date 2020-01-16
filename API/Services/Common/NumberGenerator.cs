using Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Services.Common
{
    class NumberGenerator
    {
        private static string wordKey = "AWS";
        private static string lastEmployeeNumber = "";

        public static string EmployeeNumberGenerator(StoreDbContext db)
        {

            var getLastEmpNumber = db.Employees.Select(x => x.EmployeeNumber).OrderByDescending(x => x).FirstOrDefault();
            if (getLastEmpNumber == null)
            {
                lastEmployeeNumber = "0";
            }
            Regex regex = new Regex(@"[\d]+");
            lastEmployeeNumber = regex.Match(lastEmployeeNumber).Value;

            return EmployeeGenerator();

        }
        private static string EmployeeGenerator()
        {
            var number = int.Parse(lastEmployeeNumber);
            number++;

            StringBuilder sb = new StringBuilder();

            sb.Append(string.Format("{0}{1,0}", wordKey, number.ToString("D8")));

            return sb.ToString();
        }
    }
}
