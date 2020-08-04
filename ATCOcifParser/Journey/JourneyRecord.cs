using System.Collections.Generic;


namespace ATCOcif
{
    public class JourneyRecord : IRecord
    {
        public JourneyHeader journeyHeader;
        public OriginRecord journeyOrigin;
        public List<IntermediateRecord> intermediateRecords;
        public DestinationRecord journeyDestination;
        //public JourneyDataRunningRecord journeyDataRunningRecord;
        //public JourneyNoteRecord journeyNoteRecord;



        public JourneyRecord(char[] header)
        {
            this.journeyHeader = new JourneyHeader(header);
            this.intermediateRecords = new List<IntermediateRecord>();
        }

        public void setOriginRecord(char[] origin)
        {
            this.journeyOrigin = new OriginRecord(origin);
        }

        public void addIntermediateRecord(char[] chars)
        {
            this.intermediateRecords.Add(new IntermediateRecord(chars));
        }

        public void setDestinationRecord(char[] chars)
        {
            this.journeyDestination= new DestinationRecord(chars);
        }

        public override string ToString()
        {
            string result = this.journeyHeader.ToString();
            result += "------------------------------------------\n";
            result += this.journeyOrigin.ToString() + "\n";
            foreach(StopRecord stop in this.intermediateRecords)
            {
                result += stop.ToString() + "\n";
            }
            result += this.journeyDestination.ToString() + "\n";

            return result;
        }

        public string routeDescriptionKey()
        {
            string result = journeyHeader.route;
            result += (journeyHeader.direction == Direction.Inbound) ? "I" : "O";
            return result;
        }
    }
}

