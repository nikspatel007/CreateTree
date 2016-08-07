using System.Text.RegularExpressions;
using NUnit.Framework;
using StringParser.Tests.Data;

namespace StringParser.Tests
{
    [TestFixture]
    public class ExtensionsTests
    {
        [Test, TestCaseSource(typeof(Strings), "TestData")]
        public void StringParse_ToConsole(string value)
        {
            //Arrange

            //Act   
            string result = value.ParseString();
            string removeSpecialChar = result.Replace("\r\n", "")
                .Replace(" ", "");
            //Assert
            Assert.That(removeSpecialChar.StartsWith("id") , Is.True);
        }
    }
}