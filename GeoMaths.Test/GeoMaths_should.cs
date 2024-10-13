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

        [TestCaseSource(nameof(CalcPositionBearingDistanceCases))]
        public void TestCalcPosition_shouldReturnCoordinateAtDistanceAndHeading(double degrees, double nm_distance, GeoCoord reference, GeoCoord expected, double delta)
        {
            GeoCoord actual = _geoMaths.CalcPosition(degrees, nm_distance, reference);
            Assert.That(actual.lat, Is.EqualTo(expected.lat).Within(delta), "expected latitude is incorrect");
            Assert.That(actual.lng, Is.EqualTo(expected.lng).Within(delta), "expected longitude is incorrect");
        }

        [TestCaseSource(nameof(CalcPositionNorthEastCases))]
        public void TestCalcPosition_shouldReturnCoordinateNorthAndEastOfCurrentPosition(GeoCoord primary, double nm_north, double nm_east, GeoCoord expected, double delta)
        {
            GeoCoord actual = _geoMaths.CalcPosition(primary, nm_north, nm_east);

            Assert.That(actual.lat, Is.EqualTo(expected.lat).Within(delta), "expected latitude is incorrect");
            Assert.That(actual.lng, Is.EqualTo(expected.lng).Within(delta), "expected longitude is incorrect");
        }

        [TestCaseSource(nameof(HaversineGeoCoordCases))]
        public void TestHDistance_shouldReturnHaversineDistanceBetweenTwoCoordinates(GeoCoord start, GeoCoord finish, double expected, double delta)
        {
            Console.WriteLine("Testing HDistance");
            double actual = _geoMaths.HDistance(start, finish);
            //double expected = 60.0;
            Assert.That(actual, Is.EqualTo(expected).Within(delta), "not remotely equal");
        }


        [TestCase(1.0, 0.0, 0.0, 0.01d)]
        [TestCase(1.0, 1.0, 45.0, 0.01d)]
        [TestCase(0.0, 1.0, 90.0, 0.01d)]
        [TestCase(-1.0, 1.0, 135.0, 0.01d)]
        [TestCase(-1.0, 0.0, 180.0, 0.01d)]
        [TestCase(-1.0, -1.0, 225.0, 0.01d)]
        [TestCase(0.0, -1.0, 270.0, 0.01d)]
        [TestCase(1.0, -1.0, 315.0, 0.01d)]
        public void TestHeading_shouldReturnHeadingToCoordinateFromReferenceCoordinate(double lat1, double lon1, double expected, double delta)
        {
            Console.WriteLine("Testing Heading {0} deg", expected);
            GeoCoord start = new GeoCoord();
            GeoCoord finish =  new GeoCoord(lat1, lon1);
            double actual = _geoMaths.Heading(start, finish);
            Assert.That(actual, Is.EqualTo(expected).Within(delta));
        }

        public static object[] HaversineGeoCoordCases =
        {
            new object[] { new GeoCoord(), new GeoCoord(), 0.0d, 0.001d },
            new object[] { new GeoCoord(1.0, 0.0), new GeoCoord(), 60.0d, 0.2d },
            new object[] { new GeoCoord(), new GeoCoord(1.0, 0.0), 60.0d, 0.2d }
        };

        public static object[] CalcPositionNorthEastCases =
        {
            new object[] { new GeoCoord(), 100.0d, 0.0d, new GeoCoord(1.66, 0.0), 0.02d },       // 100 nm north
            new object[] { new GeoCoord(), 100.0d, 100.0d, new GeoCoord(1.66, 1.66), 0.02d },    // 100 nm north and east
            new object[] { new GeoCoord(), 0.0d, 100.0d, new GeoCoord(0.0, 1.66), 0.02d },       // 100 nm east
            new object[] { new GeoCoord(), -100.0d, 100.0d, new GeoCoord(-1.66, 1.66), 0.02d },  // 100 nm south and east
            new object[] { new GeoCoord(), -100.0d, 0.0d, new GeoCoord(-1.66, 0.0), 0.02d },     // 100 nm south
            new object[] { new GeoCoord(), -100.0d, -100.0d, new GeoCoord(-1.66, -1.66), 0.02d },// 100 nm south and west
            new object[] { new GeoCoord(), 0.0d, -100.0d, new GeoCoord(0.0, -1.66), 0.02d },     // 100 nm west
            new object[] { new GeoCoord(), 100.0d, -100.0d, new GeoCoord(1.66, -1.66), 0.02d }   // 100 nm north and west
        };


        public static object[] CalcPositionBearingDistanceCases =
        {
            new object[] {  0.0d, 100.0d, new GeoCoord(), new GeoCoord(1.66, 0.0), 0.02d },         // 100 nm north
            new object[] {  45.0d, 100.0d, new GeoCoord(), new GeoCoord(1.18, 1.18), 0.02d },       // 100 nm north-east
            new object[] {  90.0d, 100.0d, new GeoCoord(), new GeoCoord(0.0, 1.66), 0.02d },        // 100 nm east
            new object[] {  135.0d, 100.0d, new GeoCoord(), new GeoCoord(-1.18, 1.18), 0.02d },     // 100 nm south-east
            new object[] {  180.0d, 100.0d, new GeoCoord(), new GeoCoord(-1.66, 0.0), 0.02d },      // 100 nm south
            new object[] {  225.0d, 100.0d, new GeoCoord(), new GeoCoord(-1.18, -1.18), 0.02d },    // 100 nm south-west
            new object[] {  270.0d, 100.0d, new GeoCoord(),new GeoCoord(0.0, -1.66), 0.02d },       // 100 nm west
            new object[] {  315.0d, 100.0d, new GeoCoord(), new GeoCoord(1.18, -1.18), 0.02d }      // 100 nm north-west
        };
    }


}