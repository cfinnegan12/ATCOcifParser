﻿using System;

namespace ATCOcif
{
    public class IntermediateRecord : StopRecord
    {
        public char Activity { get; }


        public IntermediateRecord(char[] chars) : base(chars)
        {
            this.Activity = chars[22];
        }

        protected override void initTime(char[] chars)
        {
            string strtime = Util.charArrSubs(chars, 18, 4);
            int hours = Int32.Parse(strtime.Substring(0, 2));
            int mins = Int32.Parse(strtime.Substring(2, 2));
            this.time = new TimeSpan(hours, mins, 0);
        }
    }
}
