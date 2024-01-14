namespace Ab_pk_task_MovieStore.Services
{
    public class ConsoleLogger : ILoggerService
    {
        public void Write(string message)
        {
            Console.WriteLine("[ConsoleLogger] " + message);
        }
    }
}
