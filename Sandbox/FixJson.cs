using NUnit.Framework;
using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Sandbox
{
    [TestFixture]
    public class FixJson
    {
        [Test]
        [Category("FixJson")]
        public void FixJsonTest()
        {
            string filepath = @"c:\users\jbcro\desktop\bad_json.txt";
            string text = File.ReadAllText(filepath);
            text = Regex.Replace(text, @"\s*type:\s*", "");
            text = Regex.Replace(text, @",\s*values\s*", "");
            text = Regex.Replace(text, "'", "\"");
            Console.WriteLine(text);
        }
    }
}