using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AdventOfCode2018.DaySeven
{
    public class TaskOrdering
    {
        public string[] Lines { get; private set; }
        public Dictionary<string, List<string>> Dependencies { get; set; }
        public Dictionary<string, List<string>> DependsOn { get; set; }

        public TaskOrdering() { }

        public TaskOrdering(string[] lines)
        {
            Lines = lines;
            BuildDependencies();
        }

        public TaskOrdering(string filePath)
        {
            Lines = System.IO.File.ReadAllLines(filePath);
            BuildDependencies();
        }

        private void BuildDependencies()
        {
            Dependencies = new Dictionary<string, List<string>>();
            DependsOn = new Dictionary<string, List<string>>();

            foreach (var line in Lines)
            {
                string[] tokens = line.Split();
                
                if (Dependencies.ContainsKey(tokens[1]))
                {
                    Dependencies[tokens[1]].Add(tokens[7]);
                }
                else
                {
                    Dependencies.Add(tokens[1], new List<string>
                    {
                        tokens[7]
                    });
                }

                if (DependsOn.ContainsKey(tokens[7]))
                {
                    DependsOn[tokens[7]].Add(tokens[1]);
                }
                else
                {
                    DependsOn.Add(tokens[7], new List<string>
                    {
                        tokens[1]
                    });
                }
            }
        }

        public int PartTwo(string answer, int workers, int baseCost)
        {
            string index = " ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            List<string> toBeDone = GetTasksToBeDone(answer);
            bool isDone = toBeDone.Count == 0;
            int seconds = 0;
            List<bool> workerList = new List<bool>();
            List<Task> currentTasks = new List<Task>();

            for (int i = 0; i < workers; i++)
            {
                workerList.Add(false);
            }

            while (!isDone)
            {
                List<Task> canBeStarted = new List<Task>();

                // Find tasks that can be done.
                foreach (var t in toBeDone)
                {
                    if (!HasDependenciesToBeCompleted(t, toBeDone) && !currentTasks.Any(ta => ta.Name == t))
                    {
                        canBeStarted.Add(new Task(t, index.IndexOf(t) + baseCost));
                    }
                }

                // Handle Work Assignment.
                while (workerList.Any(w => !w) && canBeStarted.Count > 0)
                {
                    var task = canBeStarted[0];
                    canBeStarted.Remove(task);

                    for (int i = 0; i < workerList.Count; i++)
                    {
                        if (!workerList[i])
                        {
                            workerList[i] = true;
                            task.WorkerIndex = i;
                            break;
                        }
                    }

                    currentTasks.Add(task);
                }

                seconds++;

                // Handle Update.
                for (int i = 0; i < currentTasks.Count; i++)
                {

                    currentTasks[i].DropTime();

                    if (currentTasks[i].IsComplete)
                    {
                        
                        toBeDone.Remove(currentTasks[i].Name);
                        workerList[(int)currentTasks[i].WorkerIndex] = false;
                        currentTasks.Remove(currentTasks[i]);
                        i--;
                    }
                }

                isDone = toBeDone.Count == 0;
            }

            return seconds;
        }

        private List<string> GetTasksToBeDone(string s)
        {
            var toBeDone = new List<string>();

            foreach (var c in s)
            {
                toBeDone.Add(c.ToString());
            }

            return toBeDone;
        }

        private bool HasDependenciesToBeCompleted(string s, List<string> toBeDone)
        {
            if (!DependsOn.ContainsKey(s)) return false;

            foreach (var task in DependsOn[s])
            {
                if (toBeDone.Contains(task)) return true;
            }

            return false;
        }

        public string GetStringOrder()
        {
            var sb = new StringBuilder();
            var candidates = Dependencies.Keys.ToList<string>();

            foreach (var kvp in Dependencies)
            {
                foreach (var d in kvp.Value)
                {
                    if (candidates.Contains(d))
                    {
                        candidates.Remove(d);
                    }
                }
            }

            candidates.Sort();

            while (candidates.Count > 0)
            {
                sb.Append(candidates[0]);

                if (Dependencies.ContainsKey(candidates[0]))
                {
                    foreach (var d in Dependencies[candidates[0]])
                    {
                        // go through each dependency and see if it depends on others and it's not in sb.tostring.
                        bool dependsOnOthers = false;
                        List<string> dependsOn = new List<string>();

                        foreach (var kvp in Dependencies)
                        {
                            if (kvp.Value.Contains(d))
                            {
                                dependsOnOthers = true;
                                dependsOn.Add(kvp.Key);
                            }
                        }

                        if (!dependsOnOthers) candidates.Add(d);
                        else
                        {
                            string temp = sb.ToString();
                            bool allDepsHit = true;

                            foreach (var s in dependsOn)
                            {
                                if (!temp.Contains(s)) allDepsHit = false;
                            }

                            if (allDepsHit) candidates.Add(d);
                        }
                    }
                    //candidates.AddRange(Dependencies[candidates[0]]);
                }
                
                candidates.RemoveAll(c => c == candidates[0]);
                candidates.Sort();                
            }

            return sb.ToString();
        }
    }
}
