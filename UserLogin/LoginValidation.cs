using System;


namespace UserLogin
{
    public class LoginValidation
    {
        private string username;
        private string password;
        public static User User;
        private string errorMessage;

        public delegate void ActionOnError(string errorMsg);

        private ActionOnError error;

        public LoginValidation(string username, string password, ActionOnError error)
        {
            this.username = username;
            this.password = password;
            this.error = error;
        }
        static public UserRoles currentUserRole
        {
            get;
            private set;
        }

        public Boolean ValidateUserInput(User user)
        {

            Boolean emptyUserName;
            emptyUserName = username.Equals(String.Empty);

            Boolean emptyPassword;
            emptyPassword = password.Equals(String.Empty);

            if (emptyUserName)
            {
                errorMessage = "Не е посочено потребителско име";
                currentUserRole = UserRoles.ANONYMOUS;
                error(errorMessage);
                return false;
            }

            if (emptyPassword)
            {
                errorMessage = "Не е посочена парола";
                currentUserRole = UserRoles.ANONYMOUS;
                error(errorMessage);
                return false;
            }

            if (username.Length < 5)
            {
                errorMessage = "Потребителското име трябва да е поне 5 символа";
                currentUserRole = UserRoles.ANONYMOUS;
                error(errorMessage);
                return false;
            }

            if (password.Length < 5)
            {
                errorMessage = "Паролата трябва да е поне 5 символа";
                currentUserRole = UserRoles.ANONYMOUS;
                error(errorMessage);
                return false;
            }
            if (UserData.isUserPassCorrect(username, password) == null)
            {

                errorMessage = "Не е намерен такъв потребител";
                currentUserRole = UserRoles.ANONYMOUS;
                error(errorMessage);
                return false;
            }

            User = user = UserData.isUserPassCorrect(username, password);

            currentUserRole = user.Role;
            Logger.LogActivity("Успешен Login");
            Console.WriteLine();
            return true;


        }
    }
}
