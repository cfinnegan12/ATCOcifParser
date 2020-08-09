
using System.Dynamic;

namespace ATCOcif
{
    public class JourneyHeader : IRecord
    {
        public bool[] OperationDays{ get; }
        public bool BankHolidays { get; }
        public string Route { get; }
        public Direction Direction { get; }

        public JourneyHeader(char[] chars)
        {
            this.Route = Util.charArrSubs(chars, 38, 4);
            this.OperationDays = new bool[7];
            initOperationDays(chars);
            this.Direction = (chars[64] == 'I') ? Direction.Inbound : Direction.Outbound;
            this.BankHolidays = (chars[37] == 'A' || chars[37] == 'B');
        }

        private void initOperationDays(char[] chars)
        {
            for(int i = 0; i < 7; i++)
            {
                char day = chars[29+i];
                this.OperationDays[i] = (day == '1');
            }
        }

        public override string ToString()
        {
            string result = "Route: " + this.Route + "\tDirection: " + this.Direction;
            result += "\nDays of Operation: " + daystostring() + "\n";
            return result;
        }
        private string daystostring()
        {
            string result = "";
            if (OperationDays[0]) result += "\tMn";
            if (OperationDays[1]) result += "\tTu";
            if (OperationDays[2]) result += "\tWd";
            if (OperationDays[3]) result += "\tTh";
            if (OperationDays[4]) result += "\tFr";
            if (OperationDays[5]) result += "\tSa";
            if (OperationDays[6]) result += "\tSu";

            return result;
        }
    }
}
