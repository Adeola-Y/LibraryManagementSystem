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
            // Create managers and notifiers
            INotifier emailNotifier = new EmailNotification();
            INotifier smsNotifier = new SMSNotification();
            FinePaymentManager finePaymentManager = new FinePaymentManager();
            AccountManager accountManager = new AccountManager();
            ReservationManager reservationManager = new ReservationManager();

            // Create user accounts
            User user1 = new UserAccount()
                .UserName("Ella Charles")
                .UserEmail("ella.charles@example.com")
                .UserPhone("204-123-4567")
                .UserPassword("HYUEU45jk")
                .UserCreate();

            Console.WriteLine("Adding user1:");
            accountManager.AddUser(user1);

            User user2 = new UserAccount()
                .UserName("Adeola Yusuf")
                .UserEmail("adeola.yusuf@example.com")
                .UserPhone("204-891-0112")
                .UserPassword("babyShark123")
                .UserCreate();

            Console.WriteLine("Adding user2:");
            accountManager.AddUser(user2);

            // Media
            IMedia book1 = new Books("J.K. Rowling", "Harry Potter", "Fantasy", 1, 500, DateOnly.FromDateTime(DateTime.Now).AddDays(30), "Book", 20.00m, emailNotifier);
            IMedia book2 = new Books("Robert Munsch", "Love You Forever", "Children Literature", 2, 500, DateOnly.FromDateTime(DateTime.Now).AddDays(30), "Book", 20.00m, emailNotifier);
            IMedia dvd1 = new DVD("Christopher Nolan", "Inception", "Sci-Fi", 1, "DVD", DateOnly.FromDateTime(DateTime.Now).AddDays(30), 15.00m, smsNotifier);
            IMedia dvd2 = new DVD("Greta Gerwig", "Barbie", "Drama", 2, "DVD", DateOnly.FromDateTime(DateTime.Now).AddDays(30), 18.00m, smsNotifier);
            IMedia magazine1 = new Magazines("Time Magazine", "Current Events", "Time Inc.", 1, "Magazine", DateOnly.FromDateTime(DateTime.Now).AddDays(30), 12.00m, emailNotifier);
            IMedia magazine2 = new Magazines("Vogue", "Fashion", "Vogue", 2, "Magazine", DateOnly.FromDateTime(DateTime.Now).AddDays(30), 10.00m, emailNotifier);

            List<IMedia> books = new List<IMedia> { book1, book2 };
            List<IMedia> dvds = new List<IMedia> { dvd1, dvd2 };
            List<IMedia> magazines = new List<IMedia> { magazine1, magazine2 };

            Console.WriteLine("Creating a reservation for book1:");
            BaseReservation bookReservation = new BaseReservation(user1, book1);
            reservationManager.AddReservation(bookReservation);
            Console.WriteLine($"Reservation made for {user1.Name} on book '{book1.Title}'");

            Console.WriteLine("Completing book reservation for user1:");
            reservationManager.CompleteReservation(bookReservation);
            Console.WriteLine($"Reservation status for '{book1.Title}': {bookReservation.Status}");

            bool isRunning = true;

            while (isRunning)
            {
                Console.WriteLine("\nLibrary Management System");
                Console.WriteLine("1. Loan a Book");
                Console.WriteLine("2. Loan a DVD");
                Console.WriteLine("3. Loan a Magazine");
                Console.WriteLine("4. Pay Fine");
                Console.WriteLine("5. Manage Reservations"); // New option for managing reservations
                Console.WriteLine("6. Exit");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Books:");
                        for (int i = 0; i < books.Count; i++)
                        {
                            if (books[i].ItemType == "Book")
                            {
                                Console.WriteLine($"{i + 1}. {books[i].Title}");
                            }
                        }
                        Console.Write("Select the book you want to loan: ");
                        int bookChoice = int.Parse(Console.ReadLine());
                        books[bookChoice - 1].Loan();
                        break;

                    case "2":
                        Console.WriteLine("DVDs:");
                        for (int i = 0; i < dvds.Count; i++)
                        {
                            if (dvds[i].ItemType == "DVD")
                            {
                                Console.WriteLine($"{i + 1}. {dvds[i].Title}");
                            }
                        }
                        Console.Write("Select the dvd you want to loan: ");
                        int dvdChoice = int.Parse(Console.ReadLine());
                        dvds[dvdChoice - 1].Loan();
                        break;

                    case "3":
                        Console.WriteLine("Magazines:");
                        for (int i = 0; i < magazines.Count; i++)
                        {
                            if (magazines[i].ItemType == "Magazine")
                            {
                                Console.WriteLine($"{i + 1}. {magazines[i].Title}");
                            }
                        }
                        Console.Write("Select the magazine you want to loan: ");
                        int magazineChoice = int.Parse(Console.ReadLine());
                        magazines[magazineChoice - 1].Loan();
                        break;

                    case "4":
                        Console.WriteLine("Select the type of media to check:");
                        Console.WriteLine("1. Book");
                        Console.WriteLine("2. DVD");
                        Console.WriteLine("3. Magazine");

                        string mediaTypeInput = Console.ReadLine();
                        List<IMedia> mediaList = new List<IMedia>();

                        if (mediaTypeInput == "1")
                        {
                            mediaList = books;
                        }
                        else if (mediaTypeInput == "2")
                        {
                            mediaList = dvds;
                        }
                        else if (mediaTypeInput == "3")
                        {
                            mediaList = magazines;
                        }

                        for (int i = 0; i < mediaList.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {mediaList[i].Title}. Cost: {mediaList[i].Cost}");
                        }

                        int mediaChoice = -1;
                        bool validInput = false;

                        while (!validInput)
                        {
                            Console.Write("Enter the item number to check if overdue: ");
                            string input = Console.ReadLine();

                            if (int.TryParse(input, out mediaChoice) && mediaChoice > 0 && mediaChoice <= mediaList.Count)
                            {
                                validInput = true;
                            }
                            else
                            {
                                Console.WriteLine("Invalid selection. Please enter a valid item number.");
                            }
                        }

                        IMedia selectedItem = mediaList[mediaChoice - 1];

                        if (selectedItem.IsOverdue())
                        {
                            Console.WriteLine($"The item '{selectedItem.Title}' is overdue. Fine: {selectedItem.Cost}");
                        }
                        else
                        {
                            Console.WriteLine($"The item '{selectedItem.Title}' is not overdue.");
                        }
                        break;

                    // In the existing Program class, ensure you have the correct type for reservations

                    case "5": // Reservation management
                        Console.WriteLine("\nReservation Management");
                        Console.WriteLine("1. Make a Reservation");
                        Console.WriteLine("2. View Active Reservations");
                        Console.WriteLine("3. Cancel Reservation");

                        string reservationChoice = Console.ReadLine();

                        switch (reservationChoice)
                        {
                            case "1": // Make a Reservation
                                Console.WriteLine("Select media to reserve:");
                                Console.WriteLine("Available Books:");
                                for (int i = 0; i < books.Count; i++)
                                {
                                    Console.WriteLine($"{i + 1}. {books[i].Title}");
                                }

                                Console.Write("Select the book you want to reserve: ");
                                int reserveBookChoice = int.Parse(Console.ReadLine());
                                IMedia mediaToReserve = books[reserveBookChoice - 1];

                                // Create a reservation
                                BaseReservation reservation = new BaseReservation(user1, mediaToReserve);
                                reservationManager.AddReservation(reservation);
                                Console.WriteLine($"Reservation made for {user1.Name} on '{mediaToReserve.Title}'");

                                break;

                            case "2": // View Active Reservations
                                Console.WriteLine("Active Reservations:");
                                List<IReservation> activeReservations = reservationManager.GetActiveReservations(); // Ensure this method returns List<IReservation>

                                foreach (var res in activeReservations)
                                {
                                    Console.WriteLine($"{res.ReservedBy.Name} reserved '{res.ReservedItem.Title}' on {res.ReservationDate}");
                                }
                                break;

                            case "3": // Cancel Reservation
                                Console.WriteLine("Select reservation to cancel:");
                                List<IReservation> reservationsToCancel = reservationManager.GetActiveReservations(); // Ensure this method returns List<IReservation>

                                for (int i = 0; i < reservationsToCancel.Count; i++)
                                {
                                    Console.WriteLine($"{i + 1}. {reservationsToCancel[i].ReservedItem.Title} - {reservationsToCancel[i].ReservedBy.Name}");
                                }

                                int cancelChoice = int.Parse(Console.ReadLine());
                                var reservationToCancel = reservationsToCancel[cancelChoice - 1];

                                reservationManager.CancelReservation(reservationToCancel);
                                Console.WriteLine($"Reservation for '{reservationToCancel.ReservedItem.Title}' has been canceled.");

                                break;

                            default:
                                Console.WriteLine("Invalid reservation option.");
                                break;
                        }
                        break;

                }
            }
        }
    }
}
