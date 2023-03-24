using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ServiceReference1;
using Microsoft.IdentityModel.Tokens;

namespace Session4Assignment
{
    [TestClass]
    public class UnitTest1
    {
        //Global Variable
        CountryInfoServiceSoapTypeClient? cisSoapTypeAPI;

        [TestInitialize]
        public void TestInit()
        {
   
           cisSoapTypeAPI = new CountryInfoServiceSoapTypeClient(CountryInfoServiceSoapTypeClient.EndpointConfiguration.CountryInfoServiceSoap12);
        }

        [TestMethod]
        public void TestMethod1()
        {
            var result1 = cisSoapTypeAPI.ListOfCountryNamesByCode();
            Assert.IsTrue(result1.SequenceEqual(result1.OrderBy(t => t.sISOCode)), "List of Country Names by Code are not in Ascending order");
        }

        [TestMethod]
        public void TestMethod2()
        {
            var result2 = cisSoapTypeAPI.CountryName("PH");
            Assert.AreEqual(result2, "Philippines", "Country Name did not match");

            var result3 = cisSoapTypeAPI.CountryName("ZZ");
            Assert.AreEqual(result3, "Country not found in the database", "Country Name has a match in database");

        }

        [TestMethod]
        public void TestMethod3()
        {
            var result4 = cisSoapTypeAPI.ListOfCountryNamesByCode();
            Assert.AreEqual(result4.Last().sISOCode, "ZW", "Country Code did not match");
            Assert.AreEqual(result4.Last().sName, "Zimbabwe", "Country Name did not match");

            var result5 = cisSoapTypeAPI.CountryName(result4.Last().sISOCode);
            Assert.AreEqual(result5, "Zimbabwe", "Country Name did not match");

            Assert.AreEqual(result5, result4.Last().sName, "Country Name did not match");
        }
    }
}