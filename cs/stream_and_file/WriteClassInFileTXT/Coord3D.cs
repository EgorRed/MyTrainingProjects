using System;
using System.Linq;

namespace WriteClassInFileTXT
{
    public class Coord3D
    {
        public Coord3D()
        {
            coord_X = 0;
            coord_Y = 0;
            coord_Z = 0;
        }

        public Coord3D(double coord_X, double coord_Y, double coord_Z)
        {
            this.coord_X = coord_X;
            this.coord_Y = coord_Y;
            this.coord_Z = coord_Z;
        }

        public double coord_X { get; set; }
        public double coord_Y { get; set; }
        public double coord_Z { get; set; }

        public override string ToString()
        {
            return $"X:{coord_X}\t Y:{coord_Y}\t Z:{coord_Z}";
            
        }

        public void PrintCord()
        {
            Console.WriteLine(ToString());
        }

        public static Coord3D Parse(string coords)
        {
            string result = String.Concat(coords.Split(new Char[] { ':', 'X', 'Y', 'Z' }));
            double[] parseCord = result.Split(new Char[] {' '}).Select(double.Parse).ToArray();
            Coord3D coord3D = new Coord3D(parseCord[0], parseCord[1], parseCord[2]);
            return coord3D;
        }
    }
}
