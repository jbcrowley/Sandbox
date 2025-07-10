using NUnit.Framework;
using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Sandbox
{
    [TestFixture]
    public class TimeOnlyClass
    {
        [Test]
        [Category("TimeOnly")]
        public void TimeOnlyTest()
        {

            string filepath = @"c:\users\jbcro\desktop\bad_json.txt";
            string text = File.ReadAllText(filepath);
            text = Regex.Replace(text, @"\s*type:\s*", "");
            text = Regex.Replace(text, @",\s*values\s*", "");
            text = Regex.Replace(text, "'", "\"");
            Console.WriteLine(text);
        }

        public TimeOnly BuildTimeOnly(int hours, Minutes minutes)
        {

        }

        public bool ValidateAlertTime(TimeOnly alertTime)
        {
            if (alertTime.)
        }

        private enum Minutes
        {
            Zero,
            Fifteen,
            Thirty,
            FourtyFive
        }
    }
}