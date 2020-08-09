using System;

namespace ATCOcif
{
    public class LocationRecord : IRecord
    {
        private int gridEasting = -1;
        private int gridNorthing = -1;


        public string Location { get; }
        public string FullLocation { get; }
        public int GridEasting { get => gridEasting; }
        public int GridNorthing { get => gridNorthing; }

        public LocationRecord(char[] chars)
        {
            this.Location = Util.charArrSubs(chars, 3, 12);
            this.FullLocation = Util.charArrSubs(chars, 15, 48, false);
        }

        public void setGridReference(char[] chars)
        {
            this.gridEasting = Int32.Parse(Util.charArrSubs(chars, 15, 8));
            this.gridNorthing = Int32.Parse(Util.charArrSubs(chars, 23, 8));
        }

        public override string ToString()
        {
            string result = "Location (Short Form): \t" + Location + "\nLocation (Full Form): \t" + FullLocation;
            result += "\nGrid Reference: \t" + GridEasting + "\t" + GridNorthing + "\n";
            return result;
        }
    }
}
