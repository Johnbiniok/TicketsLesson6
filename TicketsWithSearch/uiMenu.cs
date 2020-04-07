using System;

namespace TicketsFull
{
    public class uiMenu
    {
        //private TicketHandler handleTicket;
        //private Ticket userTicket;
        private string userChoice { get; set; }
        public uiMenu()
        {
           TicketHandler.FindTopId();
            do
            {
                Console.WriteLine("1. Write Tickets To File ");
                Console.WriteLine("2. Read Tickets From File ");
                Console.WriteLine("3. Search a File ");
                Console.WriteLine("4. Exit ");
                userChoice = Console.ReadLine();

                switch (userChoice)
                {
                    case "1":
                        writeFile();
                        break;
                    case "2":
                        readFile();
                        break;
                    case "3":
                        chooseSearch();
                        break;
                    case "4":
                            System.Environment.Exit(0);
                        break;
                }
            } while (!userChoice.Equals("4"));

        }

        private void writeFile()
        {
            string writeChoice;
            do
            {
                Console.WriteLine("Choose a ticket type to write");
                Console.WriteLine("1. Bug/Defect");
                Console.WriteLine("2. Enhancement");
                Console.WriteLine("3. Task");
                Console.WriteLine("4. Cancel");
                writeChoice = Console.ReadLine();


                switch (writeChoice)
                {
                    case "1":
                        TicketHandler.UserDefect();
                        break;
                    case "2":
                        TicketHandler.UserEnhancement();
                        break;
                    case "3":
                        TicketHandler.UserTask();
                        break;
                    case "4":
                        Console.WriteLine("Exiting write menu");
                        Console.WriteLine("Writing to file(s)");
                        TicketHandler.AddToFiles();
                        break;
                }
            } while (!writeChoice.Equals("4"));
        }

        private void readFile()
        {
            string readChoice;
            do
            {
                Console.WriteLine("Choose a ticket type to read");
                Console.WriteLine("1. Bug/Defect");
                Console.WriteLine("2. Enhancement");
                Console.WriteLine("3. Task");
                Console.WriteLine("4. Cancel");
                readChoice = Console.ReadLine();

            switch (readChoice)
            {
                case "1":
                    TicketHandler.ReadDefect();
                    break;
                case "2":
                    TicketHandler.ReadEnhancement();
                    break;
                case "3":
                    TicketHandler.ReadTask();
                    break;
            }
            } while (!readChoice.Equals("4"));
        }

        private void chooseSearch()
        {
            string userSearch;
            string searchTerm;
            do
            {
                Console.WriteLine("What would you like to search?");
                Console.WriteLine("1. Status");
                Console.WriteLine("3. Priority");
                Console.WriteLine("4. Submitter");
                userSearch = Console.ReadLine();
            } while (!userSearch.Equals("1") && !userSearch.Equals("3") && !userSearch.Equals("4"));
            Console.WriteLine("What would you like to search for?");
            searchTerm = Console.ReadLine();
            TicketHandler.SearchFiles(userSearch, searchTerm);
        }

    }
}