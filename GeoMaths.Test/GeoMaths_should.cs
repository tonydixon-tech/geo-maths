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

        [Test]
        public void TestHDistance_coord_coord()
        {
            Console.WriteLine("Testing HDistance");
            GeoCoord start = new GeoCoord(0.0, 0.0);
            GeoCoord finish = new GeoCoord(0.0, 1.0);
            double actual = _geoMaths.HDistance(start, finish);
            double expected = 0;
            Assert.That(actual, Is.EqualTo(expected));
        }
    }

}