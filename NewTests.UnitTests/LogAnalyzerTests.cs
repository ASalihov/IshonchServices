using System;
using System;
using System.Collections.Specialized;
using NUnit.Framework;
using NUnit.Framework.Internal;


namespace NewTests.UnitTests
{
    [TestFixture]
    public class LogAnalyzerTests
    {
        private LogAnalyzer MakeAnalizer()
        {
            return new LogAnalyzer();
        }

        [Category("simple")]
        [TestCase(".SLF", true)]
        [Category("simple")]
        [TestCase(".fuckOff", false)]
        public void IsValidLogFileName_BadAndGoodExtention_ReturnsTrueOrFalse(string fileExtention, bool expected)
        {
            var logAnalizer = MakeAnalizer();
            bool res = logAnalizer.IsValidLogFileName(fileExtention);
            var a = string.Empty;
            Assert.AreEqual(expected, res);
        }

        [Category("fuckoff")]
        //[Ignore("fuck off from this test!")]
        [Test]
        public void IsValidLogFileName_EmptyExtention_ThrowsException()
        {
            var la = MakeAnalizer();
            var ex = Assert.Catch<Exception>(() => la.IsValidLogFileName(string.Empty));
            StringAssert.Contains("file name cannot be empty string", ex.Message);
        }

        [TestCase("fuck.SLF", true)]
        [TestCase("fuck.slf", true)]
        public void IsValidLogFileName_GoodExtention_WasLastFileNameValidIsTrue(string fn, bool exp)
        {
            var la = MakeAnalizer();
            la.IsValidLogFileName(".SLF");
        
            Assert.AreEqual(exp, la.WasLastFileNameValid);
        }
    }
}
