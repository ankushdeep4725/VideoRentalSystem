using System;
using System.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VideoRentalSystem;

namespace VideoRentalTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CheckDatabase()
        {
            Database db = new Database(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Rajbir\source\repos\VideoRentalSystem\VideoRentalSystemDB.mdf;Integrated Security=True");
            Assert.IsTrue(db.CheckConnection());
        }

        [TestMethod]
        public void CheckSelect()
        {
            Database db = new Database(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Rajbir\source\repos\VideoRentalSystem\VideoRentalSystemDB.mdf;Integrated Security=True");
            Assert.IsNotNull(db.SelectAnd("Customer"));
        }
    }
}
