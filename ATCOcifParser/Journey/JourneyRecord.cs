using System.Collections.Generic;


namespace ATCOcif
{
    public class JourneyRecord : IRecord
    {
        private OriginRecord origin;
        private DestinationRecord destination;


        public JourneyHeader Header { get; }
        public List<IntermediateRecord> IntermediateRecords { get; }
        public OriginRecord Origin { get { return origin; }}
        public DestinationRecord Destination { get { return destination; } }
        //public JourneyDataRunningRecord journeyDataRunningRecord;
        //public JourneyNoteRecord journeyNoteRecord;



        public JourneyRecord(char[] header)
        {
            this.Header = new JourneyHeader(header);
            this.IntermediateRecords = new List<IntermediateRecord>();
        }

        public void setOrigin(char[] origin)
        {
            this.origin = new OriginRecord(origin);
        }

        public void addIntermediateRecord(char[] chars)
        {
            this.IntermediateRecords.Add(new IntermediateRecord(chars));
        }

        public void setDestination(char[] chars)
        {
            this.destination= new DestinationRecord(chars);
        }

        public override string ToString()
        {
            string result = this.Header.ToString();
            result += "------------------------------------------\n";
            result += this.Origin.ToString() + "\n";
            foreach(StopRecord stop in this.IntermediateRecords)
            {
                result += stop.ToString() + "\n";
            }
            result += this.Destination.ToString() + "\n";

            return result;
        }

        public string routeDescriptionKey()
        {
            string result = Header.Route;
            result += (Header.Direction == Direction.Inbound) ? "I" : "O";
            return result;
        }
    }
}

