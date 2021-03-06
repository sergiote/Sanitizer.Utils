﻿using NUnit.Framework;
using Sanitizer.Utils.Strings;

namespace Sanitizer.Utils.Tests.Strings
{
    [TestFixture]
    public class XSSSSanitizerTests
    {
        [TestCase("<img src='javascript:alert(Hack!)'", "[img src='[javascript]:alert(Hack!)'")]
        [TestCase("<script>alert('attacked')</script>", "[script]alert('attacked')[/script]")]
        [TestCase("< script>alert('attacked')</script>", "[script]alert('attacked')[/script]")]
        public void Test_Sanitize(string value, string expected)
        {
            var sanitizer = new XSSStringSanitizer();

            var result = sanitizer.Sanitize(value);

            Assert.AreEqual(expected, result);
        }
    }
}
