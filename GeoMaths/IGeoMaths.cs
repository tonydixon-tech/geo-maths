//  ///////////////////////////////////////////////////////////////////////////
//  IGeoMaths.cs
//
//  Author:
//       tonydixon <anthonydixon56@yahoo.com>
//       21/11/2020
//
//  Copyright (c) 2020 Anthony Dixon
//
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
//
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
//  ///////////////////////////////////////////////////////////////////////////
using System;
using GeoMaths.Types;

namespace GeoMaths
{
    public interface IGeoMaths
    {
        /// <summary>
        /// Calculate the geo GeoCoordinates of a point lying at a 
        /// distance in nautical miles along a given bearing
        /// </summary>
        /// <param name="degrees"></param>
        /// <param name="nm_distance"></param>
        /// <param name="reference"></param>
        /// <returns></returns>
        GeoCoord CalcPosition(double degrees, double nm_distance, GeoCoord reference);

        /// <summary>
        /// Calculate a geo GeoCoordinate at a point nautical miles north and east of a primary position
        /// </summary>
        /// <param name="primary"></param>
        /// <param name="nm_north"></param>
        /// <param name="nm_east"></param>
        /// <returns></returns>
        GeoCoord CalcPosition(GeoCoord primary, double nm_north, double nm_east);

        /// <summary>
        /// Calculates the distancle in nautical miles between two points using the Haversine formula
        /// </summary>
        /// <param name="pointA"></param>
        /// <param name="pointB"></param>
        /// <returns></returns>
        double HDistance(GeoCoord pointA, GeoCoord pointB);

        /// <summary>
        /// Calculate the heading in degrees from point A to point B.
        /// Input points are defined in decimal degrees.
        /// </summary>
        /// <param name="pointA"></param>
        /// <param name="pointB"></param>
        /// <returns></returns>
        double Heading(GeoCoord pointA, GeoCoord pointB);        
    }
}