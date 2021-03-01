using ESM.Core.Base.Boards;
using ESM.Core.Base.Points;
using ESM.Core.Exceptions;
using ESM.Services.Boards;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ESM.Tests.ESM.Services.Tests.Boards
{
    public class ExitSetCommandTests
    {
        private readonly IBoard _board;
        private readonly IExit _exit;
        private IBoardSetCommand _boardSetCommand;
        private IExitSetCommand _exitSetCommand;

        public ExitSetCommandTests()
        {
            _board = Mock.Of<Board>();
            _exit = Mock.Of<Exit>();

        }

        [Fact]
        public void Should_ReturnTheGivenExitPoint_When_TheExistPointParametersAreValid()
        {
            _boardSetCommand = new BoardSetCommand(new Size(5, 4));
            _boardSetCommand.Set(_board);
            _boardSetCommand.Execute();

            _exitSetCommand = new ExitSetCommand(new Point(3, 3));
            _exitSetCommand.Set(_board, _exit);
            _exitSetCommand.Execute();

            Assert.Equal(3, _exit.Point.X);
            Assert.Equal(3, _exit.Point.Y);
        }

        [Theory]
        [InlineData(6, 1)]
        [InlineData(0, 6)]
        [InlineData(-1, 0)]
        [InlineData(0, -1)]
        public void Should_ThrowPointValidationException_When_TheExistPointParametersAreInvalid(int locationX, int locationY)
        {
            _boardSetCommand = new BoardSetCommand(new Size(5, 5));
            _boardSetCommand.Set(_board);
            _boardSetCommand.Execute();

            _exitSetCommand = new ExitSetCommand(new Point(locationX, locationY));
            _exitSetCommand.Set(_board, _exit);

           var exception =  Assert.Throws<PointValidationException>(() => _exitSetCommand.Execute());
            Assert.Equal("Exit point is not valid!",exception.Message);
        }
    }
}
