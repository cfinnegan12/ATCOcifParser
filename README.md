# ATCOcifParser
<h3>by Ciaran Finnegan</h3>
<p>The ATCO.cif format is a standard used widely by the transport industry for data on routing and scheduling. This library is used to read and parse ATCO-cif files into useful c# objects.</p>

# Usage
## ATCOcifParser
This is the class that will hold the parsed data from the cif file. The constructor has one parameter, filepath, which should be a string presenting the path to cif file you wish to parse.

Example:
```
using ATCOcifParser;
.
.
.
  ATCOcifParser parser = new ATCOcifParser("PATH\TO\FILE.cif");
```

The ATCOcifParser has the following properties:
* Journeys
* Locations
* Routes

which represent their cif standard items
