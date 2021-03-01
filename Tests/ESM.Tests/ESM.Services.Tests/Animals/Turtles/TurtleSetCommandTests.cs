using ESM.Core.Base.Animals.Turtles;
using ESM.Core.Base.Boards;
using ESM.Core.Base.Directions;
using ESM.Core.Exceptions;
using ESM.Services.Animals.Turtles;
using ESM.Services.Animals.Turtles.Commands;
using ESM.Services.Animals.Turtles.Services;
using ESM.Services.Boards;
using Moq;
using Xunit;

namespace ESM.Tests.ESM.Services.Tests.Animals.Turtles
{
    public class TurtleSetCommandTests
    {
        private readonly IBoard _board;
        private readonly ITurtle _turtle;
        private IBoardSetCommand _boardSetCommand;
        private ITurtleSetCommand _turtleSetCommand;

        public TurtleSetCommandTests()
        {
            ITurtleMoveService turtleMoveService = Mock.Of<TurtleMoveService>();
            _board = Mock.Of<Board>();
            _turtle = new Turtle(turtleMoveService);
        }

        [Fact]
        public void Should_ReturnSpecifiedTurtlePointAndDirection_When_GivenParamtersAreValid()
        {
            _boardSetCommand = new BoardSetCommand(new Size(5, 4));
            _boardSetCommand.Set(_board);
            _boardSetCommand.Execute();

            _turtleSetCommand = new TurtleSetCommand(new TurtlePoint(1, 3, Direction.North));
            _turtleSetCommand.Set(_board, _turtle);
            _turtleSetCommand.Execute();

            Assert.Equal(1, _turtle.Point.X);
            Assert.Equal(3, _turtle.Point.Y);
            Assert.Equal(Direction.North, _turtle.Point.Direction);
        }

        [Theory]
        [InlineData(6, 1)]
        [InlineData(0, 6)]
        [InlineData(-1, 0)]
        [InlineData(0, -1)]
        public void Should_ThrowPointValidationException_When_TurtlePointsAreInvalid(int locationX, int locationY)
        {
            _boardSetCommand = new BoardSetCommand(new Size(5, 5));
            _boardSetCommand.Set(_board);
            _boardSetCommand.Execute();

            _turtleSetCommand = new TurtleSetCommand(new TurtlePoint(locationX, locationY, Direction.North));
            _turtleSetCommand.Set(_board, _turtle);

            var exception = Assert.Throws<PointValidationException>(() => _turtleSetCommand.Execute());
            Assert.Equal("Turtle point is not valid!", exception.Message);
        }

    }
}
