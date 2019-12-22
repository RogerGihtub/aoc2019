using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace src
{
    public static class Program
    {
        public static void Main()
        {
            Console.WriteLine("Hello World!  AoC 2019 - Day 06");

            Console.WriteLine($"Answers are in the tests.");
        }

        public static int Process(List<string> orbits, bool isPartTwo)
        {
            var ret = 0;
            const string root = "COM";
            const string rt = "$";
            const char delim = ')';
            const string you = "YOU";
            const string santa = "SAN";

            var expanded = new List<string>();

            var temp = new List<string>(); // for orbits
            var temp2 = new List<string>(); // for expanded

            var total_orbits = orbits.Count();

            foreach (var orbit in orbits)
            {
                temp.Add(orbit.Replace(root, rt));
                // this is mostly for the example sets where we don't want to replace
                // the 'C' in 'COM', but it's not harmful otherwise
            }

            orbits.Clear();
            foreach (var orbit in temp)
            {
                orbits.Add(orbit);
            }
            temp.Clear();


            while (orbits.Count > 0)
            {
                Console.Write("," + orbits.Count);
                // get that root node(s?) into expanded
                foreach (var orbit in orbits)
                {
                    if (orbit.StartsWith(rt))
                    {
                        expanded.Add(orbit);
                        //orbits.Remove(orbit);
                    }
                }

                // after expansion, orbit should be out of orbits
                foreach (var orbit in expanded)
                {
                    if (orbits.Contains(orbit)) orbits.Remove(orbit);
                }

                // see what we can expand
                foreach (var orbit in orbits)
                {
                    var exploded = false;
                    var parent = orbit.Split(delim)[0];

                    foreach (var exp in expanded)
                    {
                        var child = exp.Split(delim).Last();
                        if (parent == child)
                        {
                            var bigger = orbit.Replace(parent, exp);
                            temp2.Add(bigger);
                            exploded = true;
                        }
                    }

                    if (!exploded) temp.Add(orbit);
                }

                orbits.Clear();
                foreach (var orbit in temp)
                {
                    orbits.Add(orbit);
                }
                temp.Clear();

                foreach (var orbit in temp2)
                {
                    expanded.Add(orbit);
                }
                temp2.Clear();

            }

            var duplicateItems = expanded.GroupBy(x => x).Where(x => x.Count() > 1).Select(x => x.Key);

            Console.WriteLine($"**{duplicateItems.Count()}**  ");

            //loops?
            foreach (var orbit in expanded)
            {
                var splt = orbit.Split(delim);
                var duplicates = splt.GroupBy(x => x).Where(x => x.Count() > 1).Select(x => x.Key);

                if (duplicates.Count() > 0)
                {
                    Console.WriteLine($"****{duplicates.Count()}****  ");
                    Console.WriteLine($"****{orbit}****  ");
                }

            }


            // count
            foreach (var orbit in expanded)
            {
                int count = orbit.Count(f => f == delim);
                ret += count;
            }

            // BREAK here (below) for a look in expanded

            TextWriter tw = new StreamWriter(@"..\..\..\..\output01.txt");

            foreach (String s in expanded)
                tw.WriteLine(s);

            tw.Close();

            var total_expanded = expanded.Count;
            Console.WriteLine($">>{total_orbits} -- {total_expanded}<<  ");

            if (!isPartTwo) return ret;

            //look for YOU
            var you_str = "";
            var you_cnt = 0;
            foreach (var orbit in expanded)
            {
                var child = orbit.Split(delim).Last();
                if (child == you)
                {
                    you_str = orbit;
                    you_cnt = orbit.Count(f => f == delim);
                }
            }

            //look for SAN
            var san_str = "";
            var san_cnt = 0;
            foreach (var orbit in expanded)
            {
                var child = orbit.Split(delim).Last();
                if (child == santa)
                {
                    san_str = orbit;
                    san_cnt = orbit.Count(f => f == delim);
                }
            }

            //determine longest common str
            var cmn_str = "";
            var cmn_cnt = 0;

            cmn_str = lcs(you_str, san_str, rt);
            cmn_cnt = cmn_str.Count(f => f == delim);

            //calc
            ret = you_cnt - cmn_cnt + san_cnt - cmn_cnt;

            return ret; //388
        }

        // longest common substring (that starts with a particular value)
        public static string lcs(string a, string b, string root)
        {
            var lengths = new int[a.Length, b.Length];
            int greatestLength = 0;
            string output = "";
            for (int i = 0; i < a.Length; i++)
            {
                for (int j = 0; j < b.Length; j++)
                {
                    if (a[i] == b[j])
                    {
                        lengths[i, j] = i == 0 || j == 0 ? 1 : lengths[i - 1, j - 1] + 1;
                        if (lengths[i, j] > greatestLength)
                        {
                            var gl = lengths[i, j];
                            var op = a.Substring(i - greatestLength + 1, greatestLength);

                            greatestLength = lengths[i, j];
                            output = a.Substring(i - greatestLength + 1, greatestLength);

                            if (op.StartsWith(root))
                            {

                                greatestLength = lengths[i, j];
                                output = a.Substring(i - greatestLength + 1, greatestLength);
                            }
                        }
                    }
                    else
                    {
                        lengths[i, j] = 0;
                    }
                }
            }
            return output;
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
