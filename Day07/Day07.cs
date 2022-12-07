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
        public static Dictionary<string, int> Directory = new()
        {
            {"/", 0}, {"..", CurrentBranch}
        };
        public static Dictionary<string, Action> Commands = new()
        {
            {"$", NewCommand}, {"cd", ChangeDirectory}, {"ls", ListDirectory}
        };
        public static Dictionary<string, int> Files = new();
        public static string[] CurrentString = Array.Empty<string>();
        public static int CurrentAction = 0;
        public static int CurrentBranch = 0;
        public static Action RunCommand = Commands[CurrentString[CurrentAction]];
        public static int CurrentReadInput = 0;
        readonly static List<string> input = new();
        readonly static List<string> inputCommands = new();
        readonly static int maxSize = 100000;
        public Day07(string file)
        {
            var lines = File.ReadAllLines(file);
            input.AddRange(lines.ToList());
            inputCommands.AddRange(lines.Where(l => l.StartsWith("$")).ToList());
        }
        public static void NewCommand()
        {
            CurrentAction = 1;
            CurrentReadInput++;
            RunCommand();
        }
        public static void ChangeDirectory()
        {
            CurrentAction++;
            string selectDir = CurrentString[CurrentAction];
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
            RunCommand();
        }
        public static void ListDirectory()
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
                    Files.Add(listDir[1], dirSize);
                }
                if (int.TryParse(listDir[0], out int fileSize))
                {
                    dirSize += fileSize;
                    branchSize += fileSize;
                }
                if (i == 0) // will break if end of loop is not "dir x"
                    Files.Add(listDir[0], branchSize); // Overrides value of directory since its a dictionary
            }
        }
        public static void Reset()
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
            Console.WriteLine(Files["/"]);
        }

        public void PartTwo()
        {
        }
    }
}
