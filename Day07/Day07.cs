using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCock
{
    internal class Day07 : IDay
    {
        public Dictionary<string, int> Directory = new()
        {
            {"/", 0}, {"..", CurrentBranch}
        };
        public Dictionary<string, RunActions> Commands = new()
        {
            {"$", RunActions.NewCommand}, {"cd", RunActions.ChangeDirectory}, {"ls", RunActions.ListDirectory}
        };
        public enum RunActions
        {
            NewCommand, ChangeDirectory, ListDirectory
        };
        public Dictionary<string, int> Files = new();
        public string[] CurrentString = Array.Empty<string>();
        public int CurrentAction = 0;
        public static int CurrentBranch = 0;
        public int CurrentReadInput = 0;
        readonly List<string> input = new();
        readonly List<string> inputCommands = new();
        readonly int maxSize = 100000;
        public Day07(string file)
        {
            var lines = File.ReadAllLines(file);
            input.AddRange(lines.ToList());
            inputCommands.AddRange(lines.Where(l => l.StartsWith("$")).ToList());
        }
        public void RunCommand()
        {
            switch (Commands[CurrentString[CurrentAction]])
            {
                case RunActions.NewCommand:
                    NewCommand();
                    break;
                case RunActions.ChangeDirectory:
                    ChangeDirectory();
                    break;
                case RunActions.ListDirectory:
                    ListDirectory();
                    break;
            }
        }
        public void NewCommand()
        {
            CurrentAction = 1;
            CurrentReadInput++;
            RunCommand();
        }
        public void ChangeDirectory()
        {
            string selectDir = CurrentString[CurrentAction + 1];
            switch (selectDir)
            {
                case "/":
                    //switch back to main directory
                    CurrentBranch = 0;
                    break;
                case "..":
                    //goes up 1 level
                    CurrentBranch--;
                    break;
                default:
                    //goes in 1 level into specified dictionary
                    CurrentBranch++;
                    if (!Directory.ContainsKey(selectDir))
                        Directory.Add(selectDir, CurrentBranch);
                    break;
            }
        }
        public void ListDirectory()
        {
            CurrentReadInput++;
            int dirLength = 1;
            while (input[CurrentReadInput].StartsWith("$") && CurrentReadInput < input.Count)
            {
                dirLength++;
                CurrentReadInput++;
            }
            int branchSize = 0;
            int dirSize = 0;
            for (int i = dirLength - 1; i >= 0; i--)
            {
                string[] listDir = input[CurrentReadInput].Split(" ");
                if (listDir[0] == "dir")
                {
                    Files.Add(listDir[1], dirSize); // Probably need to fix this
                }
                if (int.TryParse(listDir[0], out int fileSize))
                {
                    dirSize += fileSize;
                    branchSize += fileSize;
                }
                if (i == 0) // will break if end of loop is not "dir x"
                    Files.Add(listDir[1], branchSize); // Probably need to fix this
            }
        }
        public void Reset()
        {
            CurrentString = Array.Empty<string>();
            CurrentAction = 0;
            CurrentBranch = 0;
            CurrentReadInput = 0;
        }
        public void PartOne()
        {
            for (int i = 0; i < inputCommands.Count; i++)
            {
                CurrentString = (string[])inputCommands[i].Split(" ").Clone();
                RunCommand();
            }
            int highest = 0;
            foreach (var item in Files)
            {
                if (highest < item.Value && item.Value < maxSize)
                    highest = item.Value;
            }
            Console.WriteLine(highest);
        }

        public void PartTwo()
        {
        }
    }
}
