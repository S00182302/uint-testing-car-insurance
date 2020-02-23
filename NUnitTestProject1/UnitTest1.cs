using NUnit.Framework;
using System;
using testing_app;
using testing_app.Models;

namespace NUnitTestProject1
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase(0, 0)]
        [TestCase(3, 100)]
        [TestCase(5, 200)]
        [TestCase(10, 300)]
        public void Test_CalculatePenaltyFee(int point, int expected)
        {
            // Arrange
            Driver driver = new Driver();
            driver.PenaltyPoints = point;
            // Act
            var actual = driver.CalculatePenaltyFee();
            // Assess
            Assert.AreEqual(expected, actual);
        }

        [TestCase("01/01/2020", "01/01/2000", 20)]
        [TestCase("01/01/2020", "01/01/2020", 0)]
        [TestCase("01/01/2020", "01/01/2025", -5)]
        public void Test_GetAge(DateTime currentDate, DateTime DOB, int expected)
        {
            // Arrange
            Driver driver = new Driver();
            // Act
            var actual = driver.GetAge(currentDate, DOB);
            // Assess
            Assert.AreEqual(expected, actual);
        }



        [TestCase(InsuranceType.Comprehensive, "2020-01-01", "2005-01-01", 0.04)]
        [TestCase(InsuranceType.Comprehensive, "2020-01-01", "2000-01-01", 0.14)]
        [TestCase(InsuranceType.Comprehensive, "2020-01-01", "1994-01-01", 0.04)]
        [TestCase(InsuranceType.ThirdParty, "2020-01-01", "2005-01-01", 0.025)]
        [TestCase(InsuranceType.ThirdParty, "2020-01-01", "2000-01-01", 0.125)]
        [TestCase(InsuranceType.ThirdParty, "2020-01-01", "1994-01-01", 0.025)]
        public void Test_CalculatePremium(InsuranceType insuranceType, DateTime currentDate, DateTime dob, decimal expected)
        {
            // Arrange
            Driver driver = new Driver();
            driver.DOB = dob;
            driver.InsuranceType = insuranceType;
            // Act
            var actual = driver.CalculatePremium(currentDate);
            // Assess
            Assert.AreEqual(expected, actual);
        }

        
        [Test]
        [TestCase(10000, InsuranceType.Comprehensive, "2008/01/01", -1, "01/01/2020", -1)]
        [TestCase(10000, InsuranceType.Comprehensive, "2008/01/01", 0, "01/01/2020", -1)]
        [TestCase(10000, InsuranceType.Comprehensive, "2000/01/01", 13, "01/01/2020", -1)]
        [TestCase(10000, InsuranceType.Comprehensive, "2000/01/01", 0, "01/01/2020", 1400)]
        public void Test_CalculateQuote(decimal vehicleValue, InsuranceType insuranceType, DateTime dob, int penaltyPoints, DateTime testDate, decimal expected)
        {
            // Arrange
            Driver driver = new Driver();
            driver.InsuranceType = insuranceType;
            driver.VehicleValue = vehicleValue;
            driver.DOB = dob;
            driver.PenaltyPoints = penaltyPoints;
            // Act
            var actual = driver.CalculateQuote(testDate);
            // Assess
            Assert.AreEqual(expected, actual);
        }
        
    }
}