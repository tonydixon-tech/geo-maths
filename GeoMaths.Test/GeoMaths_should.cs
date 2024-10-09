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

        [TestCaseSource(nameof(CalcPositionNorthEastCases))]
        public void TestCalcPosition_primary_north_east(GeoCoord primary, double nm_north, double nm_east, GeoCoord expected, double delta)
        {
            GeoCoord actual = _geoMaths.CalcPosition(primary, nm_north, nm_east);
            //double expected = 60.0;
            Assert.That(actual.lat, Is.EqualTo(expected.lat).Within(delta), "expected latitude is incorrect");
            Assert.That(actual.lng, Is.EqualTo(expected.lng).Within(delta), "expected longitude is incorrect");
        }

        [TestCaseSource(nameof(HaversineGeoCoordCases))]
        public void TestHDistance_coord_coord(GeoCoord start, GeoCoord finish, double expected, double delta)
        {
            Console.WriteLine("Testing HDistance");
            double actual = _geoMaths.HDistance(start, finish);
            //double expected = 60.0;
            Assert.That(actual, Is.EqualTo(expected).Within(delta), "not remotely equal");
        }


        [TestCase(0.0, 0.0, 1.0, 0.0, 0.0, 0.01d)]
        [TestCase(0.0, 0.0, 1.0, 1.0, 45.0, 0.01d)]
        [TestCase(0.0, 0.0, 0.0, 1.0, 90.0, 0.01d)]
        [TestCase(0.0, 0.0, -1.0, 1.0, 135.0, 0.01d)]
        [TestCase(0.0, 0.0, -1.0, 0.0, 180.0, 0.01d)]
        [TestCase(0.0, 0.0, -1.0, -1.0, 225.0, 0.01d)]
        [TestCase(0.0, 0.0, 0.0, -1.0, 270.0, 0.01d)]
        [TestCase(0.0, 0.0, 1.0, -1.0, 315.0, 0.01d)]
        public void TestHeading(double lat0, double lon0, double lat1, double lon1, double expected, double delta)
        {
            Console.WriteLine("Testing Heading");
            double actual = _geoMaths.Heading(new GeoCoord(lat0, lon0), new GeoCoord(lat1, lon1));
            Assert.That(actual, Is.EqualTo(expected).Within(delta));
        }

        public static object[] HaversineGeoCoordCases =
        {
        new object[] { new GeoCoord(1.0, 0.0), new GeoCoord(0.0, 0.0), 60.0d, 0.2d },
        new object[] { new GeoCoord(0.0, 0.0), new GeoCoord(1.0, 0.0), 60.0d, 0.2d }
        };

        public static object[] CalcPositionNorthEastCases =
        {
        new object[] { new GeoCoord(0.0, 0.0), 100.0d, 0.0d, new GeoCoord(1.66, 0.0), 0.02d },       // 100 nm north
        new object[] { new GeoCoord(0.0, 0.0), 100.0d, 100.0d, new GeoCoord(1.66, 1.66), 0.02d },    // 100 nm north and east
        new object[] { new GeoCoord(0.0, 0.0), 0.0d, 100.0d, new GeoCoord(0.0, 1.66), 0.02d },       // 100 nm east
        new object[] { new GeoCoord(0.0, 0.0), -100.0d, 100.0d, new GeoCoord(-1.66, 1.66), 0.02d },  // 100 nm south and east
        new object[] { new GeoCoord(0.0, 0.0), -100.0d, 0.0d, new GeoCoord(-1.66, 0.0), 0.02d },     // 100 nm south
        new object[] { new GeoCoord(0.0, 0.0), -100.0d, -100.0d, new GeoCoord(-1.66, -1.66), 0.02d },// 100 nm south and west
        new object[] { new GeoCoord(0.0, 0.0), 0.0d, -100.0d, new GeoCoord(0.0, -1.66), 0.02d },     // 100 nm west
        new object[] { new GeoCoord(0.0, 0.0), 100.0d, -100.0d, new GeoCoord(1.66, -1.66), 0.02d }   // 100 nm north and west
        };
    }


}