using System;
using NUnit.Framework;

namespace ProjectName.TestsPack2 {
    public class CodeNameTests {
        [TestCase("036000291452", "03600029145")]
        [TestCase("012300000642", "01230000064")]
        [TestCase("712345678904", "71234567890")]
        [TestCase("639382000393", "63938200039")]
        [Category("Positive test cases")]
        public void CkeckDigitByNotZeroPath_UPCcode_ReturnsUPCcodeWithCkeckDigit(String exp_upc_code_with_check_digit, String upc_code) {
            Assert.AreEqual(exp_upc_code_with_check_digit, CodeName.Calculate_check_digit(upc_code));
        }

        [Test]
        [Category("Positive test cases")]
        public void CkeckDigitByZeroPath__UPCcode_ReturnsUPCcodeWithCkeckDigit() {
            Assert.AreEqual("000000000000", CodeName.Calculate_check_digit("00000000000"));
        }

        [Test]
        [Category("Negative test cases")]
        public void CkeckDigitOnInvalidArgument_UPCcodeIsNull_ThrowsException() {
            Assert.Throws<ArgumentNullException>(() => CodeName.Calculate_check_digit(null));
        }

        [Test]
        [Category("Negative test cases")]
        public void CkeckDigitOnInvalidArgument_UPCcodeIsEmpty_ThrowsException() {
            Assert.Throws<ArgumentOutOfRangeException>(() => CodeName.Calculate_check_digit(""));
        }

        [Test]
        [Category("Negative test cases")]
        public void CkeckDigitOnInvalidArgument_UPCcodeIsToLong_ThrowsException() {
            Assert.Throws<ArgumentOutOfRangeException>(() => CodeName.Calculate_check_digit("712345678904"));
        }

        [Test]
        [Category("Negative test cases")]
        public void CkeckDigitOnInvalidArgument_UPCcodeIsToShort_ThrowsException() {
            Assert.Throws<ArgumentOutOfRangeException>(() => CodeName.Calculate_check_digit("7234567890"));
        }

        [Test]
        [Category("Negative test cases")]
        public void CkeckDigitOnInvalidArgument_InvalidFormatOfUPCcode_ThrowsException() {
            Assert.Throws<FormatException>(() => CodeName.Calculate_check_digit("7l234567890"));
        }

        [Test]
        [Category("Negative test cases")]
        public void CkeckDigitByNotZeroPath_NotExpectedUPCcode_ReturnsUPCcodeWithCkeckDigit() {
            Assert.AreNotEqual("712345678904", CodeName.Calculate_check_digit("10010101000"));
        }

        [Test]
        [Category("Negative test cases")]
        public void CkeckDigitByNotZeroPath_ActualNotExpected_ReturnsUPCcodeWithCkeckDigit() {
            Assert.AreNotEqual("712345678904", CodeName.Calculate_check_digit("11111111111"));
        }

        [Test]
        [Category("Negative test cases")]
        public void CkeckDigitByZeroPath_NotExpectedUPCcode_ReturnsUPCcodeWithCkeckDigit() {
            Assert.AreNotEqual("919959191090", CodeName.Calculate_check_digit("00000000000"));
        }

        [Test]
        [Category("Negative test cases")]
        public void CkeckDigitByZeroPath_ActualNotExpected_ReturnsUPCcodeWithCkeckDigit() {
            Assert.AreNotEqual("111111111117", CodeName.Calculate_check_digit("00000000000"));
        }

        [TestCase("712345678904", "71234567890")]
        [TestCase("712345678904", "71234567890")]
        [Category("Negative test cases")]
        public void CkeckDigitByNotZeroPath_UPCcodeREPEAT_ReturnsUPCcodeWithCkeckDigit(String exp_upc_code_with_check_digit, String upc_code) {
            Assert.AreEqual(exp_upc_code_with_check_digit, CodeName.Calculate_check_digit(upc_code));
        }

        [TestCase("000000000000", "00000000000")]
        [TestCase("000000000000", "00000000000")]
        [Category("Negative test cases")]
        public void CkeckDigitByZeroPath_UPCcodeREPEAT_ReturnsUPCcodeWithCkeckDigit(String exp_upc_code_with_check_digit, String upc_code) {
            Assert.AreEqual(exp_upc_code_with_check_digit, CodeName.Calculate_check_digit(upc_code));
        }
    }
}