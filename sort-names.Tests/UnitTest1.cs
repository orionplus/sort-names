using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
//using System.IO;

namespace sort_names.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void InputFileExists()
        {
            SortService service = new SortService(@"C:\names.txt");
            Assert.IsTrue(service.IsInputFileExists());
        }
        [TestMethod]
        public void InputFileIsNotEmpty()
        {
            SortService service = new SortService(@"C:\names.txt");
            Assert.IsTrue(service.IsInputFileNotEmpty());
        }
        [TestMethod]
        public void IsFileFormatted()
        {
            SortService service = new SortService(@"C:\names.txt");
            Assert.IsTrue(service.IsInputFileProperlyFormatted());
        }
    }
}
