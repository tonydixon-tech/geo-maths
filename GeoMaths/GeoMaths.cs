﻿using System;
using GeoMaths.Types;

namespace GeoMaths
{
  
    public class GeoMaths : IGeoMaths
    {
        public GeoMaths()
        {
        }

        public GeoCoord CalcPosition(double degrees, double distance, GeoCoord reference)
        {
            double lat1 = reference.lat;
            double lng1 = reference.lng;
            double bearing = Maths.toRadians(degrees);
            double ds_angular = distance / Constants.EARTH_SEMI_MAJOR_AXIS;

            // Calculate the latitude of the point
            double lat0 = Math.Asin(Math.Sin(lat1) * Math.Cos(ds_angular) + Math.Cos(lat1) * Math.Sin(ds_angular) * Math.Cos(bearing));

            // Calculate the longitude of the point
            double y = Math.Sin(bearing) * Math.Sin(ds_angular) * Math.Cos(lat1);
            double x = Math.Cos(ds_angular) - Math.Sin(lat1) * Math.Sin(lat0);
            double lng0 = lng1 + Math.Atan2(y, x);

            return new GeoCoord(Maths.toDegrees(lat0), Maths.toDegrees(lng0));
        }

        public GeoCoord CalcPosition(double degrees, double distance, GeoCoord reference)
        {
            // Get the lat-lon of the primary point in radians
            double lat0 = Maths.toRadians(primary.lat);
            double lng0 = Maths.toRadians(primary.lng);

            // Get the angular distance from the primary point
            double ds = Math.Sqrt(Math.Pow(ds_east, 2.0) + Math.Pow(ds_north, 2.0));
            ds /= Constants.EARTH_SEMI_MAJOR_AXIS;

            // Calculate the bearing
            double theta = Math.Atan2(ds_east, ds_north);

            // Calculate the latitude of the target position
            double lat1 = Math.Asin(Math.Sin(lat0) * Math.Cos(ds) + Math.Cos(lat0) * Math.Sin(ds) * Math.Cos(theta));

            // Calculate the target longitude
            double lng1 = lng0 + Math.Atan2(Math.Sin(theta) * Math.Sin(ds) * Math.Cos(lat0),
                Math.Cos(ds) - Math.Sin(lat0) * Math.Sin(lat1));

            // Convert lat lon from radians to degrees
            return new GeoCoord(Maths.toDegrees(lat1), Maths.toDegrees(lng1));
        }

        public GeoCoord CalcPosition(GeoCoord primary, double ds_north, double ds_east)
        {
            // Get the lat-lon of the primary point in radians
            double lat0 = Maths.toRadians(primary.lat);
            double lng0 = Maths.toRadians(primary.lng);

            // Get the angular distance from the primary point
            double ds = Math.Sqrt(Math.Pow(ds_east, 2.0) + Math.Pow(ds_north, 2.0));
            ds /= Constants.EARTH_SEMI_MAJOR_AXIS;

            // Calculate the bearing
            double theta = Math.Atan2(ds_east, ds_north);

            // Calculate the latitude of the target position
            double lat1 = Math.Asin(Math.Sin(lat0) * Math.Cos(ds) + Math.Cos(lat0) * Math.Sin(ds) * Math.Cos(theta));

            // Calculate the target longitude
            double lng1 = lng0 + Math.Atan2(Math.Sin(theta) * Math.Sin(ds) * Math.Cos(lat0),
                Math.Cos(ds) - Math.Sin(lat0) * Math.Sin(lat1));

            // Convert lat lon from radians to degrees
            return new GeoCoord(Maths.toDegrees(lat1), Maths.toDegrees(lng1));
        }

        public double HDistance(GeoCoord pointA, GeoCoord pointB)
        {
            // Copy coords to local radian variables
            double lat1 = Maths.toRadians(pointA.lat);
            double lon1 = Maths.toRadians(pointA.lng);
            double lat2 = Maths.toRadians(pointB.lat);
            double lon2 = Maths.toRadians(pointB.lng);

            double dsLat = lat2 - lat1;
            double dsLon = lon2 - lon1;

            var angle = Math.Pow(Math.Sin(dsLat / 2), 2) + Math.Cos(lat1) * Math.Cos(lat2) * Math.Pow(Math.Sin(dsLon / 2), 2);
            var c = 2 * Math.Atan2(Math.Sqrt(angle), Math.Sqrt(1 - angle));
            double ds = Constants.EARTH_SEMI_MAJOR_AXIS * c;
            return ds;
        }

        public double Heading(GeoCoord pointA, GeoCoord pointB)
        {
            throw new System.NotImplementedException();
        }
    }
}
