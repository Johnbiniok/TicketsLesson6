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
        private static string[] fileList = new string[3]{@"Tasks.csv",@"Enhancements.csv",@"Defects.csv"};

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

        public static void searchFiles(string userSearch)
        {
            string searchResults = new List<string>();
            string totalTickets = "";
            for (int i = 0; i < 3; i++)
            {
                totalTickets += File.ReadAllLines(fileList[i]);
            }

            for (int i = 0; i < 3; i++)
            {
                foreach (string correctLine in totalTickets.Split('\n'))
                {
                    if (!string.IsNullOrEmpty(correctLine))
                    {
                        bool found = false;
                        foreach (var matches in correctLine.Split(','))
                        {
                            bool findMatch = matches.ToUpper().Contains(userSearch.ToUpper());
                            if (findMatch)
                            {
                                found = true;
                                break;
                            }
                        }

                        if (found)
                        {
                            searchResults.Add(correctLine);
                        }
                    }
                }
            }

            for (int i = 0; i < searchResults.Count; i++)
            {
                Console.WriteLine(searchResults[i]);
            }
        }

        /* var file1Lines = File.ReadAllText(@"Tasks.csv");
         var file2Lines = File.ReadAllText(@"Enhancements.csv");
         var file3Lines = File.ReadAllText(@"Defects.csv");

         foreach (string correctLine in file1Lines.Split('\n'))
         {
             if (!string.IsNullOrEmpty(correctLine))
             {
                 bool found = false;
                 foreach (var matches in correctLine.Split(','))
                 {
                     bool findMatch = matches.ToUpper().Contains(userSearch.ToUpper());
                     if (findMatch)
                     {
                         found = true;
                         break;
                     }
                 }

                 if (found)
                 {
                     searchResults.Add(correctLine);
                 }
             }
         }
         foreach (string correctLine in file2Lines.Split('\n'))
         {
             if (!string.IsNullOrEmpty(correctLine))
             {
                 bool found = false;
                 foreach (var matches in correctLine.Split(','))
                 {
                     bool findMatch = matches.ToUpper().Contains(userSearch.ToUpper());
                     if (findMatch)
                     {
                         found = true;
                         break;
                     }
                 }

                 if (found)
                 {
                     searchResults.Add(correctLine);
                 }
             }
         }*/
            // var splitLine = correctLine.Split(new char[] {','});
            //if(correctLine.Split(','[1]).Equals(userSearch))
       // }

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