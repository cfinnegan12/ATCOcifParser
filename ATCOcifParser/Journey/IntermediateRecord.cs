
namespace ATCOcif
{
    public class IntermediateRecord : StopRecord
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
