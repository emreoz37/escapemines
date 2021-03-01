using ESM.Core.Base.Boards;
using ESM.Core.Base.Obstacles.Mines;
using ESM.Core.Base.Points;
using ESM.Core.Exceptions;
using ESM.Services.Boards;
using ESM.Services.Obstacles.Mines;
using Moq;
using Xunit;

namespace ESM.Tests.ESM.Services.Tests.Obstacles
{
    public class MineSetCommandTests
    {
        private readonly IBoard _board;
        private readonly IMine _mine;
        private IBoardSetCommand _boardSetCommand;
        private IMineSetCommand _mineSetCommand;

        public MineSetCommandTests()
        {
            _board = Mock.Of<Board>();
            _mine = Mock.Of<Mine>();
        }


        [Fact]
        public void Should_ReturnTheAvailableMinePoints_When_TheAppropriatePointsAreGiven()
        {
            _boardSetCommand = new BoardSetCommand(new Size(5, 4));
            _boardSetCommand.Set(_board);
            _boardSetCommand.Execute();

            _mineSetCommand = new MineSetCommand(new Point(1, 2));
            _mineSetCommand.Set(_board, _mine);
            _mineSetCommand.Execute();

            Assert.Equal(1, _mine.Point.X);
            Assert.Equal(2, _mine.Point.Y);
        }

 

        [Theory]
        [InlineData(6, 1)]
        [InlineData(0, 6)]
        [InlineData(-1, 0)]
        [InlineData(0, -1)]
        public void Should_ThrowPointValidationException_When_TheInvalidMinePointsAreGiven(int locationX, int locationY)
        {
            _boardSetCommand = new BoardSetCommand(new Size(5, 5));
            _boardSetCommand.Set(_board);
            _boardSetCommand.Execute();

            _mineSetCommand = new MineSetCommand(new Point(locationX, locationY));
            _mineSetCommand.Set(_board, _mine);

            var exception = Assert.Throws<PointValidationException>(() => _mineSetCommand.Execute());
            Assert.Equal("Mine point is not valid!", exception.Message);
        }
    }
}
