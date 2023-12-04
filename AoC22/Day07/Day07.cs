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
        public enum FileType { directory, file }
        public class Node
        {
            public FileType fileType;
            public string name = "";
            public int size = 0;
            public Node parentNode = null;
            public List<Node> dirChildren = new List<Node>();
        }

        public Node rootNode = new Node() { fileType = FileType.directory, name = "/" }; // Cool inline constructor but happens after the actual constructor
        public Node currentNode;
        public HashSet<Node> allDirectories = new(); // If you add the same instance of something, it wont add, basically dictionary but without value pair
        
        public Dictionary<string, Action> commands = new(); // Needs to init only after the class is instantiated
        public string[] currentString = Array.Empty<string>();
        public int currentReadInput = 0;

        readonly List<string> input = new();
        readonly List<string> inputCommands = new();
        public Day07(string file)
        {
            currentNode = rootNode;
            var lines = File.ReadAllLines(file);
            input.AddRange(lines.ToList());
            inputCommands.AddRange(lines.Where(l => l.StartsWith("$")).ToList());

            commands.Add("$", NewCommand);
            commands.Add("cd", ChangeDirectory);
            commands.Add("ls", ListDirectory);
        }
        public void NewCommand()
        {
            currentReadInput++;
            commands[currentString[1]]();
        }
        public void ChangeDirectory()
        {
            string selectDir = currentString.Last();
            switch (selectDir)
            {
                case "/":
                    //switch back to main directory
                    currentNode = rootNode;
                    break;
                case "..":
                    //goes up 1 level
                    currentNode = currentNode.parentNode;
                    break;
                default:
                    //goes in 1 level into specified dictionary
                    currentNode = currentNode.dirChildren
                        .Where(n => n.fileType == FileType.directory)
                        .First(n => n.name == selectDir); // (n => bool) predicate asks for type bool
                    break;
            }
        }
        public void ListDirectory()
        {
            int dirLength = 0;
            int startingReadInput = currentReadInput;
            while (currentReadInput < input.Count && !input[currentReadInput].StartsWith("$"))
            {
                dirLength++;
                currentReadInput++;
            }
            for (int i = 0; i < dirLength; i++)
            {
                string[] listDir = input[startingReadInput + i].Split(" ");
                if (int.TryParse(listDir[0], out int fileSize)) // If readinput is a file
                    currentNode.dirChildren.Add(new Node() { fileType = FileType.file, name = listDir.Last(), parentNode = currentNode, size = fileSize });
                if (listDir[0] == "dir") // If readinput is a sub-directory
                    currentNode.dirChildren.Add(new Node() { fileType = FileType.directory, name = listDir.Last(), parentNode = currentNode });
            }
        }
        /// <summary>
        /// Tree traversal fucky wucky
        /// </summary>
        /// <param name="node">The node to traverse recursively </param>
        public void LoadNodes(Node node)
        {
            if (node.fileType == FileType.file) return; // Base case to break the recursion
            foreach (var child in node.dirChildren)
                LoadNodes(child);
            node.size = node.dirChildren.Sum(d => d.size); // Sum the results of the children that has recursed
            allDirectories.Add(node);
        }

        public void PartOne()
        {
            for (int i = 0; i < inputCommands.Count; i++)
            {
                currentString = (string[])inputCommands[i].Split(" ").Clone();
                NewCommand();
            }
            LoadNodes(rootNode);
            int maxSize = 100000;
            int totalSize = 0;
            foreach (var directory in allDirectories)
            {
                if (directory.size < maxSize)
                    totalSize += directory.size;
            }
            Console.WriteLine(totalSize);
        }
        public void PartTwo()
        {
            int totalSpace = 70000000;
            int spaceRequired = 30000000;
            int spaceAvailable = totalSpace - rootNode.size;
            int spaceToYeet = spaceRequired - spaceAvailable;
            Node nodeToYeet = allDirectories.Where(n => n.size > spaceToYeet).OrderBy(a => a.size).First();
            Console.WriteLine(nodeToYeet.size);
        }
    }
}
