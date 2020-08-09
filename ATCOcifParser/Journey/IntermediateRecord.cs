
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
            this.time = Util.charArrSubs(chars, 18, 4);
        }
    }
}
