using Microsoft.Extensions.DependencyInjection;
using OfficeTime.Ioc;
using System;
using System.IO;

namespace OfficeTime.Con
{
    class Program
    {
        static void Main(string[] args)
        {
            //Add dependency to the app
            var services = new ServiceCollection();

            services.AddTransient<Application>()
                .AddOfficeTimeDependencies();

            using (ServiceProvider serviceProvider = services.BuildServiceProvider())
            {
                Application app = serviceProvider.GetService<Application>();
                Console.Write("Please input path and file name : ");
                var FileName = Console.ReadLine();

                //Verify validity 
                var isValid = string.IsNullOrEmpty(@FileName) || FileName.IndexOfAny(Path.GetInvalidFileNameChars()) < 0 || !File.Exists(@FileName);

                if (!isValid)
                {
                    var pair_list = app.GetPairs(@FileName);

                    for (int i = 0; i < pair_list.Count; i++)
                    {
                        Console.WriteLine(pair_list[i].employee_names + " Count: " + pair_list[i].pair_count.ToString());
                    }
                }
                else
                {
                    Console.WriteLine("File name is not valid or File name does not exists");
                }
            }        
        }
    }
}
