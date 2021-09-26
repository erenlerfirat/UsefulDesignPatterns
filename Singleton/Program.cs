using System;

namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            
            CustomerManager customerManager = CustomerManager.CreateAsSingleton();
            CustomerManager customerManager2 = CustomerManager.CreateAsSingleton();
            customerManager.Save();
            Console.WriteLine(customerManager == customerManager2);
            //output True
        }
    }
    public class CustomerManager
    {
        static CustomerManager _customerManager;
        static object _lockObject = new object();
        private CustomerManager()
        {

        }
        public static CustomerManager CreateAsSingleton()
        {
            // code below returns _cM if it isn't null otherwise it creates new _cM then returns 
            lock (_lockObject)
            {
                if (_customerManager==null)
                {
                    _customerManager = new CustomerManager();
                } 
            }
            return _customerManager;
           
        }

        public  void Save()
        {
            Console.WriteLine("Saved");
        }
    }
       

}
