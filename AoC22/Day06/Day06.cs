using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCock
{
    internal class Day06 : IDay
    {
        readonly string input;
        readonly int packetSize = 4;
        readonly int messageSize = 14;
        public Day06(string file)
        {
            input = File.ReadAllText(file);
        }
        public static bool IsUnique(string marker, out int fallBackCount)
        {
            fallBackCount = 0;
            for (int i = marker.Length - 1; i > 0; i--)
            {
                for (int c = i - 1; c >= 0; c--)
                {
                    if (marker[i] == marker[c])
                    {
                        fallBackCount = marker.Length - 1 - c;
                        return false;
                    }
                }
            }
            return true;
        }
        public void GetMarkerIndex(int markerSize)
        {
            string current = "";
            int i = 0;
            while (i < input.Length)
            {
                current += input[i];
                i++;
                if (current.Length == markerSize)
                {
                    if (!IsUnique(current, out int fallBack))
                    {
                        i -= fallBack;
                        current = "";
                    }
                    else
                        break;
                }
            }
            Console.WriteLine(i);
        }
        public void PartOne()
        {
            GetMarkerIndex(packetSize);
        }

        public void PartTwo()
        {
            GetMarkerIndex(messageSize);
        }
    }
}
