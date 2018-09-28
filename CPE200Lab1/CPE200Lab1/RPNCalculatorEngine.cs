using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace CPE200Lab1
{
    public class RPNCalculatorEngine : CalculatorEngine
    {
        /// <summary>
        /// Use for Calculate with RPN Calculator style
        /// </summary>
        /// <param name="str">INPUT is String</param>
        /// <returns>OUTPUT is String</returns>
        public string Process(string str)
        {
            try
            {
                Stack temp = new Stack();
                string[] parts;
                if (str.Last() != ' ')
                {
                    str += " ";
                }
                parts = str.Split(' ');
                for (int i = 0; i < parts.Length - 1; i++)
                {
                    if (isOperator(parts[i]) == false && isSingle_Operator(parts[i]) == false)
                    {
                        temp.Push(parts[i]);
                    }
                    else if (isOperator(parts[i]) == true)
                    {
                        if (temp.Count < 2)
                        {
                            return "E";
                        }
                        string firstOperand = "0";
                        if (parts[i] != "%")
                        {
                            firstOperand = temp.Pop().ToString();
                        }
                        string secondOperand = temp.Pop().ToString();
                        temp.Push(calculate(parts[i], secondOperand, firstOperand, 4));
                    }
                    else if (isSingle_Operator(parts[i]) == true)
                    {
                        if (temp.Count < 1)
                        {
                            return "E";
                        }
                        string firstOperand = temp.Pop().ToString();
                        temp.Push(unaryCalculate(parts[i], firstOperand, 4));
                    }
                    Console.WriteLine(temp.Count.ToString());
                }
                Console.WriteLine(temp.Count.ToString());
                if (temp.Count == 1)
                {
                    return temp.Peek().ToString();
                }
                // your code here

                return "E";
            }
            catch (Exception er)
            {
                Console.WriteLine(er.ToString());
                return "E";
            }
        }

        /// <summary>
        /// Check is a Single_Operator
        /// </summary>
        /// <param name="str">INPUT is String</param>
        /// <returns>OUTPUT is String</returns>
        private bool isSingle_Operator(string str)
        {
            switch (str)
            {
                case "√":
                case "1/x":
                    return true;
            }
            return false;
        }
    }
}
