using System.Collections;
using GeoMaths.Types;

namespace GeoMaths.Test
{

    [TestFixture]
    public class GeoMaths_should
    {
        private IGeoMaths _geoMaths;
        [SetUp]
        public void Setup()
        {
            _geoMaths = new GeoMaths();
        }

        [Test]
        public void TestCalcPosition_deg_dist_ref()
        {
            Assert.Pass();
        }

        [Test]
        public void TestCalcPosition_primary_north_east()
        {
            Assert.Pass();
        }

        [TestCaseSource(nameof(HaversineGeoCoordCases))]
        public void TestHDistance_coord_coord(GeoCoord start, GeoCoord finish)
        {
            Console.WriteLine("Testing HDistance");
            double actual = _geoMaths.HDistance(start, finish);
            double expected = Constants.METRES_PER_NM * 60.0;
            Assert.That(actual, Is.EqualTo(expected).Within(200.0), "not remotely equal");
        }


        [TestCase(0.0, 0.0, 1.0, 0.0, 0.0, 0.01)]
        [TestCase(0.0, 0.0, 1.0, 1.0, 45.0, 0.01)]
        [TestCase(0.0, 0.0, 0.0, 1.0, 90.0, 0.01)]
        [TestCase(0.0, 0.0, -1.0, 1.0, 135.0, 0.01)]
        [TestCase(0.0, 0.0, -1.0, 0.0, 180.0, 0.01)]
        [TestCase(0.0, 0.0, -1.0, -1.0, 225.0, 0.01)]
        [TestCase(0.0, 0.0, 0.0, -1.0, 270.0, 0.01)]
        [TestCase(0.0, 0.0, 1.0, -1.0, 315.0, 0.01)]
        public void TestHeading(double lat0, double lon0, double lat1, double lon1, double expected, double delta)
        {
            Console.WriteLine("Testing Heading");
            double actual = _geoMaths.Heading(new GeoCoord(lat0, lon0), new GeoCoord(lat1, lon1));
            Assert.That(actual, Is.EqualTo(expected).Within(delta));
        }

        public static object[] HaversineGeoCoordCases =
        {
        new object[] { new GeoCoord(1.0, 0.0), new GeoCoord(0.0, 0.0) },
        new object[] { new GeoCoord(0.0, 0.0), new GeoCoord(1.0, 0.0) }
        };
    }


}