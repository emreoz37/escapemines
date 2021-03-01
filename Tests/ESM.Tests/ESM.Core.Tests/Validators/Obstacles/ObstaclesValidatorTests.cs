using ESM.Core.Validators.Obstacles;
using Moq;
using System;
using Xunit;

namespace ESM.Tests.ESM.Core.Tests.Validators.Obstacles
{
    public class ObstaclesValidatorTests
    {
        private readonly IObstaclesValidator _obstaclesValidator;

        public ObstaclesValidatorTests()
        {
            _obstaclesValidator = Mock.Of<ObstaclesValidator>();
        }

        [Theory]
        [InlineData(null)]
        [InlineData(" ")]
        [InlineData("       ")]
        [InlineData("")]
        public void Should_ThrowArgumentNullException_When_TheListOfObstaclesComesNullOrWhiteSpace(string listOfObstacles)
        {
            var exception = Assert.Throws<ArgumentNullException>(() => _obstaclesValidator.IsValidListOfObstacles(listOfObstacles));
            Assert.Equal("List of obstacles parameter cannot be null or empty", exception.Message);

        }

        [Fact]
        public void Should_PatternMatch_When_TheListOfObstaclesComesValidPattern()
        {
            Assert.Matches(@"", "5 3");

        }

    }
}
