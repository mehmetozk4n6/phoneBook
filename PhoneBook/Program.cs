using System;
using System.Collections.Generic;
using System.Linq;

namespace PhoneBook
{
    class Program
    {
        static void Main(string[] args)
        {
            Records records = new Records();
            while (true)
            {
                Console.Write("     1-Add");
                Console.Write("     2-Delete");
                Console.Write("     3-Update");
                Console.Write("     4-List Records");
                Console.Write("     5-Search");
                Console.Write("     6-Exit");
                Console.WriteLine(" ");
                string choice = Console.ReadLine();
                if (choice == "1")
                {
                    Console.Write("Name   : ");
                    string name = Console.ReadLine();
                    Console.Write("Number : ");
                    long number = long.Parse(Console.ReadLine());
                    records.recordAdd(name, number);
                }else if (choice == "2")
                {
                    Console.Write("Name   : ");
                    string name = Console.ReadLine();
                    records.recordDelete(name);
                }
                else if (choice == "3")
                {
                    Console.Write("Name   : ");
                    string name = Console.ReadLine();
                    Console.Write("Number : ");
                    long number = long.Parse(Console.ReadLine());
                    records.recordUpdate(name, number);
                }else if(choice == "4")
                {
                    Console.Write("     1-Sort");
                    Console.Write("     2-Reverse");
                    Console.WriteLine(" ");
                    Console.Write("Sorted Type : ");
                    string listChoice = Console.ReadLine();
                    if (listChoice == "1")
                    {
                        records.listRecords(true);
                    }else if(listChoice == "2")
                    {
                        records.listRecords(false);
                    }
                    else
                    {
                        Console.WriteLine("Wrong input!!"); 
                    }
                }
                else if (choice == "5")
                {
                    Console.Write("Search Value  : ");
                    string searchVal = Console.ReadLine();
                    records.recordSearch(searchVal);
                }
                else if (choice == "6")
                {
                    Console.WriteLine("Exit");
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong Input!!");
                }
            }

            Console.ReadLine();
        }
    }

    class Records
    {

        private static Dictionary<string,long> book = new Dictionary<string,long>();

        public Records()
        {
        }

        public void recordAdd(string name,long number)
        {
            book.Add(name, number);
            Console.WriteLine("{0} {1} has been added successfully.", name, number);
        }

        public void recordDelete(string name)
        {
            book.Remove(name);
            Console.WriteLine("{0} has been deleted.", name);
        }
        public void recordUpdate(string name, long number)
        {
            book[name] = number;
            Console.WriteLine("{0} {1} has been updated.", name, number);
        }
        public void listRecords(bool choice)
        {
            Console.WriteLine("Name              Number");
            foreach(var item in choice?book.OrderBy(el=>el.Key):book.OrderBy(el => el.Key).Reverse())
            {
                Console.WriteLine("{0}      => {1}", item.Key, item.Value);
            }
        }
        public void recordSearch(string searchVal)
        {
            bool notFound = true;
            foreach(var item in book)
            {
                if (item.Key.Contains(searchVal))
                {
                    Console.WriteLine("{0} {1}",item.Key,item.Value);
                    notFound = false;
                }
            }
            if (notFound)
            {
                Console.WriteLine("No record found!");
            }
        }
 
        

    }
}
