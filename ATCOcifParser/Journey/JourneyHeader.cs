
namespace ATCOcif
{
    public class JourneyHeader : IRecord
    {
        public bool[] operationDays = new bool[7];
        public bool bankHolidays;
        public string route;
        public Direction direction;

        public JourneyHeader(char[] chars)
        {
            this.route = Util.charArrSubs(chars, 38, 4);
            initOperationDays(chars);
            initDirection(chars);
            this.bankHolidays = (chars[37] == 'A' || chars[37] == 'B');
        }

        private void initOperationDays(char[] chars)
        {
            for(int i = 0; i < 7; i++)
            {
                char day = chars[29+i];
                this.operationDays[i] = (day == '1');
            }
        }

        private void initDirection(char[] chars)
        {
            if (chars[64] == 'I') this.direction = Direction.Inbound;
            else this.direction = Direction.Outbound;
        }

        public override string ToString()
        {
            string result = "Route: " + this.route + "\tDirection: " + this.direction;
            result += "\nDays of Operation: " + daystostring() + "\n";
            return result;
        }
        private string daystostring()
        {
            string result = "";
            if (operationDays[0]) result += "\tMn";
            if (operationDays[1]) result += "\tTu";
            if (operationDays[2]) result += "\tWd";
            if (operationDays[3]) result += "\tTh";
            if (operationDays[4]) result += "\tFr";
            if (operationDays[5]) result += "\tSa";
            if (operationDays[6]) result += "\tSu";

            return result;
        }
    }
}
