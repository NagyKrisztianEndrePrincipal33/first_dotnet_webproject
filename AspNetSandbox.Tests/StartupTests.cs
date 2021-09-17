using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AspNetSandbox.Tests
{
    public class StartupTests
    {

        [Fact]
        public void CheckConversionToEFConnectionString()
        {
            // ASSUME
            string databaseUrl = "postgres://bgquogrrlregwu:aae9a12d44c0668cf9343892b7b90cb6fe3de8184ec5d9f318d20dddef80d488@ec2-54-155-61-133.eu-west-1.compute.amazonaws.com:5432/d2vfcsa6ira9tm";

            // ACT
            string convertedConnectionString = Startup.ConvertConnectionString(databaseUrl);

            // ASSERT
            Assert.Equal("Database=d2vfcsa6ira9tm; Host=ec2-54-155-61-133.eu-west-1.compute.amazonaws.com; Port=5432; User Id=bgquogrrlregwu; Password=aae9a12d44c0668cf9343892b7b90cb6fe3de8184ec5d9f318d20dddef80d488; SSL Mode=Require;Trust Server Certificate=true", convertedConnectionString);
        }
    }
}
