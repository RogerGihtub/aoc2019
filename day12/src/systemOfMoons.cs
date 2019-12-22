using System;
using System.Collections.Generic;
using System.Text;

namespace src
{
    /*public class Triplet
    {
        public int x;
        public int y;
        public int z;
    }*/

    public class SystemOfMoons
    {
        private List<Moon> _moons;
        public int TotalEnergy = 0;

        public SystemOfMoons()
        {
            _moons = new List<Moon>();
        }

        public void AddMoon(Moon moon)
        {
            int id = (int)_moons.Count;
            moon.ID = id;
            _moons.Add(moon);
        }

        public void AddMoon(int x, int y, int z)
        {
            var moon = new Moon((int)x, (int)y, (int)z);
            int id = (int)_moons.Count;
            moon.ID = id;
            _moons.Add(moon);
        }

        public List<Moon> GetMoons()
        {
            return _moons;
        }

        public bool AreMoonsSame(List<Moon> past)
        {
//lightly-optimized
            for (int i = 0; i < 4; i++)
            {
                if (_moons[i].X() != past[i].X()) return false;
                if (_moons[i].Y() != past[i].Y()) return false;
                if (_moons[i].Z() != past[i].Z()) return false;

                if (_moons[i].dX() != past[i].dX()) return false;
                if (_moons[i].dY() != past[i].dY()) return false;
                if (_moons[i].dZ() != past[i].dZ()) return false;
            }
            return true;
        }

        public string MoonHash()
        {
            var ret = "";

            //lightly-optimized
            for (int i = 0; i < 4; i++)
            {
ret+= $"{_moons[i].ID}:{_moons[i].X()},{_moons[i].Y()},{_moons[i].Z()},{_moons[i].dX()},{_moons[i].dY()},{_moons[i].dZ()};";
            }
            return ret;
        }

        public string MoonHash(int i)
        {
                return $"{_moons[i].ID}:{_moons[i].X()},{_moons[i].Y()},{_moons[i].Z()},{_moons[i].dX()},{_moons[i].dY()},{_moons[i].dZ()};";
        }

        public List<string> MoonReport()
        {
            var ret = new List<string>();
            foreach (var moon in _moons)
            {
                var line = 
$"{moon.ID}: pos= <x= {moon.X()}, y=  {moon.Y()}, z= {moon.Z()}>, vel= <x= {moon.dX()}, y=  {moon.dY()}, z= {moon.dZ()}>";
                ret.Add(line);
            }

            var totalEnergy = 0;
            foreach (var moon in _moons)
            {
                var ln =
$"pot: {moon.PotentialEnergy()};   kin: {moon.KineticEnergy()};   total:  {moon.TotalEnergy()}";
                ret.Add(ln);
                totalEnergy += moon.TotalEnergy();
            }
            ret.Add($"Total Energy: {totalEnergy}");
            TotalEnergy = totalEnergy;

            return ret;
        }

        public void ExecuteTimeStep()
        {
            /*          
Simulate the motion of the moons in time steps. 
Within each time step, 
first update the velocity of every moon by applying gravity. 
Then, once all moons' velocities have been updated, 
update the position of every moon by applying velocity. 
Time progresses by one step once all of the positions are updated.
             */

            var pairs = GeneratePairs();

            foreach (var pair in pairs)
            {
                CreateThenAddPendingGravityFields(pair);
            }

            foreach (var moon in _moons)
            {
                moon.ApplyGravity();
                moon.ApplyVelocity(); // I'm sure this is fine
            }
        }

        public void CreateThenAddPendingGravityFields(List<Moon> pair)
        {
            var a = pair[0];
            var b = pair[1];

            int a_x = (int)(b.X() - a.X());
            int a_y = (int)(b.Y() - a.Y());
            int a_z = (int)(b.Z() - a.Z());

            if (a_x > 1) a_x = 1;
            if (a_x < -1) a_x = -1;

            if (a_y > 1) a_y = 1;
            if (a_y < -1) a_y = -1;

            if (a_z > 1) a_z = 1;
            if (a_z < -1) a_z = -1;

            int b_x = (int)(a_x * -1);
            int b_y = (int)(a_y * -1);
            int b_z = (int)(a_z * -1);

            foreach (var moon in _moons)
            {
                if (a.ID == moon.ID) moon.AddPendingGravity(a_x, a_y, a_z);
                if (b.ID == moon.ID) moon.AddPendingGravity(b_x, b_y, b_z);
            }

            //a.AddPendingGravity(a_x, a_y, a_z);
            //b.AddPendingGravity(b_x, b_y, b_z);

            //var ret = new List<Moon>();
            //ret.Add(a);
            //ret.Add(b);
            //return ret;
        }

        public List<List<Moon>> GeneratePairs()
        {
            var ret = new List<List<Moon>>(); // prepare final result

            for (int i = 0; i < _moons.Count; i++)
                for (int j = i + 1; j < _moons.Count; j++)
                    if (j < _moons.Count)
                    {
                        var pair = new List<Moon>();
                        pair.Add(_moons[i]);
                        pair.Add(_moons[j]);
                        ret.Add(pair);
                    }

            return ret;
        }

    }
}
