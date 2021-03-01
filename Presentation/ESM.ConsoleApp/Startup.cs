using ESM.Core.Base.Boards;
using ESM.Core.Base.Obstacles.Mines;
using ESM.Core.Infrastructure;
using ESM.Core.Validators.Animals;
using ESM.Core.Validators.Boards;
using ESM.Core.Validators.Obstacles;
using ESM.Services.Animals.Turtles;
using ESM.Services.Animals.Turtles.Services;
using ESM.Services.Common;
using ESM.Services.Initializations;
using Microsoft.Extensions.DependencyInjection;

namespace ESM.ConsoleApp
{
    public class Startup
    {
        /// <summary>
        /// Add services to the application and configure service provider
        /// </summary>
        /// <param name="services">Collection of service descriptors</param>
        public void ConfigureServices(IServiceCollection services)
        {
            //Animals
            services.AddScoped<ITurtle, Turtle>();

            //Boards
            services.AddScoped<IBoard, Board>();
            services.AddScoped<IExit, Exit>();

            //Obstacles
            services.AddScoped<IMine, Mine>();

            //Infrastructure
            services.AddScoped<IInvoker, TurtleGameInvoker>();

            //Validators
            services.AddScoped<IAnimalValidator, AnimalValidator>();
            services.AddScoped<IBoardValidator, BoardValidator>();
            services.AddScoped<IExitValidator, ExitValidator>();
            services.AddScoped<IObstaclesValidator, ObstaclesValidator>();

            //Services
            services.AddScoped<IInitializationService<ITurtle, IMine>, TurtleInitializationService>();
            services.AddScoped<ITurtleMoveService, TurtleMoveService>();
            services.AddScoped<ICommandParserService, CommandParserService>();
        }
    }
}
