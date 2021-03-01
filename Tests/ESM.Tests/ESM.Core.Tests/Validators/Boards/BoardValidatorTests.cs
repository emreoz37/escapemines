using ESM.Core.Exceptions;
using ESM.Core.Validators.Boards;
using Moq;
using System;
using Xunit;

namespace ESM.Tests.ESM.Core.Tests.Validators.Boards
{
    public class BoardValidatorTests
    {
        private readonly IBoardValidator _boardValidator;

        public BoardValidatorTests()
        {
            _boardValidator = Mock.Of<BoardValidator>();
        }

        [Theory]
        [InlineData(null)]
        [InlineData(" ")]
        [InlineData("       ")]
        [InlineData("")]
        public void Should_ThrowArgumentNullException_When_TheBoardSizeComesNullOrWhiteSpace(string boardSize)
        {
           var exception =  Assert.Throws<ArgumentNullException>(() => _boardValidator.IsValidBoardSize(boardSize));
            Assert.Equal("Board size parameter cannot be null or empty", exception.Message);

        }

        [Theory]
        [InlineData("0")]
        [InlineData("01")]
        [InlineData("353")]
        [InlineData("3 N")]
        [InlineData("0 1 N")]
        public void Should_ThrowPatternException_When_TheBoardSizeComesInvalidPattern(string boardSize)
        {
           var exception =  Assert.Throws<PatternValidationException>(() => _boardValidator.IsValidBoardSize(boardSize));
            Assert.Equal("Board size parameter pattern is not valid",exception.Message);
        }

        [Fact]
        public void Should_PatternMatch_When_TheBoardSizeComesValidPattern()
        {
            Assert.Matches(@"^\d+ \d+$", "2 4");
        }
    }
}
