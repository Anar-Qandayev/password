using System;

namespace parole
{
    class Program
    {
        static void Main(string[] args)
        {
            int id = 1;//id 1-den baslayir 
            while (true)
            {
                try
                {
                  bool checkedPass = false;  
                  User us = new User();
                  us.Id = id;
                  Console.WriteLine("Create a new account.");
                  Console.Write("Enter the full usual : ");
                  us.fullname = Console.ReadLine();
                  Console.Write("Enter your email address : ");
                  us.email = Console.ReadLine();
                
                  while (!checkedPass)
                  {
                    Console.Write("Enter the password :");
                    us.password = Console.ReadLine();
                    string result = us.PasswordChecker(us.password);
                    if (result == "") checkedPass = true; //paroldan xeta gelmese true olsun
                    else Console.WriteLine(result);
                  }
                  us.ShowInfo();
                  id++; // her userin id-si beraber olmamasi uchun id artiririq

                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                    throw;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
        }
        
    }
    public interface IAccount
    {
        string PasswordChecker(string password);
        public void ShowInfo();
    }
    class User: IAccount
    {
        public int Id { get; set; }
        public string fullname { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string PasswordChecker(string password)
        {            
                string description = "";
                string lowerPass = password.ToLower();
                if (password.Length < 8) description = "The length of the password must be greater than 8 !";

                if (password == lowerPass) description = "The password must contain at least one uppercase letter!";

                int numCount = 0;
                for (int i = 0; i < 10; i++) 
                {
                    if (password.Contains($"{i}")) numCount++; // Contains- psswordda 1-9dek her hansi reqemin olub olmamasini yoxluyur.
                }

                if (numCount == 0) description = "The password must contain at least one digit !";// numCount 0 olsa demeli paswordda reqem yoxdur.

                return description;
        }
        public void ShowInfo()
        { 
            Console.WriteLine($"Your id code:  {Id}\nYour name: {fullname}\nYour email address: {email}\n" );            
        }
    }
}
