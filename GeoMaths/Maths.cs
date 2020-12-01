//  ///////////////////////////////////////////////////////////////////////////
//  Maths.cs
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
namespace GeoMaths
{
    public class Maths
    {
        /// <summary>
        /// Coverts degrees to radians
        /// </summary>
        /// <param name="degrees"></param>
        /// <returns></returns>
        public static double toRadians(double degrees)
        {
            return Math.PI / 180.0 * degrees;
        }

        /// <summary>
        /// Converts radians to degrees
        /// </summary>
        /// <param name="radians"></param>
        /// <returns></returns>
        public static double toDegrees(double radians)
        {
            return radians * (180.0 / Math.PI);
        }
    }
}
