using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCock
{
    internal class InputHelper
    {
        public static List<List<int>> ReadInput(string path)
        {
            string input = File.ReadAllText(path);
            List<List<int>> list = new List<List<int>>();
            string[] groups = input.Split("\n\n");
            foreach (var group in groups)
            {
                var items = group.Split("\n").Select(s => int.Parse(s));
                list.Add(items.ToList());
            }
            return list;
        }
    }
}
