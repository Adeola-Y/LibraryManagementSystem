using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Managers
{
    public class AccountManager
    {
        public List<User> users = new List<User>();

        private bool UserExists(int userId)
        {
            foreach (User u in users)
            {
                if (u.UserId == userId)
                {
                    return true;
                }
            }
            return false;
        }

        public void AddUser(User user)
        {
            if (user != null && !UserExists(user.UserId))
            {
                users.Add(user);
                Console.WriteLine($"User added successfully {user}");
            }
            else
            {
                Console.WriteLine("User already exists");
            }
        }

        public bool RemoveUser(int userId)
        {
            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].UserId == userId)
                {
                    users.RemoveAt(i);
                    Console.WriteLine($"User removed successfully {users[i]}");
                    return true;
                }
            }
            Console.WriteLine("User not found.");
            return false;
        }

        public void DisplayUsers()
        {
            if (users.Count == 0)
            {
                Console.WriteLine("No users available.");
            }
            else
            {
                Console.WriteLine("Current users in the system:");
                foreach (User user in users)
                {
                    Console.WriteLine($"Name: {user.Name}, Email: {user.Email}, Phone: {user.PhoneNumber}, ID: {user.UserId}");
                }
            }
        }
    }
}
