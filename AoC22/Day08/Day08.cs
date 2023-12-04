using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC22
{
    internal class Day08 : IDay
    {
        readonly string[] input;
        readonly int xLength;
        readonly int zLength;
        public Day08(string file)
        {
            input = File.ReadAllLines(file);

            for (int z = 0; z < input.Length; z++)
            {
                for (int x = 0; x < input[z].Length; x++)
                {
                    int y = int.Parse(input[z][x].ToString());
                    trees.Add(new VectorTree(x, y, z));
                }
            }
            zLength = input.Length;
            xLength = input[0].Length;
        }
        public class VectorTree
        {
            public int x;
            public int y;
            public int z;
            public VisibleDirections visibleFrom;
            public bool isVisible => visibleFrom.left || visibleFrom.right || visibleFrom.up || visibleFrom.down;
            public VectorTree(int xCoord, int yHeight, int zCoord)
            {
                x = xCoord;
                y = yHeight;
                z = zCoord;
            }
            public struct VisibleDirections
            {
                public VisibleDirections(bool right, bool left, bool up, bool down)
                {
                    this.left = left;
                    this.right = right;
                    this.up = up;
                    this.down = down;
                }
                public bool left;
                public bool right;
                public bool up;
                public bool down;
            }
        }
        public List<VectorTree> trees = new();

        public void PartOne()
        {
            int visibleTrees = 0;
            foreach (var tree in trees)
            {
                var sameRow = trees.Where(t => tree.z == t.z);
                tree.visibleFrom.left = !sameRow.Any(left => left.x < tree.x && left.y >= tree.y);
                tree.visibleFrom.right = !sameRow.Any(right => right.x > tree.x && right.y >= tree.y);

                var sameColumn = trees.Where(t => tree.x == t.x);
                tree.visibleFrom.up = !sameColumn.Any(up => up.z < tree.z && up.y >= tree.y);
                tree.visibleFrom.down = !sameColumn.Any(down => down.z > tree.z && down.y >= tree.y);

                if (tree.isVisible)
                    visibleTrees++;
            }
            Console.WriteLine(visibleTrees);
        }

        public void PartTwo()
        {
            int highestScore = 0;
            foreach (var tree in trees)
            {
                var sameRow = trees.Where(t => tree.z == t.z);
                var leftOrder = sameRow.Where(left => left.x < tree.x).OrderBy(t => -t.x);
                var leftTree = leftOrder.FirstOrDefault(t => t.y >= tree.y, leftOrder.LastOrDefault());
                int leftScore = leftTree != null ? (int)MathF.Abs(leftTree.x - tree.x) : 0;
                var rightOrder = sameRow.Where(right => right.x > tree.x).OrderBy(t => t.x);
                var rightTree = rightOrder.FirstOrDefault(t => t.y >= tree.y, rightOrder.LastOrDefault());
                int rightScore = rightTree != null ? (int)MathF.Abs(rightTree.x - tree.x) : 0;
                
                var sameColumn = trees.Where(t => tree.x == t.x);
                var upOrder = sameColumn.Where(up => up.z < tree.z).OrderBy(t => -t.z);
                var upTree = upOrder.FirstOrDefault(t => t.y >= tree.y, upOrder.LastOrDefault());
                int upScore = upTree != null ? (int)MathF.Abs(upTree.z - tree.z) : 0;
                var downOrder = sameColumn.Where(down => down.z > tree.z).OrderBy(t => t.z);
                var downTree = downOrder.FirstOrDefault(t => t.y >= tree.y, downOrder.LastOrDefault());
                int downScore = downTree != null ? (int)MathF.Abs(downTree.z - tree.z) : 0;

                int treeScore = leftScore * rightScore * upScore * downScore;
                if (highestScore < treeScore)
                    highestScore = treeScore;
            }
            Console.WriteLine(highestScore);
        }
    }
}
