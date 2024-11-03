using LibraryManagementSystem.Interfaces;
using LibraryManagementSystem.Managers;
using LibraryManagementSystem.Media;
using LibraryManagementSystem.Notifications;
using LibraryManagementSystem.Payments;
using System;
using System.Collections.Generic;

namespace LibraryManagementSystem
{
    public class Program
    {
        public static void Main(string[] args)


        {


            // managers and services
            INotifier emailNotifier = new EmailNotification();
            INotifier smsNotifier = new SMSNotification();
            FinePaymentManager finePaymentManager = new FinePaymentManager();
            AccountManager accountManager = new AccountManager();
            ReservationManager reservationManager = new ReservationManager();
            ReservationFactory reservationFactory = new ReservationFactory();
            ReservationNotifier reservationNotifier = new ReservationNotifier();

            //  for reservation status changes
            reservationNotifier.ReservationStatusChanged += (status) =>
            {
                Console.WriteLine($"Reservation status changed to: {status}");
            };

            // create users
            User user1 = new UserAccount()
                .UserName("Ella Charles")
                .UserEmail("ella.charles@example.com")
                .UserPhone("204-123-4567")
                .UserPassword("HYUEU45jk")
                .UserCreate();
            accountManager.AddUser(user1);

            User user2 = new UserAccount()
                .UserName("Adeola Yusuf")
                .UserEmail("adeola.yusuf@example.com")
                .UserPhone("204-891-0112")
                .UserPassword("babyShark123")
                .UserCreate();
            accountManager.AddUser(user2);

            // create media items
            IMedia book1 = new Books("J.K. Rowling", "Harry Potter", "Fantasy", 1, 500, DateOnly.FromDateTime(DateTime.Now).AddDays(30), "Book", 20.00m, emailNotifier);
            IMedia dvd1 = new DVD("Christopher Nolan", "Inception", "Sci-Fi", 1, "DVD", DateOnly.FromDateTime(DateTime.Now).AddDays(30), 15.00m, smsNotifier);
            List<IMedia> books = new List<IMedia> { book1 };
            List<IMedia> dvds = new List<IMedia> { dvd1 };

            bool isRunning = true;

            while (isRunning)
            {
                // Main menu display
                Console.WriteLine("\nLibrary Management System");
                Console.WriteLine("1. Loan a Book");
                Console.WriteLine("2. Loan a DVD");
                Console.WriteLine("3. Pay Fine");
                Console.WriteLine("4. Create a Reservation");
                Console.WriteLine("5. Cancel a Reservation");
                Console.WriteLine("6. Exit");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        // Display books for loaning
                        Console.WriteLine("Books:");
                        for (int i = 0; i < books.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {books[i].Title}");
                        }
                        Console.Write("Select the book to loan: ");
                        int bookChoice = int.Parse(Console.ReadLine());
                        books[bookChoice - 1].Loan();
                        break;

                    case "2":
                        // Display DVDs for loaning
                        Console.WriteLine("DVDs:");
                        for (int i = 0; i < dvds.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {dvds[i].Title}");
                        }
                        Console.Write("Select the DVD to loan: ");
                        int dvdChoice = int.Parse(Console.ReadLine());
                        dvds[dvdChoice - 1].Loan();
                        break;

                    case "3":
                        Console.WriteLine("Fine payment logic here.");
                        break;

                    case "4":
                        // reservation
                        Console.WriteLine("Select the media type for reservation:");
                        Console.WriteLine("1. Book");
                        Console.WriteLine("2. DVD");

                        string mediaTypeInput = Console.ReadLine();
                        List<IMedia> mediaList = mediaTypeInput switch
                        {
                            "1" => books,
                            "2" => dvds,
                            _ => new List<IMedia>()
                        };

                        if (mediaList.Count > 0)
                        {
                            for (int i = 0; i < mediaList.Count; i++)
                            {
                                Console.WriteLine($"{i + 1}. {mediaList[i].Title}");
                            }

                            Console.Write("Select an item to reserve: ");
                            int reserveChoice = int.Parse(Console.ReadLine());
                            IMedia selectedMedia = mediaList[reserveChoice - 1];

                            // create and add reservation
                            BaseReservation newReservation = (BaseReservation)reservationFactory.CreateReservation(user1, selectedMedia);
                            reservationManager.AddReservation(newReservation);
                            Console.WriteLine($"Reservation created for '{selectedMedia.Title}' for user '{user1.Name}'.");
                        }
                        else
                        {
                            Console.WriteLine("Invalid media type selection.");
                        }
                        break;

                    case "5":
                        Console.WriteLine("Cancel reservation logic here.");
                        break;

                    case "6":
                        isRunning = false;
                        break;

                    default:
                        Console.WriteLine("Invalid option, please try again.");
                        break;
                }
            }
        }
    }
}
