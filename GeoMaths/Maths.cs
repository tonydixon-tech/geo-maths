using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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