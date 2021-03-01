using ESM.Core.Exceptions;
using ESM.Core.Validators.Boards;
using Moq;
using System;
using Xunit;

namespace ESM.Tests.ESM.Core.Tests.Validators.Exits
{
    public class ExitValidatorTests
    {
        private readonly IExitValidator _exitValidator;

        public ExitValidatorTests()
        {
            _exitValidator = Mock.Of<ExitValidator>();
        }

        [Theory]
        [InlineData(null)]
        [InlineData(" ")]
        [InlineData("       ")]
        [InlineData("")]
        public void Should_ThrowArgumentNullException_When_TheExitPointComesNullOrWhiteSpace(string exitPoint)
        {
           var exception = Assert.Throws<ArgumentNullException>(() => _exitValidator.IsValidExitPoint(exitPoint));
            Assert.Equal("Exit point parameter cannot be null or empty",exception.Message);

        }

        [Theory]
        [InlineData("4")]
        [InlineData("53")]
        [InlineData("842")]
        [InlineData("3 L")]
        [InlineData("3 5 M")]
        public void Should_ThrowPatternException_When_TheExitPointComesInvalidPattern(string exitPoint)
        {
            var exception = Assert.Throws<PatternValidationException>(() => _exitValidator.IsValidExitPoint(exitPoint));
            Assert.Equal("Exit point parameter pattern is not valid", exception.Message);
        }

        [Fact]
        public void Should_PatternMatch_When_TheExitPointComesValidPattern()
        {
            _exitValidator.IsValidExitPoint("5 3");
            Assert.Matches(@"^\d+ \d+$", "5 3");
        }
    }
}
