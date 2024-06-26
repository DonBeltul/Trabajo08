namespace PruebaMVCTest
{
    [TestClass]
    public class UnitTest1
    {
        private TestContext context;

        public TestContext TestContext
        {
            get { return context; }
            set { context = value; }
        }
        [TestMethod()]
        [DeploymentItem("")]
        [DataSource("")]
        public void TestMethod1()
        {
        }
    }
}