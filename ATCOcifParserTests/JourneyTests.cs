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
            Assert.AreEqual(header.Route, "2E", "The header route not as expected");
            Assert.AreEqual(header.Direction, Direction.Inbound, "The route direction not as expected");
            operationDaysTest(header);
            Assert.AreEqual(header.BankHolidays, false);
        }

        private void operationDaysTest(JourneyHeader header)
        {
            bool[] expected = { false, false, false, false, false, true, false };
            for(int i = 0; i < 7; i++)
            {
                Assert.AreEqual(header.OperationDays[i], expected[i]);
            }
        }

        [TestMethod]
        public void originTest()
        {
            string originStr = "QO7000000153640720UQST1";
            OriginRecord origin = new OriginRecord(originStr.ToCharArray());
            Assert.AreEqual(origin.Time, "0720");
            Assert.AreEqual(origin.Location, "700000015364");
        }

        [TestMethod]
        public void destinationTest()
        {
            string destStr = "QT7000000015830753   T1  ";
            DestinationRecord dest = new DestinationRecord(destStr.ToCharArray());
            Assert.AreEqual(dest.Time, "0753");
            Assert.AreEqual(dest.Location, "700000001583");
        }

        [TestMethod]
        public void intermediateTest()
        {
            string intStr = "QI70000000120507400740B   T1  ";
            IntermediateRecord intermediate = new IntermediateRecord(intStr.ToCharArray());
            Assert.AreEqual(intermediate.Time, "0740");
            Assert.AreEqual(intermediate.Location, "700000001205");
            Assert.AreEqual(intermediate.Activity, 'B');
        }

    }
}
