namespace Ab_pk_task_MovieStore.Services
{
    public class DBLogger : ILoggerService
    {
        public void Write(string message)
        {
            Console.WriteLine("[DBLogger] " + message);
        }
    }
}
