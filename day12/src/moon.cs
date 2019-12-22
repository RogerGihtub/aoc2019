using System;
using System.Collections.Generic;

namespace src
{
    //alas, using sbyte was merely a beautiful dream
    public class Triplet
    {
        public int x;
        public int y;
        public int z;
    }

    public class Moon
    {
        public int ID;

        private int p_x;
        private int p_y;
        private int p_z;

        private int v_x;
        private int v_y;
        private int v_z;

        /*private int g_x;
        private int g_y;
        private int g_z;
        */

        private List<Triplet> pendingGravities;

        public Moon(int p_X, int p_Y, int p_Z)
        {
            p_x = p_X;
            p_y = p_Y;
            p_z = p_Z;

            v_x = 0;
            v_y = 0;
            v_z = 0;

            pendingGravities = new List<Triplet>();
        }

        public int X()
        {
            return p_x;
        }

        public int Y()
        {
            return p_y;
        }

        public int Z()
        {
            return p_z;
        }

        public int dX()
        {
            return v_x;
        }

        public int dY()
        {
            return v_y;
        }

        public int dZ()
        {
            return v_z;
        }

        public void AddPendingGravity(int g_X, int g_Y, int g_Z)
        {
            var g = new Triplet();

            g.x = g_X;
            g.y = g_Y;
            g.z = g_Z;

            pendingGravities.Add(g);
        }

        public void ApplyGravity(int dv_X, int dv_Y, int dv_Z)
        {
            v_x += dv_X;
            v_y += dv_Y;
            v_z += dv_Z;
        }

        public void ApplyGravity()
        {
            foreach (var g in pendingGravities)
            {
                ApplyGravity(g.x, g.y, g.z);
            }
            pendingGravities.Clear();

            /*v_x += g_x;
            v_y += g_y;
            v_z += g_z;*/
        }

        public void ApplyVelocity()
        {
            p_x += v_x;
            p_y += v_y;
            p_z += v_z;
        }

        public int PotentialEnergy()
        {
            return Math.Abs(p_x) + Math.Abs(p_y) + Math.Abs(p_z);
        }

        public int KineticEnergy()
        {
            return Math.Abs(v_x) + Math.Abs(v_y) + Math.Abs(v_z);
        }

        public int TotalEnergy() 
        {
            return PotentialEnergy() * KineticEnergy();
        }
    }
}
