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
        public int OrderOfDestruction = 0;
        public double Bearing;
        public int ManDist = 0;

        //public Point point;


        /* public Asteroid DestroyAsteroidAlongPath(int DestroyedSoFar, List<Asteroid> field, Asteroid station, Point target)
        {
            var points = station.IntegralPointsBetweenPoints(this, target);

        }*/

        public List<Asteroid> DestroyAllAsteroids(List<Asteroid> field, Asteroid station)
        {
            var bearingField = GenerateBearings(station, field);
            var targetCount = bearingField.Count; // won't destroy station; bearingField doesn't include it

            var destructionField = new List<Asteroid>();

            var beamWidth = GetMinimumBearingDifference(bearingField);
            beamWidth = beamWidth / 1;

            double bearing = (double)0; // start at up

            while (destructionField.Count < targetCount)
            {
                while (bearing < 360)
                {
                    var targets = FindAsteroidsAlongBearing(bearingField, bearing, beamWidth);
                    if (targets.Count > 0)
                    {
                        var toDestroy = ReturnClosestAsteroid(targets);

                        if (toDestroy != null)
                        {
                            var destructionCount = GetDestructionCount(destructionField);
                            toDestroy.OrderOfDestruction = destructionCount + 1;
                            destructionField.Add(toDestroy);

                            var updatedField = RemoveDestroyedAsteroid(bearingField, toDestroy);
                            bearingField.Clear();
                            foreach (var item in updatedField)
                            {
                                bearingField.Add(item);
                            }
                        }
                    }
                    bearing += beamWidth;
                }
                bearing = bearing - (double)360; //start over
            }

            return destructionField;
        }

        public List<Asteroid> FindAsteroidsAlongBearing(List<Asteroid> field, double bearing, double beamWidth)
        {
            var ret = new List<Asteroid>();

            foreach (var target in field)
            {
                var targetBearing = target.Bearing;

                if (Math.Abs(targetBearing - bearing) < (beamWidth / 2)) ret.Add(target);
            }
            return ret;
        }

        public List<Asteroid> RemoveDestroyedAsteroid(List<Asteroid> field, Asteroid target)
        {
            var ret = new List<Asteroid>();

            foreach (var asteroid in field)
            {
                if (!(asteroid.X == target.X && asteroid.Y == target.Y)) ret.Add(asteroid);
            }
            return ret;
        }

        public int GetDestructionCount(List<Asteroid> field)
        {
            int ret = 0;

            if (field.Count == 0) return 0;

            foreach (var asteroid in field)
            {
                if (asteroid.OrderOfDestruction > ret)
                    ret = asteroid.OrderOfDestruction;
            }
            return ret;
        }

        public Asteroid GetSpecificDestroyedAsteroid(List<Asteroid> field, int destructionSequence)
        {
            foreach (var asteroid in field)
            {
                if (asteroid.OrderOfDestruction == destructionSequence)
                    return asteroid;
            }
            return null;
        }

        public Asteroid GetSpecificDestroyedAsteroid(List<Asteroid> field, int X, int Y)
        {
            foreach (var asteroid in field)
            {
                if (asteroid.X == X && asteroid.Y == Y)
                    return asteroid;
            }
            return null;
        }


        public List<Asteroid> GenerateBearings(Asteroid origin, List<Asteroid> field)
        {
            var ret = new List<Asteroid>();

            foreach (var target in field)
            {
                if (!(origin.X == target.X && origin.Y == target.Y)) // notself
                {
                    target.Bearing = TakeBearing(origin, target);

                    // while we're at it...
                    target.ManDist = GetManhattanDistance(origin, target);

                    ret.Add(target);
                }
            }
            return ret;
        }

        public Asteroid ReturnClosestAsteroid(List<Asteroid> targets)
        {

            if (targets.Count == 1) return targets.First();

            var minDistance = int.MaxValue;

            foreach (var target in targets)
            {
                if ((target.ManDist > 0) && (target.ManDist < minDistance)) minDistance = target.ManDist;
            }

            foreach (var target in targets)
            {
                if (target.ManDist == minDistance) return target;
            }

            return null;
        }

        public int GetManhattanDistance(Asteroid origin, Asteroid target)
        {
            var x = origin.X - target.X;
            var y = origin.Y - target.Y;
            return (x * x) + (y * y);

        }

        public double GetMinimumBearingDifference(List<Asteroid> field)
        {
            double min = (double)360;

            foreach (var a in field)
            {
                foreach (var b in field)
                {
                    double diff = Math.Abs(a.Bearing - b.Bearing);
                    if (diff > (double)0)
                    {
                        if (diff < min) min = diff;
                    }
                }
            }
            return min;
        }

        public double TakeBearing(Point A, Point B)
        {
            int a = 0;
            int o = 0;
            double mycalcInRadians = 0;
            double mycalcInDegrees = 0;

            if (A.X == B.X)
            {
                if (A.Y > B.Y) return (double)0;
                if (A.Y < B.Y) return (double)180;
            }

            if (A.Y == B.Y)
            {
                if (A.X < B.X) return (double)90;
                if (A.X > B.X) return (double)270;
            }

            if ((A.X < B.X) && (A.Y > B.Y)) // 00-90 (n - e)
            {
                if ((A.Y - B.Y) >= (B.X - A.X)) // 00-45 (n - ne)
                {
                    a = A.Y - B.Y;
                    o = B.X - A.X;

                    mycalcInRadians = Math.Atan2(o, a);
                    mycalcInDegrees = mycalcInRadians * ((double)(180)) / Math.PI;
                    return mycalcInDegrees;
                }
                else // 45-90 (ne - e)
                {
                    o = A.Y - B.Y;
                    a = B.X - A.X;

                    mycalcInRadians = Math.Atan2(o, a);
                    mycalcInDegrees = mycalcInRadians * ((double)(180)) / Math.PI;
                    return ((double)(090)) - mycalcInDegrees;
                }
            }

            if ((A.X < B.X) && (A.Y < B.Y)) // 90-180 (se)
            {
                if ((B.Y - A.Y) >= (B.X - A.X)) // 90-135 (e - se)
                {
                    o = B.Y - A.Y;
                    a = B.X - A.X;

                    mycalcInRadians = Math.Atan2(o, a);
                    mycalcInDegrees = mycalcInRadians * ((double)(180)) / Math.PI;
                    return ((double)(090)) + mycalcInDegrees;
                }
                else // 135-180 (se - s)
                {
                    a = B.Y - A.Y;
                    o = B.X - A.X;

                    mycalcInRadians = Math.Atan2(o, a);
                    mycalcInDegrees = mycalcInRadians * ((double)(180)) / Math.PI;
                    return ((double)(180)) - mycalcInDegrees;
                }
            }

            if ((A.X > B.X) && (A.Y < B.Y)) // 180-270 (sw)
            {
                if ((B.Y - A.Y) >= (A.X - B.X)) // 180-225 (s - sw)
                {
                    a = B.Y - A.Y;
                    o = A.X - B.X;

                    mycalcInRadians = Math.Atan2(o, a);
                    mycalcInDegrees = mycalcInRadians * ((double)(180)) / Math.PI;
                    return ((double)(180)) + mycalcInDegrees;
                }
                else // 225-270 (sw - w)
                {
                    o = B.Y - A.Y;
                    a = A.X - B.X;

                    mycalcInRadians = Math.Atan2(o, a);
                    mycalcInDegrees = mycalcInRadians * ((double)(180)) / Math.PI;
                    return ((double)(270)) - mycalcInDegrees;
                }
            }

            if ((A.X > B.X) && (B.Y < A.Y)) // 270-360 (nw)
            {
                if ((B.Y - A.Y) <= (A.X - B.X)) // 270-315 (w - nw)
                {
                    o = A.Y - B.Y;
                    a = A.X - B.X;

                    mycalcInRadians = Math.Atan2(o, a);
                    mycalcInDegrees = mycalcInRadians * ((double)(180)) / Math.PI;
                    return ((double)(270)) + mycalcInDegrees;
                }
                else // 315-360 (sw - w)
                {
                    a = A.Y - B.Y;
                    o = A.X - B.X;

                    mycalcInRadians = Math.Atan2(o, a);
                    mycalcInDegrees = mycalcInRadians * ((double)(180)) / Math.PI;
                    return ((double)(360)) - mycalcInDegrees;
                }
            }

            /*
            if ((A.X > B.X) && (A.Y < B.Y)) // 180-270 (sw)
            {
                var a = B.Y - A.Y;
                var o = A.X - B.X;

                double mycalcInRadians = Math.Atan2(o, a);
                double mycalcInDegrees = mycalcInRadians * ((double)(180)) / Math.PI;
                return ((double)(90)) + mycalcInDegrees;
            }
            */

            return 0;
        }

        public double TakeBearing(Asteroid origin, Asteroid target)
        {
            var a = new Point(origin.X, origin.Y);
            var b = new Point(target.X, target.Y);
            return TakeBearing(a, b);
        }

        public Point WhereIsMaxCount(List<Asteroid> field)
        {
            var ret = 0;
            var X = 0;
            var Y = 0;
            foreach (var asteroid in field)
            {
                if (asteroid.Count > ret)
                {
                    ret = asteroid.Count;
                    X = asteroid.X;
                    Y = asteroid.Y;
                }
            }
            return new Point(X, Y);
        }

        public Point GetMyTwelveOClock()
        {
            // overkill but...
            return new Point(X, 0);
        }

        public Point GetLowerRightPoint(string filename)
        {
            var strings = File.ReadAllLines(filename);
            var max_X = (strings[0].Length) - 1;
            var max_Y = (strings.Count()) - 1;
            return new Point(max_X, max_Y);
        }


        public List<Point> RocksAroundTheClockTonight(Point startingPoint, Point extremePoint)
        {
            var ret = new List<Point>();

            ret.Add(startingPoint);

            // clockwise (right) along top
            for (int i = startingPoint.X + 1; i <= extremePoint.X; i++)
            {
                ret.Add(new Point(i, 0));
            }

            // clockwise (down) along right
            for (int j = 1; j <= extremePoint.Y; j++)
            {
                ret.Add(new Point(extremePoint.X, j));
            }

            // clockwise (left) along bottom
            for (int k = extremePoint.X - 1; k >= 0; k--)
            {
                ret.Add(new Point(k, extremePoint.Y));
            }

            // clockwise (up) along left
            for (int m = extremePoint.Y - 1; m >= 0; m--)
            {
                ret.Add(new Point(0, m));
            }

            // clockwise (right) along top, stopping short of starting point
            for (int n = 1; n < startingPoint.X; n++)
            {
                ret.Add(new Point(n, 0));
            }

            return ret;
        }

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
                    /*if (asteroid1.X == 4 && asteroid1.Y == 0
                        && asteroid2.X == 1 && asteroid2.Y == 2)
                    {
                        var stopnow = true;
                    }*/

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
                    if (c == ASTEROID)
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
                if (gcd != 0) { numbers[i] /= gcd; }
                else
                { if (numbers[i] != 0) numbers[i] = 1; }
                if (numbers[i] > 0 && signs[i] < 0)
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

            int[] deltas = new int[] { diff_X, diff_Y };

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

                if (newPt == b)
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

        public List<Point> IntegralPointsBetweenPoints(Asteroid a1, Point b)
        {
            var a = new Point(a1.X, a1.Y);
            return IntegralPointsBetweenPoints(a, b);
        }


        public bool IsOccupied(Point p, List<Asteroid> field)
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
