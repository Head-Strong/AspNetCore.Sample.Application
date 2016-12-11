using System;

namespace CustomCacheProvider.Test
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var customCacheManager = new CustomCacheManager();
            
            customCacheManager.Add("Aditya Magotra", "Name", 20);

            var getKey = customCacheManager.Get<string>("Name");

            Console.WriteLine(getKey);
            Console.ReadLine();
        }
    }
}
