using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace ATCOcif
{
    class IntermediateRecord : StopRecord
    {
        public char activity;

        public IntermediateRecord(char[] chars) : base(chars)
        {
            this.activity = chars[22];
        }

        protected override void initTime(char[] chars)
        {
            this.time = Util.charArrSubs(chars, 18, 4);
        }
    }
}
