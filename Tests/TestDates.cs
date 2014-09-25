using System;
using Interfaces_JonSkeet;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NodaTime;
using NodaTime.Testing;

namespace Tests
{
    [TestClass]
    public class TestDates
    {
        [TestMethod]
        public void ExpiredLicence()
        {
            Instant expiry = Instant.FromUtc(2000, 1, 1, 0, 0, 0);
            FakeClock clock = new FakeClock(expiry + Duration.Epsilon);
            ImprovedLicence licence = new ImprovedLicence(expiry, clock);
            Assert.IsTrue(licence.hasExpired);
        }


        [TestMethod] 
        public void NonExpiredLicence()
        {
            Instant expiry = Instant.FromUtc(2000, 1, 1, 0, 0, 0);
            FakeClock clock = new FakeClock(expiry - Duration.Epsilon);
            ImprovedLicence licence = new ImprovedLicence(expiry, clock);
            Assert.IsFalse(licence.hasExpired);
        }



        [TestMethod]
        public void ExpiredAtExactInstant()
        {
            Instant expiry = Instant.FromUtc(2000, 1, 1, 0, 0, 0);
            FakeClock clock = new FakeClock(expiry);
            ImprovedLicence licence = new ImprovedLicence(expiry, clock);
            Assert.IsTrue(licence.hasExpired);
        }

        [TestMethod]
        public void NonExpiredLicenceBecomesExpiredLicence()
        {
            Instant expiry = Instant.FromUtc(2000, 1, 1, 0, 0, 0);
            FakeClock clock = new FakeClock(expiry - Duration.Epsilon);
            ImprovedLicence licence = new ImprovedLicence(expiry, clock);

            Assert.IsFalse(licence.hasExpired);

            clock.AdvanceTicks(1);

            Assert.IsTrue(licence.hasExpired);

        }
    }
}
