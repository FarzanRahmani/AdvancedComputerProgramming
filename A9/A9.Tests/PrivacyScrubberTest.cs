using System;
using Logger;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LoggerTest
{
    [TestClass]
    public class PrivacyScrubberTest 
    {
        [TestMethod]
        public void SinglePhoneNumberTest()
        {
            string piiNum = "(517)303-5279";
            string scrubbedPII = "(XXX)XXX-XXXX";
            string testString = $"My phone number is {piiNum}";
            string scrubbedString = $"My phone number is {scrubbedPII}";
            string replacedPIINum = PhoneNumberScrubber.Instance.Scrub(testString);
            Assert.AreEqual(replacedPIINum, scrubbedString);
        }

        [TestMethod]
        public void MultiplePhoneNumbersTest()
        {
            string pii1 = "(517)303-5279";
            string pii2 = "206-323-1212";
            string scrubbedPII1 = "(XXX)XXX-XXXX";
            string scrubbedPII2 = "XXX-XXX-XXXX";
            string testString = $"My phone number was {pii1} but it is {pii2} now";
            string scrubbedString = $"My phone number was {scrubbedPII1} but it is {scrubbedPII2} now";

            string replacedPIINum = PhoneNumberScrubber.Instance.Scrub(testString);
            Assert.AreEqual(replacedPIINum, scrubbedString);
        }

        [TestMethod]
        public void IDTest()
        {
            string testString = "Ali's SSN is  432-12-3232";
            string expectedString = "Ali's SSN is  XXX-XX-XXXX";

            string scrubbedString = IDScrubber.Instance.Scrub(testString);
            Assert.AreEqual(scrubbedString, expectedString);

        }

        [TestMethod]
        public void FullNameTest()
        {
            string testString = "Mr. Bill Gates failed the exam.";
            string expectedString = "Xx. Xxxx Xxxxx failed the exam.";

            string maskedString = FullNameScrubber.Instance.Scrub(testString);
            Assert.AreEqual(expectedString, maskedString);
        }

        // +++
        [TestMethod]
        public void IDTest2()
        {
            string testString = "Ali's SSN is  432 12 3232";
            string expectedString = "Ali's SSN is  XXX XX XXXX";

            string scrubbedString = IDScrubber.Instance.Scrub(testString);
            Assert.AreEqual(scrubbedString, expectedString);

        }

        [TestMethod]
        public void IranianIDTest1()
        {
            string testString = "Ali's SSN is  002-789432-7";
            string expectedString = "Ali's SSN is  XXX-XXXXXX-X";

            string scrubbedString = IDScrubber.Instance.Scrub(testString);
            Assert.AreEqual(scrubbedString, expectedString);

        }

        [TestMethod]
        public void IranianIDTest2()
        {
            string testString = "Ali's SSN is  002 789432 7";
            string expectedString = "Ali's SSN is  XXX XXXXXX X";

            string scrubbedString = IDScrubber.Instance.Scrub(testString);
            Assert.AreEqual(scrubbedString, expectedString);

        }

        [TestMethod]
        public void EmailScrubberTest1()
        {
            string testString = "Ali's e-mail is  Ali@gmail.com";
            string expectedString = "Ali's e-mail is  Xxx@xxxxx.xxx";

            string scrubbedString = EmailScrubber.Instance.Scrub(testString);
            Assert.AreEqual(scrubbedString, expectedString);

        }

        [TestMethod]
        public void EmailScrubberTest2()
        {
            string testString = "ali's email is ali@en.yahoo.com and he lives in Tehran and his mother's email is maryam@gmail.com";
            string expectedString = "ali's email is xxx@xx.xxxxx.xxx and he lives in Tehran and his mother's email is xxxxxx@xxxxx.xxx";

            string scrubbedString = EmailScrubber.Instance.Scrub(testString);
            Assert.AreEqual(scrubbedString, expectedString);

        }

        [TestMethod]
        public void EmailScrubberTest3()
        {
            string testString = "ali's email is ali_r@en.yahoo.com and he lives in Tehran and his mother's email is maryam_Rht@gmail.com";
            string expectedString = "ali's email is xxx_x@xx.xxxxx.xxx and he lives in Tehran and his mother's email is xxxxxx_Xxx@xxxxx.xxx";

            string scrubbedString = EmailScrubber.Instance.Scrub(testString);
            Assert.AreEqual(scrubbedString, expectedString);

        }

        [TestMethod]
        public void CCScrubberTest1()
        {
            string testString = "Ali's CC is  1452-9785-6321-4567";
            string expectedString = "Ali's CC is  XXXX-XXXX-XXXX-XXXX";

            string scrubbedString = CCScrubber.Instance.Scrub(testString);
            Assert.AreEqual(scrubbedString, expectedString);

        }

        [TestMethod]
        public void CCScrubberTest2()
        {
            string testString = "Ali's CC is  1452 9785 6321 4567";
            string expectedString = "Ali's CC is  XXXX XXXX XXXX XXXX";

            string scrubbedString = CCScrubber.Instance.Scrub(testString);
            Assert.AreEqual(scrubbedString, expectedString);

        }

        [TestMethod]
        public void CCScrubberTest3()
        {
            string testString = "Ali's CC is  1452978563214567";
            string expectedString = "Ali's CC is  XXXXXXXXXXXXXXXX";

            string scrubbedString = CCScrubber.Instance.Scrub(testString);
            Assert.AreEqual(scrubbedString, expectedString);

        }
    }

}
