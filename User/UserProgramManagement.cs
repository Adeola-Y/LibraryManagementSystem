namespace LibraryManagementSystem.Managers
{
    using System;
    using System.Collections.Generic;

    namespace LibraryManagementSystem
    {
        public class UserProgramManagement
        {
            private AccountManager accountManager;

            public UserProgramManagement(AccountManager AccountManager)
            {
                accountManager = AccountManager;
            }

            // Method to convert users from AccountManager to UserManagement
            public List<UserManagement> CreateUserManagementList()
            {
                List<UserManagement> userManagements = new List<UserManagement>();
                foreach (User user in accountManager.users)
                {
                    // Create a new UserManagement instance for each User
                    UserManagement userManagement = new UserManagement
                    {
                        Name = user.Name,
                        Email = user.Email,
                        PhoneNumber = user.PhoneNumber,
                        UserId = user.UserId
                    };
                    userManagements.Add(userManagement);
                }
                return userManagements;
            }

            public UserManagement SelectUser()
            {
                int userChoice;

                Console.WriteLine("\nSelect a user:");
                List<UserManagement> userManagements = CreateUserManagementList();
                for (int i = 0; i < userManagements.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {userManagements[i].Name}");
                }
                Console.Write("Enter user number: ");

                if (int.TryParse(Console.ReadLine(), out userChoice) && userChoice > 0 && userChoice <= userManagements.Count)
                {
                    return userManagements[userChoice - 1];
                }
                else
                {
                    Console.WriteLine("Invalid user selection.");
                    return null;
                }
            }
        }
    }
}
