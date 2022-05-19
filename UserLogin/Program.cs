using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

namespace UserLogin
{
    class Program
    {
        public delegate void ActionOnError(string errorMsg);

        public static void ErrorOnValidation(string errorMessage)
        {
            Console.WriteLine("!!! " + errorMessage + " !!!");
        }

        static void Main(string[] args)
        {

            Console.WriteLine(DateTime.MaxValue);

            Console.WriteLine("Потребителско име");
            string username = Console.ReadLine();
            Console.WriteLine("Парола");
            string password = Console.ReadLine();

            LoginValidation loginValidation = new LoginValidation(username, password, ErrorOnValidation);

            var user = new User();

            if (loginValidation.ValidateUserInput(user))
            {
                Console.WriteLine("Username = {0} password = {1}  faculty number = {2} ", LoginValidation.User.Username, LoginValidation.User.Password, LoginValidation.User.FacNum);

            }


            switch (LoginValidation.currentUserRole)
            {
                case UserRoles.ANONYMOUS:
                    Console.WriteLine("ANONYMOUS");
                    break;
                case UserRoles.ADMIN:
                    Console.WriteLine("ADMIN");
                    AdminMenu();
                    break;
                case UserRoles.INSPECTOR:
                    Console.WriteLine("INSPECTOR");
                    break;
                case UserRoles.PROFESSOR:
                    Console.WriteLine("PROFESSOR");
                    break;
                case UserRoles.STUDENT:
                    Console.WriteLine("STUDENT");
                    break;
                default:
                    break;
            }
        }

        static void AdminMenu()
        {
            Console.WriteLine("0. Изход");
            Console.WriteLine("1. Промяна на роля на потребител");
            Console.WriteLine("2. Промяна на активност на потребител");
            Console.WriteLine("3. Списък на потребителите");
            Console.WriteLine("4. Преглед на лог на активност");
            Console.WriteLine("5. Преглед на текуща активност");
            Int32 input = Int32.Parse(Console.ReadLine());
            while (input != 0)
            {
                switch (input)
                {
                    case 0:
                        break;
                    case 1:
                        Console.WriteLine("Въведете потребителското име, което искате да коригирате");
                        string username = Console.ReadLine();
                        var roles = new[] { UserRoles.ADMIN, UserRoles.INSPECTOR, UserRoles.PROFESSOR, UserRoles.STUDENT };

                        for (var i = 0; i < roles.Length; i++)
                            Console.WriteLine(i + ": " + roles[i]);

                        Console.WriteLine("Въведете нова роля");
                        var newUserRole = Convert.ToInt32(Console.ReadLine());
                        UserData.AssignUserRole(username, roles[newUserRole]);

                        break;
                    case 2:
                        Console.WriteLine("Въведете потребителското име, което искате да коригирате");
                        username = Console.ReadLine();
                        Console.WriteLine("Въведете нова дата на активност");
                        DateTime newDateActiveTo = DateTime.Parse(Console.ReadLine());
                        UserData.SetUserActiveTo(username, newDateActiveTo);
                        break;
                    case 3:
                        UserData.UserList();
                        break;
                    case 4:
                        Logger.ReadFullLog();
                        break;
                    case 5:
                        string filter = Console.ReadLine();
                        StringBuilder sb = new StringBuilder();

                        IEnumerable<string> currentActvs = Logger.getCurrentSessionActivities(filter);

                        foreach (string line in currentActvs)
                        {
                            sb.Append(line);
                        }

                        Console.WriteLine(sb.ToString());
                        break;
                }
                Console.WriteLine();
                Console.WriteLine("0. Изход");
                Console.WriteLine("1. Промяна на роля на потребител");
                Console.WriteLine("2. Промяна на активност на потребител");
                Console.WriteLine("3. Списък на потребителите");
                Console.WriteLine("4. Преглед на лог на активност");
                Console.WriteLine("5. Преглед на текуща активност");
                Console.WriteLine("Изберете опция");
                input = Int32.Parse(Console.ReadLine());
            }
        }
    }
}
