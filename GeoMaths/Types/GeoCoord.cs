using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeoMaths.Types
{
    public class GeoCoord
    {
        public double lat { get; set; }
        public double lng { get; set; }

        public GeoCoord()
        {
            lat = 0.0;
            lng = 0.0;
        }

        public GeoCoord(double lat, double lng)
        {
            this.lat = lat;
            this.lng = lng;
        }
    }
}