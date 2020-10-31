using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*
 * These classes are ported from the VB.Net PCalculate library
*/

namespace _6800Emulator
{
    class PCalculation
    {
        double iNum1 = -1;
        double iNum2 = -1;
        string strOperator = "";

        public PCalculation(double iNewNum1, double iNewNum2, string strNewOperator)
        {
            iNum1 = iNewNum1;
            iNum2 = iNewNum2;
            strOperator = strNewOperator;
        }

        // Get the result of the calculation
        
        public double Result()
        {
            if (strOperator == "")
                return -1;

            switch (strOperator)
            {
                case "+":
                    return iNum1 + iNum2;

                case "-":
                    return iNum1 - iNum2;

                case "*":
                    return iNum1 * iNum2;

                case "/":
                    if (iNum1 == 0 || iNum2 == 0)
                        return 0;

                    return iNum1 / iNum2;

                case "%":
                    return iNum1 % iNum2;

                case "&":
                    return (int)iNum1 & (int)iNum2;

                case "|":
                    return (int)iNum1 | (int)iNum2;

                case "^":
                    return (int)iNum1 ^ (int)iNum2;

                default:
                    return 0;
            }
        }
    }

    class PCalculator
    {
        private SortedList<string, int> Operators = new SortedList<string, int>();

        public PCalculator()
        {
            // Create the order of operations
            Operators.Add("+", 2);
            Operators.Add("-", 2);
            Operators.Add("*", 3);
            Operators.Add("\\", 3);
            Operators.Add("/", 3);
            Operators.Add("%", 3);
            Operators.Add("&", 1);
            Operators.Add("|", 1);
            Operators.Add("^", 1);
        }

        public double Calculate(string strCalculation)
        {
            try
            {
                string strCalc = StripString(strCalculation);
                double dAnswer = 0;

                char[] aOperators = new char[9];

                aOperators[0] = '+';
                aOperators[1] = '-';
                aOperators[2] = '*';
                aOperators[3] = '\\';
                aOperators[4] = '/';
                aOperators[5] = '%';
                aOperators[6] = '&';
                aOperators[7] = '|';
                aOperators[8] = '^';

                dAnswer = DoCalculation(strCalc, aOperators);

                return dAnswer;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return 0;
            }
        }

        private double DoCalculation(string strCalculation, char[] aOperators)
        {
            try
            {
                string strAnswer = "";

                strAnswer = HandleBrackets(strCalculation, aOperators);

                // Fix the negative identifiers
                strAnswer = strAnswer.Replace("n", "-");

                return Convert.ToDouble(strAnswer);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return 0;
            }
        }

        private string HandleBrackets(string strCalculation, char[] aOperators)
        {
            try
            {
                string strCalc = ParseNegatives(strCalculation, aOperators);
                int i = strCalc.IndexOf(")");

                // If there are no ending brackets then there's no need to handle brackets (also strip out starting brackets)
                if (i == -1)
                {
                    strCalc = strCalc.Replace("(", "");
                    return EvaluateCalculation(strCalc, aOperators);
                }

                while (i != -1)
                {
                    int iStartEquation = strCalc.Substring(0, i).LastIndexOf("(");

                    if (iStartEquation != -1)
                    {
                        string strEquation = strCalc.Substring(iStartEquation + 1, i - iStartEquation - 1);

                        strCalc = strCalc.Remove(iStartEquation, i - iStartEquation + 1);
                        strCalc = strCalc.Insert(iStartEquation, EvaluateCalculation(strEquation, aOperators));
                    }
                    else
                    {
                        // Strip out excess brackets
                        strCalc = strCalc.Remove(i, 1);
                    }

                    i = strCalc.IndexOf(")");
                }

                return EvaluateCalculation(strCalc, aOperators);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return "";
            }
        }

        private string EvaluateCalculation(string strCalculation, char[] aOperators)
        {
            try
            {
                int i = 0;
                int iOperatorGroup = -1;
                int iOperatorPosition = -1;
                string strCalc = ParseNegatives(strCalculation, aOperators);
                string strOperator = "";

                if (strCalc == "")
                    return "0";

                if (strCalc.IndexOfAny(aOperators) == -1)
                    return strCalc;

                i = strCalc.IndexOfAny(aOperators);

                // Find the next most important operation in the order of operations
                while (i != -1)
                {
                    string strTempOperator = strCalc.Substring(i, 1);

                    if (Operators[strTempOperator] > iOperatorGroup)
                    {
                        strOperator = strTempOperator;
                        iOperatorPosition = i;
                        iOperatorGroup = Operators[strTempOperator];
                    }

                    i = strCalc.IndexOfAny(aOperators, i + 1);
                }

                string strNum1 = strCalc.Substring(0, iOperatorPosition);
                string strNum2 = strCalc.Substring(iOperatorPosition + 1);

                if (strNum1.LastIndexOfAny(aOperators) != -1)
                {
                    strNum1 = strNum1.Substring(strNum1.LastIndexOfAny(aOperators) + 1);
                }

                if (strNum2.IndexOfAny(aOperators) != -1)
                {
                    strNum2 = strNum2.Substring(0, strNum2.IndexOfAny(aOperators));
                }

                strNum1 = strNum1.Replace("n", "-");
                strNum2 = strNum2.Replace("n", "-");

                PCalculation Calc = new PCalculation(Convert.ToDouble(strNum1), Convert.ToDouble(strNum2), strOperator);

                string s = strCalc;
                s = s.Remove(iOperatorPosition - strNum1.Length, strNum1.Length + strNum2.Length + strOperator.Length);
                s = s.Insert(iOperatorPosition - strNum1.Length, Calc.Result().ToString());

                return EvaluateCalculation(s, aOperators);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return "";
            }
        }

        // Strip spaces out of the string
        private string StripString(string strString)
        {
            try
            {
                return strString.Replace(" ", "");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return "";
            }
        }

        // Replace any '-' character with 'n' if it represents a negative number
        private string ParseNegatives(string strString, char[] aOperators)
        {
            try
            {
                if (strString.IndexOfAny(aOperators) == -1)
                    return strString;

                if (strString == "")
                    return "";

                if (strString[0] == '-')
                {
                    strString = strString.Remove(0, 1);
                    strString = strString.Insert(0, "n");
                }

                int i = strString.IndexOfAny(aOperators);

                while (i != -1)
                {
                    if (i == (strString.Length - 1))
                    {
                        break;
                    }

                    if (strString.Substring(i + 1, 1) == "-")
                    {
                        strString = strString.Remove(i + 1, 1);
                        strString = strString.Insert(i + 1, "n");
                    }

                    i = strString.IndexOfAny(aOperators, i + 1);
                }

                return strString;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return "";
            }
        }
    }
}
