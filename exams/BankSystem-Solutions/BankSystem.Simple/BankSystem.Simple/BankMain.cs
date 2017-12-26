namespace BankSystem.Simple
{
    using System;

    using Core;

    public class BankMain
    {
        public static void Main(string[] args)
        {
            CommandExecutor executor = new CommandExecutor();
            while (true)
            {
                try
                {
                    string input = Console.ReadLine();
                    string output = executor.Execute(input);
                    Console.WriteLine(output);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
