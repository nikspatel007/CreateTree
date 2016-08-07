using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;

namespace StringParser.Tests.Data
{
    public static class Strings
    {
        public static IEnumerable TestData
        {
            get
            {
                yield return new TestCaseData("id");
                yield return new TestCaseData("id,created,employee(id,firstname,employeeType(id), lastname),location");
                yield return new TestCaseData("(id)");
                yield return new TestCaseData("(id, created)");
                yield return new TestCaseData("(id , created,employee(id))");
                yield return new TestCaseData("(id , created,employee(id,employeeType(id)))");
                yield return new TestCaseData("(id,created,employee(id,firstname,employeeType(id), lastname),location)");

            }
        }
    }
}