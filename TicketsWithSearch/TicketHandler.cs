using System;
using System.Collections.Generic;
using System.IO;
using TicketsFull.Tickets;
using Task = System.Threading.Tasks.Task;

namespace TicketsFull
{
    public abstract class TicketHandler
    {
        //start a
        //private Ticket userTicket;
        private static int _ticketId = 0;
        private static string taskFile = @"Tasks.csv";
        private static string enhancementFile = @"Enhancements.csv";
        private static string defectFile = @"Defects.csv";
        private static List<string> fileList = new List<string>(){@"Tasks.csv",@"Enhancements.csv",@"Defects.csv"};

        //lets gather em in some lists
        static List<Tickets.Task> taskList = new List<Tickets.Task>();
        static List<Debug> defectList = new List<Debug>();
        static List<Enhancement> enhancementList = new List<Enhancement>();

        public static void UserTask()
        {
            _ticketId++;
            Tickets.Task userTicket = new Tickets.Task {ticketId = _ticketId};
            Console.Write("Enter a summary: ");
            userTicket.summary = Console.ReadLine();
            Console.Write("Enter a status: ");
            userTicket.status = Console.ReadLine();
            Console.Write("Enter priority: ");
            userTicket.priority = Console.ReadLine();
            Console.Write("Enter submitter name: ");
            userTicket.submitter = Console.ReadLine();
            Console.Write("Names of assigned: ");
            userTicket.assigned = Console.ReadLine();
            Console.Write("Name of watching: ");
            userTicket.watching = Console.ReadLine();
            Console.Write("Enter Project Name: ");
            userTicket.projectName = Console.ReadLine();
            Console.Write("Enter Due Date: ");
            userTicket.dueDate = Console.ReadLine();
            taskList.Add(userTicket);
        }

        public static void UserEnhancement()
        {
            _ticketId++;
            Enhancement userTicket = new Enhancement();
            userTicket.ticketId = _ticketId;
            Console.Write("Enter a summary: ");
            userTicket.summary = Console.ReadLine();
            Console.Write("Enter a status: ");
            userTicket.status = Console.ReadLine();
            Console.Write("Enter priority: ");
            userTicket.priority = Console.ReadLine();
            Console.Write("Enter submitter name: ");
            userTicket.submitter = Console.ReadLine();
            Console.Write("Names of assigned: ");
            userTicket.assigned = Console.ReadLine();
            Console.Write("Name of watching: ");
            userTicket.watching = Console.ReadLine();
            Console.Write("Enter Software: ");
            userTicket.software = Console.ReadLine();
            Console.Write("Cost: ");
            userTicket.cost = Console.Read();
            Console.Write("Reason: ");
            userTicket.reason = Console.ReadLine();
            Console.Write("Estimate: ");
            userTicket.estimate = Console.Read();
            enhancementList.Add(userTicket);
        }

        public static void UserDefect()
        {
            _ticketId++;
            Debug userTicket = new Debug();
            userTicket.ticketId = _ticketId;
            Console.Write("Enter a summary: ");
            userTicket.summary = Console.ReadLine();
            Console.Write("Enter a status: ");
            userTicket.status = Console.ReadLine();
            Console.Write("Enter priority: ");
            userTicket.priority = Console.ReadLine();
            Console.Write("Enter submitter name: ");
            userTicket.submitter = Console.ReadLine();
            Console.Write("Names of assigned: ");
            userTicket.assigned = Console.ReadLine();
            Console.Write("Name of watching: ");
            userTicket.watching = Console.ReadLine();
            Console.Write("Enter Severity: ");
            userTicket.severity = Console.ReadLine();
            defectList.Add(userTicket);
        }

        public static void AddToFiles()
        {
            if (taskList.Count > 0)
            {
                using (FileStream fs = new FileStream(taskFile, FileMode.Append, FileAccess.Write))
                {
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        for (int i = 0; i < taskList.Count; i++)
                        {
                            sw.WriteLine(taskList[i]);
                        }
                    }
                }
            }

            if (enhancementList.Count > 0)
            {
                using (FileStream fs = new FileStream(enhancementFile, FileMode.Append, FileAccess.Write))
                {
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        for (int i = 0; i < enhancementList.Count; i++)
                        {
                            sw.WriteLine(enhancementList[i]);
                        }
                    }
                }
            }

            if (defectList.Count > 0)
            {
                using (FileStream fs = new FileStream(defectFile, FileMode.Append, FileAccess.Write))
                {
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        for (int i = 0; i < defectList.Count; i++)
                        {
                            sw.WriteLine(defectList[i]);
                        }
                    }
                }
            }
        }

        public static void ReadDefect()
        {
            using (StreamReader sr = new StreamReader(defectFile))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    // convert string to array
                    string[] arr = line.Split(',');
                    // display array data
                    Console.WriteLine(
                        "{0, -10}{1, -25}{2, -10}{3, -10}{4, -10}{5, -15}{6, -10}{7, -10}",
                        arr[0], arr[1], arr[2], arr[3], arr[4], arr[5], arr[6], arr[7]);

                }
            }
        }

        public static void ReadEnhancement()
        {
            using (StreamReader sr = new StreamReader(enhancementFile))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    // convert string to array
                    string[] arr = line.Split(',');
                    // display array data
                    Console.WriteLine(
                        "{0, -10}{1, -25}{2, -10}{3, -10}{4, -10}{5, -15}{6, -10}{7, -10}{8, -10}{9, -10}{10, -10}",
                        arr[0], arr[1], arr[2], arr[3], arr[4], arr[5], arr[6], arr[7], arr[8], arr[9], arr[10]);

                }
            }
        }

        public static void ReadTask()
        {
            using (StreamReader sr = new StreamReader(taskFile))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    // convert string to array
                    string[] arr = line.Split(',');
                    // display array data
                    Console.WriteLine(
                        "{0, -10}{1, -25}{2, -10}{3, -10}{4, -10}{5, -15}{6, -10}{7, -10}{8, -10}",
                        arr[0], arr[1], arr[2], arr[3], arr[4], arr[5], arr[6], arr[7], arr[8]);

                }
            }
        }

        public static void SearchFiles(string userSearch, string searchTerm)
        {
            int counter = 0;
            foreach (var g in fileList)
            {
                using (StreamReader sr = new StreamReader(g))
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        // convert string to array
                        string[] arr = line.Split(',');
                        if (arr[int.Parse(userSearch)].Contains(searchTerm))
                        {
                            counter++;
                            Console.WriteLine(line);
                        }
                    }
                }
            }
            Console.WriteLine("There were " + counter + " results returned by the search!");
        }


        public static void FindTopId()
        {
            using (StreamReader sr = new StreamReader(taskFile))
            {
                while (sr.ReadLine() != null)
                {
                    _ticketId++;
                }
            }
            using (StreamReader sr = new StreamReader(enhancementFile))
            {
                while (sr.ReadLine() != null)
                {
                    _ticketId++;
                }
            }
            using (StreamReader sr = new StreamReader(defectFile))
            {
                while (sr.ReadLine() != null)
                {
                    _ticketId++;
                }
            }
        }
    }
}