using NUnit.Framework;
using System;
using System.Linq;

namespace Sandbox
{
    [TestFixture]
    public class ForWhile
    {
        public string actualOwner;
        public string[] expectedOwners;

        [SetUp]
        public void Setup()
        {
            actualOwner = "C";
            expectedOwners = new string[] { "A", "B", actualOwner };
        }

        [Test]
        [Category("ForWhile")]
        public void ForTest()
        {
            for (int i = 0; !expectedOwners.Contains(actualOwner) && i < 5; i++)
            {
                Console.WriteLine(i);
            }

            CollectionAssert.Contains(expectedOwners, actualOwner);
        }


        [Test]
        [Category("ForWhile")]
        public void WhileTest()
        {
            int i = 0;
            while (!expectedOwners.Contains(actualOwner) && i < 5)
            {
                Console.WriteLine(i);
                i++;
            }

            CollectionAssert.Contains(expectedOwners, actualOwner);
        }
    }
}