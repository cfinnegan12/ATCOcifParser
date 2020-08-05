using Microsoft.VisualStudio.TestTools.UnitTesting;
using ATCOcif;

namespace ATCOcifParserTests
{
    [TestClass]
    public class JourneyTests
    {

        [TestMethod]
        public void JourneyHeaderTest()
        {
            string headerStr = "QSNMET 1117  20200704999999990000010 X2E        DDE             I";
            JourneyHeader header = new JourneyHeader(headerStr.ToCharArray());
            Assert.AreEqual(header.route, "2E", "The header route not as expected");
            Assert.AreEqual(header.direction, Direction.Inbound, "The route direction not as expected");
            operationDaysTest(header);
            Assert.AreEqual(header.bankHolidays, false);
        }

        private void operationDaysTest(JourneyHeader header)
        {
            bool[] expected = { false, false, false, false, false, true, false };
            for(int i = 0; i < 7; i++)
            {
                Assert.AreEqual(header.operationDays[i], expected[i]);
            }
        }
    }
}
