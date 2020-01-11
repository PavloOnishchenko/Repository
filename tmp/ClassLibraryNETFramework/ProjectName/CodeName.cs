using System;
using System.Text.RegularExpressions;

namespace ProjectName {
    public class CodeName {
        public static String Calculate_check_digit(String upc_a_code) {
            if (upc_a_code == null) {
                throw new ArgumentNullException("UPC-A code is Null\n");
            }

            int n = upc_a_code.Length;

            if (n != 11) {
                throw new ArgumentOutOfRangeException($"Invalid length {n} instead of 11\n");
            }

            if (!Regex.IsMatch(upc_a_code, @"^\d+$")) {
                throw new FormatException("Invalid format of UPC-A code\n");
            }

            int od_sum = 0, ev_sum = 0, check_digit = 0;

            for (int i = 0; i < n; i++) {
                if (i % 2 == 0) {
                    od_sum += (int)Char.GetNumericValue(upc_a_code[i]);
                } else {
                    ev_sum += (int)Char.GetNumericValue(upc_a_code[i]);
                }
            }

            int check_digit_tmp = (od_sum * 3 + ev_sum) % 10;

            if (check_digit_tmp != 0) {
                check_digit = 10 - check_digit_tmp;
            }

            return upc_a_code + check_digit.ToString();
        }
    }
}