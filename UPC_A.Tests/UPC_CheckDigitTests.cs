using System;
using NUnit.Framework;

namespace UPC_A.Tests {
    [TestFixture]
    public class UPC_CheckDigitTests {
        //both input strings has different UPC-A code but same check digit which is equal 2
        [TestCase("036000291452", "03600029145")]
        [TestCase("012300000642", "01230000064")]

        //both input strings has different UPC-A code and different check digit which are equal 4 and 3
        [TestCase("712345678904", "71234567890")]
        [TestCase("639382000393", "63938200039")]
        [Category("Positive test cases")]
        public void CkeckDigitByNotZeroPath_UPCcode_ReturnsUPCcodeWithCkeckDigit(String exp_upc_code_with_check_digit, String upc_code) {
            Assert.AreEqual(exp_upc_code_with_check_digit, UPC_CheckDigit.Calculate_check_digit(upc_code));
        }

        //there are two main check digit calculate algorithms in tested method:
        //ByNotZeroPath and ByZeroPath
        //There is a comment in tested method which explain when both algorithms are used
        //For more code coverage both algorithms will be used with most of test cases
        [Test]
        [Category("Positive test cases")]
        public void CkeckDigitByZeroPath__UPCcode_ReturnsUPCcodeWithCkeckDigit() {
            Assert.AreEqual("000000000000", UPC_CheckDigit.Calculate_check_digit("00000000000"));
        }

        [Test]
        [Category("Negative test cases")]
        public void CkeckDigitOnInvalidArgument_UPCcodeIsNull_ThrowsException() {
            Assert.Throws<ArgumentNullException>(() => UPC_CheckDigit.Calculate_check_digit(null));
        }

        [Test]
        [Category("Negative test cases")]
        public void CkeckDigitOnInvalidArgument_UPCcodeIsEmpty_ThrowsException() {
            Assert.Throws<ArgumentOutOfRangeException>(() => UPC_CheckDigit.Calculate_check_digit(""));
        }

        [Test]
        [Category("Negative test cases")]
        public void CkeckDigitOnInvalidArgument_UPCcodeIsToLong_ThrowsException() {
            Assert.Throws<ArgumentOutOfRangeException>(() => UPC_CheckDigit.Calculate_check_digit("712345678904"));
        }

        [Test]
        [Category("Negative test cases")]
        public void CkeckDigitOnInvalidArgument_UPCcodeIsToShort_ThrowsException() {
            Assert.Throws<ArgumentOutOfRangeException>(() => UPC_CheckDigit.Calculate_check_digit("7234567890"));
        }

        [Test]
        [Category("Negative test cases")]
        public void CkeckDigitOnInvalidArgument_InvalidFormatOfUPCcode_ThrowsException() {
            Assert.Throws<FormatException>(() => UPC_CheckDigit.Calculate_check_digit("7l234567890"));
        }

        //same check digit doesn't mean same UPC-A code
        //other words different UPC-A code can give as same check digit as different
        //(proved by current test and by first test above)
        [Test]
        [Category("Negative test cases")]
        //both input strings, actual and expected, has different UPC-A code but same check digit which is equal 4 
        public void CkeckDigitByNotZeroPath_NotExpectedUPCcode_ReturnsUPCcodeWithCkeckDigit() {
            Assert.AreNotEqual("712345678904", UPC_CheckDigit.Calculate_check_digit("10010101000"));
        }

        [Test]
        [Category("Negative test cases")]
        //both input strings, actual and expected, has different UPC-A code and different check digit which are equal 4 and 7
        public void CkeckDigitByNotZeroPath_ActualNotExpected_ReturnsUPCcodeWithCkeckDigit() {
            Assert.AreNotEqual("712345678904", UPC_CheckDigit.Calculate_check_digit("11111111111"));
        }

        [Test]
        [Category("Negative test cases")]
        //both input strings, actual and expected, has different UPC-A code but same check digit which is equal 0
        public void CkeckDigitByZeroPath_NotExpectedUPCcode_ReturnsUPCcodeWithCkeckDigit() {
            Assert.AreNotEqual("919959191090", UPC_CheckDigit.Calculate_check_digit("00000000000"));
        }

        [Test]
        [Category("Negative test cases")]
        //both input strings, actual and expected, has different UPC-A code and different check digit which are equal 7 and 0
        public void CkeckDigitByZeroPath_ActualNotExpected_ReturnsUPCcodeWithCkeckDigit() {
            Assert.AreNotEqual("111111111117", UPC_CheckDigit.Calculate_check_digit("00000000000"));
        }

        //same UPC-A code always means same check digit
        [TestCase("712345678904", "71234567890")]
        [TestCase("712345678904", "71234567890")]
        [Category("Negative test cases")]
        public void CkeckDigitByNotZeroPath_UPCcodeREPEAT_ReturnsUPCcodeWithCkeckDigit(String exp_upc_code_with_check_digit, String upc_code) {
            Assert.AreEqual(exp_upc_code_with_check_digit, UPC_CheckDigit.Calculate_check_digit(upc_code));
        }

        [TestCase("000000000000", "00000000000")]
        [TestCase("000000000000", "00000000000")]
        [Category("Negative test cases")]
        public void CkeckDigitByZeroPath_UPCcodeREPEAT_ReturnsUPCcodeWithCkeckDigit(String exp_upc_code_with_check_digit, String upc_code) {
            Assert.AreEqual(exp_upc_code_with_check_digit, UPC_CheckDigit.Calculate_check_digit(upc_code));
        }
    }
}