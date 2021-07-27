using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Sandbox
{
    class RegexValidation
    {
        [Test]
        public void Main()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            // build your list of regex string, ideally reading them in from a file or getting them from a db
            List<string> regexList = new List<string>();
            regexList.Add(@"(\d{1,2}) December (\d{4})");
            for (int i = 0; i < 200; i++)
            {
                regexList.Add(@"(\d{1,2}) April (\d{4})");
            }

            // if you aren't going to maintain a clean list, clean it now before we start testing
            List<string> cleanRegexList = CleanRegexList(regexList);

            string checkString = "1 December 2020";
            // string checkString = "15 April 2020";

            List<string> results = FindMatchRegex(checkString, cleanRegexList);
            stopwatch.Stop();

            foreach (string result in results)
            {
                Console.WriteLine(checkString + " found to match " + result);
            }

            Console.WriteLine("Time elapsed: " + stopwatch.Elapsed);
        }

        private static List<string> FindMatchRegex(string checkString, List<string> regexList)
        {
            List<string> matchingRegexes = new List<string>();
            foreach (string regexString in regexList)
            {
                Regex regex = new Regex(regexString);
                if (regex.IsMatch(checkString))
                {
                    matchingRegexes.Add(regexString);
                }
            }

            return matchingRegexes;
        }

        private static List<string> CleanRegexList(List<string> regexList)
        {
            List<string> cleanRegexes = new List<string>();
            foreach (string regexString in regexList)
            {
                if (IsValidRegex(regexString))
                {
                    cleanRegexes.Add(regexString);
                }
            }

            return cleanRegexes;
        }

        private static bool IsValidRegex(string regexString)
        {
            if (string.IsNullOrWhiteSpace(regexString))
            {
                return false;
            }

            try
            {
                Regex.Match("", regexString);
            }
            catch (ArgumentException)
            {
                return false;
            }

            return true;
        }
    }
}