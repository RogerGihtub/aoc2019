using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace src
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!  AoC 2019 - Day 08");

            var img = Ingest(@"..\..\..\..\input01.txt");
            var width = 25;
            var height = 6;

            Console.WriteLine($"{Process(img, width, height)}"); // 2460 // 
            Console.WriteLine();
            Console.WriteLine();

            Decode(img, width, height); // LRFKU

        }

        public static int Process(string image, int width, int height)
        {
            var layers = new List<string>();
            var len = width * height;

            layers = Split(image, len).ToList();

            var minZeroes = len;
            var ret = 0;

            foreach (var layer in layers)
            {
                var zeroes = layer.Count(f => f == '0');

                if (zeroes < minZeroes)
                {
                    minZeroes = zeroes;
                    var ones = layer.Count(f => f == '1');
                    var twos = layer.Count(f => f == '2');
                    ret = ones * twos;
                }
            }

            return ret;
        }

        public static void Decode(string image, int width, int height)
        {
            var layers = new List<string>();
            var len = width * height;

            layers = Split(image, len).ToList();

            var msg = "";

            for (int i = 0; i < len; i++)
            {
                msg += FrobLayers(layers, i);
            }

            var msgLines = Split(msg, width).ToList();

            foreach (var m in msgLines)
            {
                Console.WriteLine(m);
            }


        }

        public static string FrobLayers(List<string> layers, int i)
        {
            var ret = " ";
            var revLayers = Reverse(layers);

            foreach (var layer in revLayers)
            {
                if (layer[i] == '0') ret = " ";
                if (layer[i] == '1') ret = "█";
            }

            return ret;
        }

        static IEnumerable<T> Reverse<T>(IEnumerable<T> input)
        {
            return new Stack<T>(input);
        }

        static IEnumerable<string> Split(string str, int chunkSize)
        {
            return Enumerable.Range(0, str.Length / chunkSize)
                .Select(i => str.Substring(i * chunkSize, chunkSize));
        }

        public static string Ingest(string filename)
        {
            return File.ReadAllText(filename);
        }

    }
}
