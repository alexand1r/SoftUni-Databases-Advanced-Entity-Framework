namespace BankSystem
{
    using Core;

    public class BankSystemMain
    {
        public static void Main(string[] args)
        {
            CommandDispatcher commandDispatcher = new CommandDispatcher();
            Engine engine = new Engine() { CommandDispatcher = commandDispatcher };
            engine.Run();
        }
    }
}
