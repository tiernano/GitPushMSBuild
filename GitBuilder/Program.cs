using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace GitBuilder
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Count() > 0)
            {
                string directory = args[0];
                if (Directory.Exists(directory))
                {
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
                Console.WriteLine("Need param: Directory name to watch");
            }
        }

        static void fw_Created(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine("the file {0} was created", e.FullPath);
        }

    }
}
