using System;
using System.Collections.Generic;
using System.Text;

namespace ATCOcif.Location
{
    class LocationRecord : IRecord
    {
        public string location;
        public string fullLocation;
        public int gridEasting = -1;
        public int gridNorthing = -1;

        public LocationRecord(char[] chars)
        {
            this.location = Util.charArrSubs(chars, 3, 12);
            this.fullLocation = Util.charArrSubs(chars, 15, 48, false);
        }

        public void setGridReference(char[] chars)
        {
            this.gridEasting = Int32.Parse(Util.charArrSubs(chars, 15, 8));
            this.gridNorthing = Int32.Parse(Util.charArrSubs(chars, 23, 8));
        }

        public override string ToString()
        {
            string result = "Location (Short Form): \t" + location + "\nLocation (Full Form): \t" + fullLocation;
            result += "\nGrid Reference: \t" + gridEasting + "\t" + gridNorthing + "\n";
            return result;
        }
    }
}
