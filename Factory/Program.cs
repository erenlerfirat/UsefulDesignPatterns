using System;

namespace Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager( new LoggerFactory2());
            customerManager.Save();
        }
    }
    public class LoggerFactory:ILoggerFactory
    {
        public ILogger CreateLogger()
        {   
            //your business code
            return new MyLogger();
        }
    }
    public class LoggerFactory2 : ILoggerFactory
    {
        public ILogger CreateLogger()
        {
            //your business code
            return new Log4Net();
        }
    }
    public interface ILogger
    {
        void Log();
    }
    public interface ILoggerFactory 
    {
         ILogger CreateLogger();
        
    }
    public class MyLogger:ILogger 
    {
        public void Log() 
        {
            Console.WriteLine("Logged with MyLogger ");
        }
    }
    public class Log4Net : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged with Log4Net ");
        }
    }
    public class CustomerManager 
    {
        private ILoggerFactory _loggerFactory;
        public CustomerManager(ILoggerFactory loggerFactory)
        {
            _loggerFactory = loggerFactory;
        }
        public void Save() 
        {
            Console.WriteLine("saved");
            ILogger logger = _loggerFactory.CreateLogger();
            logger.Log();           

        }
    }
}
