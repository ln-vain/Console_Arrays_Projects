using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeatBookingSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // This program simulates a simple flight seat booking system.
            // It allows users to book seats in different sectors of a flight.

            // Main variables:
            int[] sectors = { 6, 30, 15, 15, 20 };
            bool isOpen = true;

            // Display the initial information about the flight and available sectors.
            while (isOpen)
            {
                Console.SetCursorPosition(0, 15);
                for (int i = 0; i < sectors.Length; i++)
                {
                    Console.WriteLine($"In sector {i + 1} there are {sectors[i]} seats available.");
                }


                // Display the menu for booking seats or exiting the program.
                Console.SetCursorPosition(0, 0);
                Console.WriteLine("Flight Registration");
                Console.WriteLine("\n\n1 - Book seats.\n\n2 - Exit the program.\n");
                Console.Write("Enter command number: ");

                // Read user input and process the command.             
                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    // Case 1 allows the user to book seats in a specific sector.
                    case 1:
                        int userSector, userPlaceAmount;

                        Console.Write("Which sector would you like to book seats in: ");
                        userSector = Convert.ToInt32(Console.ReadLine()) - 1;

                        // Check if the sector exists and if the requested number of seats is available.
                        if (sectors.Length <= userSector || userSector < 0)
                        {
                            Console.WriteLine("This sector does not exist.");
                            break;
                        }
                        // If the sector exists, prompt the user for the number of seats they want to book.
                        Console.Write("How many seats would you like to book: ");
                        userPlaceAmount = Convert.ToInt32(Console.ReadLine());
                        // Check if the requested number of seats is available in the specified sector.
                        if (sectors[userSector] < userPlaceAmount || userPlaceAmount <= 0)
                        {
                            Console.WriteLine($"Not enough seats available in sector {userSector + 1}. " +
                                $"Remaining: {sectors[userSector]} seats.");
                            break;
                        }

                        // If the requested number of seats is available, proceed with the booking.
                        // Update the number of available seats in the specified sector.
                        sectors[userSector] -= userPlaceAmount;
                        Console.WriteLine("Booking successful!");
                        break;

                    // Case 2 allows the user to exit the program.
                    case 2:
                        isOpen = false;
                        break;

                    // If the user enters an invalid option, display an error message.
                    default:
                        Console.WriteLine("Invalid option!");
                        break;
                }

                // Wait for the user to press a key before clearing the console and displaying the menu again.
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
