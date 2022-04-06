using NUnit.Framework;

namespace HW4_Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            CptS321.Spreadsheet_Cell spreadsheetlogic = new(1,1);
        }

        [Test]
        public void SpreadSheetLogicTest()
        {
            Assert.Pass();
            Assert.AreEqual(1,spreadsheetlogic);
        }
    }
}