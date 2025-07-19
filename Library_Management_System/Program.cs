using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // Main loop control: keeps the library system running
            bool isOpen = true;

            // 2D array representing books (authors) on shelves
            string[,] books =
            {
            { "Alexander Pushkin", "Mikhail Lermontov", "Sergei Yesenin" },
            { "Robert Martin", "Jesse Schell", "Sergey Telyakov" },
            { "Stephen King", "Howard Lovecraft", "Bram Stoker" }
            };

            while (isOpen)
            {
                // Display the full list of authors at the bottom of the console
                Console.SetCursorPosition(0, 15);
                Console.WriteLine("\nFull list of authors:\n");
                for (int i = 0; i < books.GetLength(0); i++)
                {
                    for (int j = 0; j < books.GetLength(1); j++)
                    {
                        Console.Write(books[i, j] + " | ");
                    }
                    Console.WriteLine();
                }

                // Display menu and handle user input
                Console.SetCursorPosition(0, 0);
                Console.WriteLine("Library.");
                Console.WriteLine("\n1 - Find author by book index." +
                                  "\n\n2 - Search book by author.\n\n3 - Exit");
                Console.Write("Select menu option: ");

                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case 1:
                        // User selects to find author by shelf and position
                        int shelf, position;
                        Console.Write("Enter shelf number: ");
                        shelf = Convert.ToInt32(Console.ReadLine()) - 1;
                        Console.Write("Enter position number: ");
                        position = Convert.ToInt32(Console.ReadLine()) - 1;

                        // Validate input
                        if (shelf < 0 || shelf >= books.GetLength(0) || position < 0 || position >= books.GetLength(1))
                        {
                            Console.WriteLine("Invalid input.");
                            break;
                        }

                        // Display result
                        Console.WriteLine("Author: " + books[shelf, position]);
                        break;

                    case 2:
                        // User selects to search author by name
                        string author;
                        bool authorIsFound = false;

                        Console.Write("Enter author's name: ");
                        author = Console.ReadLine();

                        // Search through all shelves and positions
                        for (int i = 0; i < books.GetLength(0); i++)
                        {
                            for (int j = 0; j < books.GetLength(1); j++)
                            {
                                if (author.ToLower() == books[i, j].ToLower())
                                {
                                    Console.Write($"Author {books[i, j]} is located at: Shelf {i + 1}, Position {j + 1}. ");
                                    authorIsFound = true;
                                }
                            }
                        }

                        if (!authorIsFound)
                        {
                            Console.WriteLine("No such author found.");
                        }
                        break;

                    case 3:
                        // Exit the program
                        isOpen = false;
                        break;

                    default:
                        Console.WriteLine("Invalid command.");
                        break;
                }
                // Pause before clearing the screen
                if (isOpen)
                {
                    Console.WriteLine("\nPress any key to continue.");
                }
                Console.ReadKey();
                Console.Clear();
            }

        }
    }
}
