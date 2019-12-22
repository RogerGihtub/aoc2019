using System;
using System.Collections.Generic;

namespace src
{
    public static class Program
    {
        public static void Main()
        {
            Console.WriteLine("Hello World!  AoC 2019 - Day 04");

            Console.WriteLine($"Answers are in the tests.");
        }

        public static bool Process(int pwd, bool isPartTwo)
        {
            var p = pwd.ToString();

            // Two adjacent digits are the same (like 22 in 122345).

            if (
                p.Contains("00") ||
                p.Contains("11") ||
                p.Contains("22") ||
                p.Contains("33") ||
                p.Contains("44") ||
                p.Contains("55") ||
                p.Contains("66") ||
                p.Contains("77") ||
                p.Contains("88") ||
                p.Contains("99"))
            {

                var a = p.Substring(0, 1);
                var b = p.Substring(1, 1);
                var c = p.Substring(2, 1);
                var d = p.Substring(3, 1);
                var e = p.Substring(4, 1);
                var f = p.Substring(5, 1);

                int a1 = 0;
                int b1 = 0;
                int c1 = 0;
                int d1 = 0;
                int e1 = 0;
                int f1 = 0;

                int.TryParse(a, out a1);
                int.TryParse(b, out b1);
                int.TryParse(c, out c1);
                int.TryParse(d, out d1);
                int.TryParse(e, out e1);
                int.TryParse(f, out f1);

                // Going from left to right, the digits never decrease;

                if (b1 < a1) return false;
                if (c1 < b1) return false;
                if (d1 < c1) return false;
                if (e1 < d1) return false;
                if (f1 < e1) return false;

                if (!isPartTwo) return true;

                // part 2: the two adjacent matching digits are not part of a larger group of matching digits.

                p = p.Replace("000000", "");
                p = p.Replace("111111", "");
                p = p.Replace("222222", "");
                p = p.Replace("333333", "");
                p = p.Replace("444444", "");
                p = p.Replace("555555", "");
                p = p.Replace("666666", "");
                p = p.Replace("777777", "");
                p = p.Replace("888888", "");
                p = p.Replace("999999", "");

                p = p.Replace("00000", "");
                p = p.Replace("11111", "");
                p = p.Replace("22222", "");
                p = p.Replace("33333", "");
                p = p.Replace("44444", "");
                p = p.Replace("55555", "");
                p = p.Replace("66666", "");
                p = p.Replace("77777", "");
                p = p.Replace("88888", "");
                p = p.Replace("99999", "");

                p = p.Replace("0000", "");
                p = p.Replace("1111", "");
                p = p.Replace("2222", "");
                p = p.Replace("3333", "");
                p = p.Replace("4444", "");
                p = p.Replace("5555", "");
                p = p.Replace("6666", "");
                p = p.Replace("7777", "");
                p = p.Replace("8888", "");
                p = p.Replace("9999", "");

                p = p.Replace("000", "");
                p = p.Replace("111", "");
                p = p.Replace("222", "");
                p = p.Replace("333", "");
                p = p.Replace("444", "");
                p = p.Replace("555", "");
                p = p.Replace("666", "");
                p = p.Replace("777", "");
                p = p.Replace("888", "");
                p = p.Replace("999", "");

                if (
    p.Contains("00") ||
    p.Contains("11") ||
    p.Contains("22") ||
    p.Contains("33") ||
    p.Contains("44") ||
    p.Contains("55") ||
    p.Contains("66") ||
    p.Contains("77") ||
    p.Contains("88") ||
    p.Contains("99")) return true; // 1145

                return false;
            }
            else
            {
                return false;
            }
            //return false;
        }

        public static int ProcessRange(int lower, int upper, bool isPartTwo)
        {
            var ret = 0;

            for (int i = lower; i <= upper; i++)
            {
                if (Process(i,isPartTwo)) ret++;
            }

            return ret;
        }

        public static List<string> Ingest(string filename)
        {

            string line;

            var arr = new List<string>();

            System.IO.StreamReader file =
                new System.IO.StreamReader(filename);
            while ((line = file.ReadLine()) != null)
            {
                /*var arrS = line.Split(',').ToList();

                foreach (var S in arrS)
                {
                    int i = 0;
                    int.TryParse(S, out i);
                    arr.Add(i);
                }*/
                arr.Add(line);
            }

            file.Close();

            return arr;
        }
    }
}
