using ESM.Core.Base.Boards;
using ESM.Services.Boards;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ESM.Tests.ESM.Services.Tests.Boards
{
    public class BoardSetCommandTests
    {
        private readonly IBoard _board;
        private IBoardSetCommand _boardSetCommand;

        public BoardSetCommandTests()
        {
            _board = Mock.Of<Board>();
        }

        [Fact]
        public void Should_CreateTheIdenticalBoardWithTheGivenSizeParameters_When_TheCommandSizeParametersAreGiven()
        {
            _boardSetCommand = new BoardSetCommand(new Size(5, 4));
            _boardSetCommand.Set(_board);
            _boardSetCommand.Execute();

            Assert.Equal(5, _board.Size.MaxX);
            Assert.Equal(4, _board.Size.MaxY);
        }
    }
}
