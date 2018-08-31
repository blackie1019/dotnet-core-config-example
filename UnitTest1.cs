using System;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        
        private IConfiguration config;
        
        [SetUp]
        public void Setup()
        {
            config =  new ConfigurationBuilder()
                .AddJsonFile("applicationsettings.json", true, true)
                .Build();
        }

        [Test]
        public void Test_GetSection()
        {
            // Arrange
            var parameter1 = 123;
            var parameter2 = "abc";

            // Action
            var settings = config.GetSection("Settings");

            // Assert
            Assert.AreEqual(parameter1, Convert.ToInt32(settings.GetSection("Parameter1").Value));
            Assert.AreEqual(parameter2, settings.GetSection("Parameter2").Value);
        }
        
        [Test]
        public void Test_FromBinder()
        {
            // Arrange
            var parameter1 = 123;
            var parameter2 = "abc";

            // Action
            var settings =new Settings();
            config.Bind("Settings",settings);

            // Assert
            Assert.AreEqual(parameter1, settings.Parameter1);
            Assert.AreEqual(parameter2, settings.Parameter2);
        }
    }
}