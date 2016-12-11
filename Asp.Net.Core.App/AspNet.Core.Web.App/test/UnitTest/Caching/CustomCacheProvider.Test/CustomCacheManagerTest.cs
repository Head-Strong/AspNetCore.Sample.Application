using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CustomCacheProvider.Test
{
    [TestClass]
    public class CustomCacheManagerTest
    {
        private readonly ICustomCacheManager _customCacheManager;

        public CustomCacheManagerTest()
        {
            _customCacheManager = new CustomCacheManager();
        }

        [TestMethod]
        public void AddKeyInCache()
        {           
            _customCacheManager.Add("Aditya Magotra", "Name", 20);

            var getKey = _customCacheManager.Get<string>("Name");

            Console.WriteLine(getKey);
            Console.ReadLine();
        }
    }
}
