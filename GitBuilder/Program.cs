using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using GitSharp;


namespace GitBuilder
{
    class Program
    {
        static string directory;
        static string repoistory; 

        static void Main(string[] args)
        {
            if (args.Count() == 2)
            {
                 directory = args[0];
                 repoistory = args[1];
                if (Directory.Exists(directory))
                {
                    foreach (string s in Directory.GetFiles(directory, "*.txt"))
                    {
                        processFile(s);
                    }

                    using (FileSystemWatcher fw = new FileSystemWatcher(directory, "*.txt"))
                    {
                        fw.Created += new FileSystemEventHandler(fw_Created);
                        fw.EnableRaisingEvents = true;
                        Console.WriteLine("Watching {0}", directory);
                        Console.WriteLine("hit enter to kill");
                        Console.ReadLine();
                    }
                    
                }
                else
                {
                    Console.WriteLine("Directory does not exist... cant watch something that dont exist");
                }
            }
            else
            {
                Console.WriteLine("Need param: Directory name to watch and Repo Location");
            }
        }

        static void fw_Created(object sender, FileSystemEventArgs e)
        {
            processFile(e.FullPath);
        }

        private static void processFile(string p)
        {
            Console.WriteLine("the file {0} was created", p);
            string contents = File.ReadAllText(p);
            string tempDir = Path.Combine(@"c:\temp", Guid.NewGuid().ToString());
            if (!Directory.Exists(tempDir))
            {
                Directory.CreateDirectory(tempDir);
            }
            //var repo =  GitSharp.Git.Clone(new GitSharp.Commands.CloneCommand() { GitDirectory = repoistory, Directory = tempDir });
            GitSharp.Commands.CheckoutCommand checkout = new GitSharp.Commands.CheckoutCommand() { Arguments = new List<string>() { contents, "-f" }, Repository = Git.Clone(repoistory, tempDir) };
            checkout.Execute();
        }

    }
}
