using NUnit.Framework;
using System;
using System.Data;
using System.Linq;
using System.Text;
using DescriptionAttribute = System.ComponentModel.DescriptionAttribute;

namespace Sandbox
{
    [TestFixture]
    public class DataTableSandbox
    {
        private static Random random = new Random();
        private const string lowerChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        private const string numbers = "0123456789";
        private const string upperChars = "abcdefghijklmnopqrstuvwxyz";

        [Test, Category("DataTable")]
        public void LoadDataTable()
        {
            System.Data.DataTable table = new System.Data.DataTable();
            table.Columns.Add("CIS", typeof(string));
            table.Columns.Add("Name", typeof(string));
            table.Columns.Add("ProductType", typeof(string));
            table.Columns.Add("Balance", typeof(double));

            for (int i = 0; i < 100; i++)
            {
                Array values = Enum.GetValues(typeof(ProductTypes));
                double balance = random.Next(0, 100000000) / 100d;
                table.Rows.Add(RandomString(numbers, 8), RandomString(lowerChars + upperChars, 8), (ProductTypes)values.GetValue(random.Next(values.Length)), balance);
            }

            StringBuilder line = new StringBuilder();
            foreach (DataRow dataRow in table.Rows)
            {
                line.Append(string.Join(",", dataRow.ItemArray) + Environment.NewLine);
            }

            Console.WriteLine(line.ToString());
        }

        public static string RandomString(string chars, int length)
        {
            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public enum ProductTypes
        {
            [Description("040")]
            Savings,
            [Description("030")]
            Checking
        }
    }
}