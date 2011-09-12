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
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
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
                        logger.Debug("Processing {0}", s);
                        processFile(s);
                    }

                    using (FileSystemWatcher fw = new FileSystemWatcher(directory, "*.txt"))
                    {
                        fw.Created += new FileSystemEventHandler(fw_Created);
                        fw.EnableRaisingEvents = true;
                        Console.WriteLine("Watching {0}", directory);
                        logger.Debug("Wating {0} for new files", directory);
                        Console.WriteLine("hit enter to kill");
                        Console.ReadLine();
                    }
                    
                }
                else
                {
                    logger.Error("Directory does not exist... cant watch something that dont exist");
                }
            }
            else
            {
                logger.Warn("Need param: Directory name to watch and Repo Location");
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
                logger.Debug("Creating {0}", tempDir);
                Directory.CreateDirectory(tempDir);
            }
            //Todo: this is not fully working at the moment... Need to make some fixes...
            


            //todo: move the output directory to a new folder...
            //todo: If the config says this is a website (some time soon) create a Web Deployment Package. maybe add option to actually deploy to IIS?
            File.Delete(p);
        }

    }
}
