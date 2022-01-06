using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repository.Library;

namespace Repository.Tests
{
    [TestClass]
    public class StreamingContentInheritanceTests
    {
        [TestMethod]
        public void TestConstructor_ShouldStoreCorrectValues()
        {
            Show show = new Show("Breaking Bad", "Somewher in New Mexico stuff happens", 10, MaturityRating.R, 7, 100, 49);

            Assert.AreEqual(MaturityRating.R, show.MaturityRating);
        }
    }

}