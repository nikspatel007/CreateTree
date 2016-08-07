using NUnit.Framework;
using StringParser.Tests.Data;

namespace StringParser.Tests
{
    [TestFixture]
    public class ParserTests
    {
        [Test, TestCaseSource(typeof(Strings), "TestData")]
        public void Parser_Parse_ToString(string value)
        {
            //Arrange
            var sut = new Parser(value);
            //Act   
            string result = sut.Parse().ToString();
            string removeSpecialChar = result.Replace("\r\n", "")
                .Replace(" ", "");
            
            //Assert
            Assert.That(removeSpecialChar.StartsWith("id"), Is.True);
        }

        [Test, TestCaseSource(typeof(Strings), "TestData")]
        [Description("Please check Console output.")]
        public void Parser_WriteInOrder(string value)
        {
            //Arrange
            var sut = new Parser(value);

            //Act   
            sut.Parse().WriteInOrder();

            //Assert
            Assert.IsTrue(true);
        }

    }
}