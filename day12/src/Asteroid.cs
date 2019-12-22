using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;

namespace src
{
    public class Asteroid
    {
        public int X;
        public int Y;
        public int Count;
        //public Point point;
        

        public bool CanISeeYou(Asteroid friend, List<Asteroid> field)
        {
            // we don't want to count seeing ourselves
            if (this.X == friend.X && this.Y == friend.Y) return false;

            var points = IntegralPointsBetweenPoints(this, friend);
            var ret = true;
            

            foreach (var p in points)
            {
                if (IsOccupied(p, field)) ret = false;
            }

            return ret;
        }

        public List<Asteroid> GenerateCounts(List<Asteroid> field)
        {
            var ret = new List<Asteroid>();

            foreach (var asteroid1 in field)
            {
                foreach (var asteroid2 in field)
                {
                    if (asteroid1.X == 4 && asteroid1.Y == 0
                        && asteroid2.X == 1 && asteroid2.Y == 2)
                    {
                        var stopnow = true;
                    }

                    if (asteroid1.CanISeeYou(asteroid2, field)) asteroid1.Count += 1;
                }
                ret.Add(asteroid1);
            }
            return ret;
        }

        public int GetMaxCount(List<Asteroid> field)
        {
            var ret = 0;
            foreach (var asteroid in field)
            {
                if (asteroid.Count > ret) ret = asteroid.Count;
            }
            return ret;
        }

        public List<Asteroid> IngestStrings(string[] strings)
        {
            var ret = new List<Asteroid>();

            const char ASTEROID = '#';
            for (int i = 0; i < strings.Count(); i++)
            {
                var s = strings[i];
                for (int j = 0; j < s.Length; j++)
                {
                    var c = s[j];
                    if (c==ASTEROID)
                    {
                        var x = j;
                        var y = i;
                        var a = new Asteroid();
                        a.X = x;
                        a.Y = y;
                        a.Count = 0;
                        ret.Add(a);
                    }
                }
            }
            return ret;
        }

        public List<Asteroid> IngestFile(string filename)
        {
            var strings = File.ReadAllLines(filename);
            return IngestStrings(strings);
        }

            public void Simplify(int[] numbers)
        {
            int[] signs = (int[])numbers.Clone();
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] < 0) { signs[i] = -1; } else { signs[i] = +1; }
            }

            int gcd = GCD(numbers);
            for (int i = 0; i < numbers.Length; i++)
            {
                if (gcd != 0) { numbers[i] /= gcd; } else 
                    {if (numbers[i] != 0) numbers[i] = 1;}
                if (numbers[i] >0 && signs[i] < 0) 
                           numbers[i] = numbers[i] * signs[i];
                if (numbers[i] < 0 && signs[i] > 0)
                    numbers[i] = numbers[i] * (-1);
            }
        }
        int GCD(int a, int b)
        {
            a = Math.Abs(a);
            b = Math.Abs(b);

            if (a == 1 || b == 1) return 1;
            //if (a == -1 || b == -1) return -1;

            while (b > 0)
            {
                int rem = a % b;
                a = b;
                b = rem;
            }
            return a;
        }
        int GCD(int[] args)
        {
            // using LINQ:
            return args.Aggregate((gcd, arg) => GCD(gcd, arg));
        }

        public List<Point> IntegralPointsBetweenPoints(Point a, Point b)
        {
            var ret = new List<Point>();
            if (a.X == b.X && a.Y == b.Y) return ret;

            var diff_X = b.X - a.X;
            var diff_Y = b.Y - a.Y;

            int[] deltas = new int[]{diff_X,diff_Y };

            Simplify(deltas);

            var inc_X = deltas[0];
            var inc_Y = deltas[1];

            var done = false;
            var curX = a.X;
            var curY = a.Y;
            while (!done)
            {
                curX += inc_X;
                curY += inc_Y;

                var newPt = new Point(curX, curY);

                if (newPt==b)
                {
                    done = true;
                }
                else
                {
                    ret.Add(newPt);
                }
            }

            return ret;
        }

        public List<Point> IntegralPointsBetweenPoints(Asteroid a1, Asteroid a2)
        {
            var a = new Point(a1.X, a1.Y);
            var b = new Point(a2.X, a2.Y);
            return IntegralPointsBetweenPoints(a, b);
        }

        public bool IsOccupied(Point p,  List<Asteroid> field)
        {
            //const string ASTEROID = "#";

            foreach (var asteroid in field)
            {
                if (asteroid.X == p.X && asteroid.Y == p.Y) return true;
            }
            return false;

        }

    }


}
