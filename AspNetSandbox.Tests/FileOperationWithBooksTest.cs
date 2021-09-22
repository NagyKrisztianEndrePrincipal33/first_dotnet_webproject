using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AspNetSandbox.Tests
{
    public class FileOperationWithBooksTest
    {
        [Fact]
        public void EnumerateFilesTest()
        {
            System.IO.DirectoryInfo directoryInfo = new System.IO.DirectoryInfo(".");
            var files = directoryInfo.EnumerateFiles();
            foreach (var file in files)
            {
                Console.WriteLine(file.Name);
            }
        }

        [Fact]
        public void CreateFileTest()
        {
            File.WriteAllText("newSettings.json", @"{
                      ""ConnectionStrings"": {
                        ""LocalPostgras"": ""Server=127.0.0.1;Port=5432;Database=AspNetSandbox;User Id=postgres;Password=postgres;"",
                        ""SqlConnection"": ""Server=(localdb)\\mssqllocaldb;Database=aspnet-AspNetSandbox-BD92296E-681A-41B4-B24E-D40B5E5BAFDE;Trusted_Connection=True;MultipleActiveResultSets=true"",
                        ""DefaultConnection"": ""Database=d2vfcsa6ira9tm; Host=ec2-54-155-61-133.eu-west-1.compute.amazonaws.com; Port=5432; User Id=bgquogrrlregwu; Password=aae9a12d44c0668cf9343892b7b90cb6fe3de8184ec5d9f318d20dddef80d488; SSL Mode=Require;Trust Server Certificate=true"",
                        ""Heroku"": ""postgres://bgquogrrlregwu:aae9a12d44c0668cf9343892b7b90cb6fe3de8184ec5d9f318d20dddef80d488@ec2-54-155-61-133.eu-west-1.compute.amazonaws.com:5432/d2vfcsa6ira9tm""
                      },
                      ""Logging"": {
                        ""LogLevel"": {
                          ""Default"": ""Information"",
                          ""Microsoft"": ""Warning"",
                          ""Microsoft.Hosting.Lifetime"": ""Information""
                        }
                      },
                      ""AllowedHosts"": ""*""
                        }
");
        }

        [Fact]
        public void ReadFilesTest()
        {
            using (var fileStream = File.OpenRead("newSettings.json"))
            {
                byte[] b = new byte[1024];
                UTF8Encoding temp = new UTF8Encoding(true);

                while (fileStream.Read(b, 0, b.Length) > 0)
                {
                    var returnedString = temp.GetString(b);
                    Console.WriteLine(temp.GetString(b));
                }
            }
        }
    }
}
