using System;
using System.Collections.Generic;
using System.Text;

namespace ATCOcif
{
    abstract class StopRecord : IRecord
    {
        public string location;
        public string time;

        public StopRecord(char[] chars)
        {
            this.location = Util.charArrSubs(chars, 2, 12);
            initTime(chars);
        }

        virtual protected void initTime(char[] chars)
        {
            this.time = Util.charArrSubs(chars, 14, 4);
        }

        public override string ToString()
        {
            return "Location: " + this.location + "\tTime: " + this.time;
        }
    }
}
