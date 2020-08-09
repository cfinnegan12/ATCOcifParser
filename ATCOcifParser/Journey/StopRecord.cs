using System;
using System.Collections.Generic;
using System.Text;

namespace ATCOcif
{
    public abstract class StopRecord : IRecord
    {
        private string location;
        protected string time;

        public string Location { get { return location; } }
        public string Time {get { return time; }}

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
            return "Location: " + this.Location + "\tTime: " + this.Time;
        }
    }
}
