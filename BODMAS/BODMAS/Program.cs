using System;
using System.Text;
using System.Data;

namespace BODMAS
{
    class Program
    {
        static void Main(string[] args)
        {
            string strin = "2+5^2/4*4+3";
            BIDMAS(strin);

        }
        // BIDMAS takes a string equation and then displays the answer
        static void BIDMAS(string equation)
        {
            StringBuilder sb = new StringBuilder(equation);
            string math;
            int j = 0;
            while(j<4)
            {
                for (int i = 0; i < sb.Length; i++)
                {
                    string ch = sb[i].ToString();
                    if (ch == "^" &j==0)
                    {
                        math = Replacalc(ch, i, sb);
                        sb = new StringBuilder(math);
                    }
                    if (ch == "/" & j == 1)
                    {
                        math = Replacalc(ch, i, sb);
                        sb = new StringBuilder(math);
                    }
                    if (ch == "*" & j == 2)
                    {
                        math = Replacalc(ch, i, sb);
                        sb = new StringBuilder(math);
                    }
                    if ((ch =="+"||ch=="-")&j==3)
                    {
                        math = Replacalc(ch, i, sb);
                        sb = new StringBuilder(math);
                    }
                }
                j++;
            }

            double answer = double.Parse(sb.ToString());
            Console.WriteLine("Answer: {0}",answer);

        }
        // Replacalc takes the character of an operator its position and the whole StringBuilder the
        // operator is in. As a result it produces a string containing the equation but with the numbers
        // either side of the operator calculated.
        // i.e. input:      ("^",3,"2+5^2/4*4+3")
        //      output:     "2+25/4*4+3"
        static string Replacalc(string ch, int inde, StringBuilder sb)
        {
            int count = 0;
            int index1 = 0;
            int index2 = 0;
            double x = 0;
            double y = 0;
            for (int j = inde - 1; j > -2; j--)
            {
                string sbch;
                if (j==-1)
                {
                    sbch = "000";
                }
                else
                {
                    sbch = sb[j].ToString();
                }
                if (sbch != "^" & sbch != "/" & sbch != "*"& sbch != "+"& sbch != "-"&j!=-1)
                {
                    count++;
                }
                else
                { 
                    StringBuilder sb2 = new StringBuilder("");
                    for (int q = 1; q < count + 1; q++)
                    {
                        string dig = sb[j + q].ToString();
                        sb2.Append(dig);
                    }
                    double int1 = double.Parse(sb2.ToString());
                    x = int1;
                    Console.WriteLine(int1);
                    index1 = j + 1;
                    break;
                }
                

            }
            int count2 = 0;
            for (int j = inde + 1; j < sb.Length+1; j++)
            {
                string sbch;
                if (j ==sb.Length)
                {
                    sbch = "000";
                }
                else
                {
                    sbch = sb[j].ToString();
                }
                if (sbch != "^" & sbch != "/" & sbch != "*" & sbch != "+" & sbch != "-"& j !=sb.Length)
                {
                    count2++;
                }
                else
                {
                    StringBuilder sb2 = new StringBuilder("");
                    for (int q = 1; q < count2 + 1; q++)
                    {
                        string dig = sb[j - (count2 + 1) + q].ToString();
                        sb2.Append(dig);
                    }
                    double int2 = double.Parse(sb2.ToString());
                    y = int2;
                    Console.WriteLine(int2);
                    index2 = j - 1;
                    break;
                }
                
            }
            string math = "";
            if (ch == "^") { math = Pow(x, y, index1, index2, sb); }
            if (ch == "/") { math = Div(x, y, index1, index2, sb); }
            if (ch == "*") { math = Tim(x, y, index1, index2, sb); }
            if (ch== "+") { math = Plu(x, y, index1, index2, sb); }
            if (ch == "-") { math = Min(x, y, index1, index2, sb); }
            return math;
            
        }
        // Div takes the number before (x) and after (y) the operator, the index of the start (index1) and
        // end (index2) of the sub-equation, and the whole StringBuilder. i.e.
        // input:       (25,4,2,5,"2+25/4*4-3")
        // output:      "2+6.25*4-3"
        static string Div(double x, double y, int index1, int index2, StringBuilder sb)
        {
            double ans = x / y;
            sb.Remove(index1, index2 - index1 + 1);
            sb.Insert(index1, ans);
            return sb.ToString();
        }
        // Tim takes the number before (x) and after (y) the operator, the index of the start (index1) and
        // end (index2) of the sub-equation, and the whole StringBuilder. i.e.
        // input:       (6.25,4,2,7,"2+6.25*4-3")
        // output:      "2+25-3"
        static string Tim(double x, double y, int index1, int index2, StringBuilder sb)
        {
            double ans = x * y;
            sb.Remove(index1, index2 - index1 + 1);
            sb.Insert(index1, ans);
            return sb.ToString();
        }
        // Pow takes the number before (x) and after (y) the operator, the index of the start (index1) and
        // end (index2) of the sub-equation, and the whole StringBuilder. i.e.
        // input:       (5,2,2,4,"2+5^2/4*4-3")
        // output:      "2+25/4*4-3"
        static string Pow(double x, double y, int index1, int index2, StringBuilder sb)
        {
            double ans = x;
            for (int i = 1; i < y; i++)
            {
                ans = ans * ans;
            }

            sb.Remove(index1, index2 - index1 + 1);
            sb.Insert(index1, ans);
            return sb.ToString();
        }
        // Plu takes the number before (x) and after (y) the operator, the index of the start (index1) and
        // end (index2) of the sub-equation, and the whole StringBuilder. i.e.
        // input:       (2,25,0,3,"2+25-3")
        // output:      "27-3"
        static string Plu(double x, double y, int index1, int index2, StringBuilder sb)
        {
            double ans = x + y;
            sb.Remove(index1, index2 - index1 + 1);
            sb.Insert(index1, ans);
            return sb.ToString();
        }
        // Min takes the number before (x) and after (y) the operator, the index of the start (index1) and
        // end (index2) of the sub-equation, and the whole StringBuilder. i.e.
        // input:       (27,3,0,3,"27-3")
        // output:      "24"
        static string Min(double x, double y, int index1, int index2, StringBuilder sb)
        {
            double ans = x - y;
            sb.Remove(index1, index2 - index1 + 1);
            sb.Insert(index1, ans);
            return sb.ToString();
        }
    }
}
