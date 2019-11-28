using System;
using System.Text.RegularExpressions;

namespace UPC_A {
    /*
        The simple UPC_CheckDigit class
        Contains only one static method for performing check digit colculation from UPC-A code
    */
    /// <summary>
    /// The simple <c>UPC_CheckDigit</c> class.
    /// Contains only one static method for performing check digit colculation from UPC-A code.
    /// </summary>
    /// <remarks>
    /// This class can colculate check digit from UPC-A code and returns the UPC-A code appended with the check digit.
    /// </remarks>
    public class UPC_CheckDigit {
        /// <summary>
        /// Takes a string as parameter containing a UPC-A code and returning the UPC-A code
        /// appended with the check digit.
        /// </summary>
        /// <returns>
        /// The UPC-A code appended with the check digit.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">Thrown when UPC-A code is Null</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown when invalid length of UPC-A code</exception>
        /// <exception cref="System.FormatException">Thrown when invalid format of UPC-A code</exception>
        /// See <see cref="Regex.IsMatch(String, String)"/> to add regular expressions.
        /// <param name="upc_a_code">A String containing a UPC-A code.</param>
        public static String Calculate_ckeck_digit(String upc_a_code) {
            if (upc_a_code == null) {
                throw new ArgumentNullException("UPC-A CODE IS NULL\n");
            }

            int n = upc_a_code.Length;

            if (n != 11) {
                throw new ArgumentOutOfRangeException("INVALID LENGTH OF UPC-A CODE\n");
            }

            if (!Regex.IsMatch(upc_a_code, @"^\d+$")) {
                throw new FormatException("INVALID FORMAT OF UPC-A CODE\n");
            }

            int od_sum = 0, ev_sum = 0, check_digit = 0;

            //as first index of array is 0, but index 1 should be insted in acordance with technical task,
            //od_sum and ev_sum have been switched to emulate work starting from index 1 which is not even number
            //while zero it is
            for (int i = 0; i < n; i++) {
                if (i % 2 == 0) {
                    od_sum += (int)Char.GetNumericValue(upc_a_code[i]);
                } else {
                    ev_sum += (int)Char.GetNumericValue(upc_a_code[i]);
                }
            }

            int check_digit_tmp = (od_sum * 3 + ev_sum) % 10;

            //if check_digit_tmp not equal to zero then ByNotZeroPath algorithm takes it place, otherway ByZeroPath
            if (check_digit_tmp != 0) {
                check_digit = 10 - check_digit_tmp;
            }

            return upc_a_code + check_digit.ToString();
        }
    }
}