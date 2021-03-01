using ESM.Core.Infrastructure;
using ESM.Services.Common;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Text;

namespace ESM.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {

            IFileProvider fileProvider = new FileProvider();
            string directoryPath = AppSettingsDefaults.DirectoryPath;

            var settingsFiles = fileProvider.GetFiles(directoryPath, "*.txt");
            if (settingsFiles.Length <= 0)
            {
                throw new ApplicationException($"Could not find any settings file");
            }

            IServiceCollection services = new ServiceCollection();
            Startup startup = new Startup();
            startup.ConfigureServices(services);
            IServiceProvider serviceProvider = services.BuildServiceProvider();

            var commandGenerator = serviceProvider.GetService<ICommandParserService>();
            var invoker = serviceProvider.GetService<IInvoker>();

            foreach (var settingsFile in settingsFiles)
            {
               var file =  fileProvider.ReadAllText(settingsFile, Encoding.UTF8);

                var commands = commandGenerator.Parse(file);
                invoker.SetCommands(commands);
                invoker.InvokeCommands();

                var result = invoker.GetResult();
                Console.WriteLine(result);
            }
            Console.ReadKey();

        }
    }
}
