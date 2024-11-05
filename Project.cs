using log;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace fasthw
{
    internal class Project
    {
        public string getCSFile(string taskname)
        {
            return @$"using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace {Path.GetFileName(Directory.GetCurrentDirectory()).ToLower()}
{"{"}
    internal class {taskname.Replace(" ", "")}
    {"{"}
        public void Execute()
        {"{"}
            // Write your code here
        {"}"}
    {"}"}
{"}"}";
        }
        public void Integrate()
        {
            if (Directory.GetFiles(Directory.GetCurrentDirectory(), "*.sln").Length == 0)
            {
                Log.Error("No Visual Studio project found in the current directory! Please navigate to a project");
                return;
            }
            Console.WriteLine("Enter Task's Names: (press enter to stop):");
            Dictionary<int, string> tasks = new Dictionary<int, string>();
            int i = 1;
            int alreadywasthere = 0;
            if (File.Exists(Directory.GetCurrentDirectory() + "\\fasthw\\tasks.json"))
            {
                string strjson = File.ReadAllText("fasthw/tasks.json");

                var newTasks = JsonSerializer.Deserialize<Dictionary<string, string>>(strjson);
                foreach (var kvp in newTasks)
                {
                    if (int.TryParse(kvp.Key, out int taskId))
                    {
                        tasks[taskId] = kvp.Value; // Adds or updates entries in the existing dictionary
                    }
                }
                i = tasks.Keys.Max() + 1;
                alreadywasthere = tasks.Keys.Max();
                Console.WriteLine("Tasks found already, adding new tasks");
            }
            while (true)
            {
                Console.Write($"{i}: ");
                string? task = Console.ReadLine();

                if (string.IsNullOrEmpty(task))
                {
                    break;
                }

                tasks.Add(i, task);
                i++;
            }
            Directory.CreateDirectory("fasthw");
            string filePath = "fasthw\\tasks.json";
            string jsonString = JsonSerializer.Serialize(tasks, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, jsonString);
            Log.Info("Setting up tasks...");
            foreach (var task in tasks)
            {
                if(task.Key > alreadywasthere)
                {
                    File.WriteAllText($".\\{task.Value.Replace(" ", "")}.cs", getCSFile(task.Value));
                }
            }
            Log.Success("Tasks Created");
            string program = 
@$"using {Path.GetFileName(Directory.GetCurrentDirectory()).ToLower()};

Console.WriteLine(""Homework Tasks:"");
";
            foreach (var task in tasks)
            {
                program += $@"Console.WriteLine(""{task.Key}: {task.Value}"");
";
            }
            program += @"
Console.Write(""Enter Task Number: "");
int taskNumber = int.Parse(Console.ReadLine());
Console.WriteLine();
switch (taskNumber)
{
";
            foreach (var task in tasks)
            {
                program += $@"
    case {task.Key}:
        new {task.Value.Replace(" ", "")}().Execute();
        break;
";
            }
            program += @"
    default:
        Console.WriteLine(""Invalid Task Number"");
        break;

}";
            File.WriteAllText("Program.cs", program);
            Log.Success("Program Created");
        }
    }
}
