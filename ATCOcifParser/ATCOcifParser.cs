/**
 * Author: Ciaran Finnegan 
 */
using System.Collections.Generic;

namespace ATCOcif
{
    /**
     * <summary>ATCOcifParser Class parses and represents the journeys, routes, and locations in a provided ATCO-cif file</summary>
     * 
     */
    public class ATCOcifParser
    {
        public List<JourneyRecord> journeys;
        public Dictionary<string, LocationRecord> locations;
        public Dictionary<string, RouteDescription> routeDescriptions;
        private string filepath;
        private System.IO.StreamReader file;
        private string line;
        private char[] lineCh;
        private string recordIdentity;

        /// <summary>
        /// Constructor for ATCOcifParser objects.
        /// </summary>
        /// <param name="filepath">The path to the ATCO-cif file intended to be parsed</param>
        public ATCOcifParser(string filepath)
        {
            this.filepath = filepath;
            this.journeys = new List<JourneyRecord>();
            this.locations = new Dictionary<string, LocationRecord>();
            this.routeDescriptions = new Dictionary<string,RouteDescription>();
            this.file = new System.IO.StreamReader(this.filepath);
            this.line = "";
            Parse();
        }

        private void Parse()
        {
            while ((line = file.ReadLine()) != null)
            {
                lineCh = line.ToCharArray();
                recordIdentity = line.Substring(0,2);
                switch (recordIdentity)
                {
                    case "QS":
                        journeys.Add(new JourneyRecord(lineCh));
                        break;
                    case "QO":
                        journeys[journeys.Count - 1].setOriginRecord(lineCh);
                        break;
                    case "QI":
                        journeys[journeys.Count - 1].addIntermediateRecord(lineCh);
                        break;
                    case "QT":
                        journeys[journeys.Count - 1].setDestinationRecord(lineCh);
                        break;
                    case "QD":
                        addRouteDescription();
                        break;
                    case "QL":
                        addLocation();
                        break;
                    case "QB":
                        setLocationGridRef();
                        break;
                    default:
                        break;
                }
            }
        }

        private void addRouteDescription()
        {
            string key = line.Substring(7, 5).Replace(" ", "");
            routeDescriptions[key] = new RouteDescription(lineCh);
        }

        private void addLocation()
        {
            LocationRecord tmp = new LocationRecord(lineCh);
            locations[tmp.location] = tmp;
        }

        private void setLocationGridRef()
        {
            string key = line.Substring(3, 12);
            if(line.Length >= 29 && lineCh[15] != ' ')
            {
                locations[key].setGridReference(lineCh);
            }
        }

    }
}
