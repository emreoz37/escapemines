using ESM.Core.Base.Boards;
using ESM.Core.Base.Obstacles.Mines;
using ESM.Core.Exceptions;
using ESM.Core.Infrastructure;
using ESM.Core.Validators.Animals;
using ESM.Core.Validators.Boards;
using ESM.Core.Validators.Obstacles;
using ESM.Services.Animals.Turtles;
using ESM.Services.Animals.Turtles.Services;
using ESM.Services.Common;
using ESM.Services.Initializations;
using Moq;
using System;
using System.Text;
using Xunit;

namespace ESM.Tests.ESM.Services.Tests.Common
{
    public class TurtleGameInvokerTests
    {
        private readonly ICommandParserService _commandParserService;
        private readonly IInvoker _invoker;

        public TurtleGameInvokerTests()
        {
            IAnimalValidator animalValidator = Mock.Of<AnimalValidator>();
            IBoardValidator boardValidator = Mock.Of<BoardValidator>();
            IExitValidator exitValidator = Mock.Of<ExitValidator>();
            IObstaclesValidator obstaclesValidator = Mock.Of<ObstaclesValidator>();
            _commandParserService = new CommandParserService(animalValidator, boardValidator, exitValidator, obstaclesValidator);
            IInitializationService<ITurtle, IMine> initializationService = new TurtleInitializationService();
            ITurtleMoveService turtleMoveService = Mock.Of<TurtleMoveService>();
            IBoard board = Mock.Of<Board>();
            IExit exit = Mock.Of<Exit>();
            ITurtle turtle = new Turtle(turtleMoveService);
            _invoker = new TurtleGameInvoker(board, exit, turtle, initializationService);
        }

        [Theory]
        [InlineData("5 4", "1,1 1,3 3,3", "4 2", "0 1 N", "R M L M M", "Mine Hit")]
        [InlineData("5 4", "1,0 1,3 3,3", "2 1", "0 1 N", "R M M", "Success")]
        [InlineData("5 4", "1,0 1,3 3,3", "5 1", "0 1 N", "R M M", "Still In Danger")]
        public void Should_ReturnSuccessfulResult_When_TheParametersAreSuitable(string boardSize, string listOfMines, string exitPoint, string turtleStartingPoint, string movements, string result)
        {
            var input = new StringBuilder();
            input.AppendLine(boardSize);
            input.AppendLine(listOfMines);
            input.AppendLine(exitPoint);
            input.AppendLine(turtleStartingPoint);
            input.Append(movements);

            var commands = _commandParserService.Parse(input.ToString());
            _invoker.SetCommands(commands);
            _invoker.InvokeCommands();

            var commandResult = _invoker.GetResult();

            Assert.Equal(result, commandResult);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void Should_ThrowArgumentNullException_When_TheInstructionsParameterComesNullOrWhiteSpace(string instructions)
        {
            var exception = Assert.Throws<ArgumentNullException>(() => _commandParserService.Parse(instructions));
            Assert.Equal("Instructions parameter cannot be null or empty", exception.Message);
        }

        [Fact]
        public void Should_ThrowArgumentException_When_TheInstructionLinesComesLowerThanMinimumLength()
        {
            var exception = Assert.Throws<ArgumentException>(() => _commandParserService.Parse("Lower_Than_Minimum_Length"));
            Assert.Contains("The length of the settings cannot be lower than minimum length", exception.Message);
        }

    }
}
