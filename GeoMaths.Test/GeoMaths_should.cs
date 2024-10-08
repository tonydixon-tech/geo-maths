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
            Assert.Pass();
        }
    }

}