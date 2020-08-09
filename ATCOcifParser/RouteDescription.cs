
namespace ATCOcif
{
    public class RouteDescription : IRecord
    {
        public string Route { get; }
        public Direction Direction { get; }
        public string Description { get; }

        public RouteDescription(char[] chars)
        {
            this.Route = Util.charArrSubs(chars, 7, 4);
            this.Direction = (chars[11] == 'I') ? Direction.Inbound : Direction.Outbound;
            this.Description = Util.charArrSubs(chars, 12, 68, false);
        }


        public override string ToString()
        {
            string result = Route + ": " + Direction + "\n"+Description+"\n";
            return result;
        }

    }
}
