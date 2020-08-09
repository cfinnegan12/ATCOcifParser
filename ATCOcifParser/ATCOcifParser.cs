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
        public List<JourneyRecord> Journeys { get; }
        public Dictionary<string, LocationRecord> Locations { get; }
        public Dictionary<string, RouteDescription> Routes { get; }

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
            this.Journeys = new List<JourneyRecord>();
            this.Locations = new Dictionary<string, LocationRecord>();
            this.Routes = new Dictionary<string,RouteDescription>();
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
                        Journeys.Add(new JourneyRecord(lineCh));
                        break;
                    case "QO":
                        Journeys[Journeys.Count - 1].setOrigin(lineCh);
                        break;
                    case "QI":
                        Journeys[Journeys.Count - 1].addIntermediateRecord(lineCh);
                        break;
                    case "QT":
                        Journeys[Journeys.Count - 1].setDestination(lineCh);
                        break;
                    case "QD":
                        addRoute();
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

        private void addRoute()
        {
            string key = line.Substring(7, 5).Replace(" ", "");
            Routes[key] = new RouteDescription(lineCh);
        }

        private void addLocation()
        {
            string key = Util.charArrSubs(lineCh, 3, 12);
            Locations[key] = new LocationRecord(lineCh);
        }

        private void setLocationGridRef()
        {
            string key = line.Substring(3, 12);
            if(line.Length >= 29 && lineCh[15] != ' ')
            {
                Locations[key].setGridReference(lineCh);
            }
        }

    }
}
