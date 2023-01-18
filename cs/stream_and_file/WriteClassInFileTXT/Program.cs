using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace WriteClassInFileTXT
{
    class Program
    {

        public static Coord3D RandomCoordsValue()
        {
            Random randomCords = new Random();
            Coord3D coord3D = new Coord3D();
            coord3D.coord_X = randomCords.Next(0, 100) / 10.0;
            coord3D.coord_Y = randomCords.Next(0, 100) / 10.0;
            coord3D.coord_Z = randomCords.Next(0, 100) / 10.0;
            return coord3D;
        }

        static void Main(string[] args)
        {

            List<Coord3D> coords = new List<Coord3D>();

            string fileName = "Coords.txt";
            using (var sw = new StreamWriter(fileName, false, Encoding.UTF8))
            {
                for (int i = 0; i < 9; i++)
                {
                    sw.WriteLine(RandomCoordsValue().ToString());
                }
            }

            using (var sw = new StreamReader(fileName, Encoding.UTF8))
            {
                while(!sw.EndOfStream)
                {
                    coords.Add(Coord3D.Parse(sw.ReadLine()));
                }
            }

            foreach (var item in coords)
            {
                item.PrintCord();
            }
        }
    }
}
