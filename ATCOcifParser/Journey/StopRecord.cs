using System;
using System.Collections.Generic;
using System.Text;

namespace ATCOcif
{
    public abstract class StopRecord : IRecord
    {
        private string location;
        protected TimeSpan time;

        public string Location { get { return location; } }
        public TimeSpan Time {get { return time; }}

        public StopRecord(char[] chars)
        {
            this.location = Util.charArrSubs(chars, 2, 12);
            initTime(chars);
        }

        virtual protected void initTime(char[] chars)
        {
            string strtime = Util.charArrSubs(chars, 14, 4);
            int hours = Int32.Parse(strtime.Substring(0,2));
            int mins = Int32.Parse(strtime.Substring(2, 2));
            this.time = new TimeSpan(hours, mins, 0);
        }

        public override string ToString()
        {
            return "Location: " + this.Location + "\tTime: " + this.Time;
        }
    }
}
