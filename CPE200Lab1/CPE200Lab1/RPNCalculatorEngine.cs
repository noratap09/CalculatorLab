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
        public string Process(string str)
        {
            Stack temp = new Stack();
            string[] parts;
            if (str.Last()!=' ')
            {
                str += " ";
            }
            parts = str.Split(' ');
            for(int i=0;i<parts.Length-1;i++)
            {
                if (isOperator(parts[i]) == false)
                {
                    temp.Push(parts[i]);
                    //Console.WriteLine(temp.Peek());
                }
                else
                {
                    if (temp.Count < 2)
                    {
                        return "E";
                    }
                        string firstOperand = temp.Pop().ToString();
                        string secondOperand = temp.Pop().ToString();
                        temp.Push(calculate(parts[i], secondOperand, firstOperand, 4));
                }
            }
            Console.WriteLine(temp.Count.ToString());
            if (temp.Count==1)
            {
                return temp.Peek().ToString();
            }
            // your code here

            return "E";
        }

        public static void PrintValues(IEnumerable myCollection, char mySeparator)
        {
            foreach (Object obj in myCollection)
                Console.Write("{0}{1}", mySeparator, obj);
            Console.WriteLine();
        }
    }
}
