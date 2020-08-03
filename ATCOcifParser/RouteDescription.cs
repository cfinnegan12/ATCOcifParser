using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace ATCOcif
{
    class RouteDescription : IRecord
    {
        public string route;
        public Direction direction;
        public string description;

        public RouteDescription(char[] chars)
        {
            this.route = Util.charArrSubs(chars, 7, 4);
            initDirection(chars);
            this.description = Util.charArrSubs(chars, 12, 68, false);
        }

        private void initDirection(char[] chars)
        {
            if (chars[11] == 'I') this.direction = Direction.Inbound;
            else this.direction = Direction.Outbound;
        }

        public override string ToString()
        {
            string result = route + ": " + direction + "\n"+description+"\n";
            return result;
        }

    }
}
