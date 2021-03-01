using ESM.Core.Exceptions;
using ESM.Core.Validators.Animals;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace ESM.Tests.ESM.Core.Tests.Validators.Animals
{
    public class AnimalValidatorTests
    {
        private readonly IAnimalValidator _animalValidator;

        public AnimalValidatorTests()
        {
            _animalValidator = Mock.Of<AnimalValidator>();
        }

        [Theory]
        [InlineData(new string[] { "N", "W", "S", "E" }, null)]
        [InlineData(new string[] { "N", "W", "S", "E" }, " ")]
        [InlineData(new string[] { "N", "W", "S", "E" }, "")]
        public void Should_ThrowArgumentNullException_When_TheAnimalStartingPointComesNullOrWhitespaceOrEmpty(IList<string> listofDirections, string animalStartingPoint)
        {

            var exception = Assert.Throws<ArgumentNullException>(() => _animalValidator.IsValidAnimalStartingPoint(listofDirections, animalStartingPoint));
            Assert.Equal("Animal starting point parameter cannot be null or empty", exception.Message);
        }

        [Theory]
        [InlineData(null, "0 1 N")]
        [InlineData(new string[] { }, "0 1 N")]
        public void Should_ThrowArgumentNullException_When_TheListOfDirectionsParameterComesNullOrEmptyList(IList<string> listOfDirections, string animalStartingPoint)
        {

            var exception = Assert.Throws<ArgumentNullException>(() => _animalValidator.IsValidAnimalStartingPoint(listOfDirections, animalStartingPoint));
            Assert.Equal("List of directions parameter cannot be null or empty", exception.Message);

        }

        [Theory]
        [InlineData(new string[] { "N", "W", "S", "E" }, "A", "")]
        [InlineData(new string[] { "N", "W", "S", "E" }, "01", "")]
        [InlineData(new string[] { "N", "W", "S", "E" }, "AB", "")]
        [InlineData(new string[] { "N", "W", "S", "E" }, "0 1 A", "")]
        [InlineData(new string[] { "N", "W", "S", "E" }, "53 E", "")]

        public void Should_PatternValidationException_When_TheAnimalStartingPointComesInvalidPattern(IList<string> listofDirections, string animalStartingPoint, string seperator)
        {
           var exception = Assert.Throws<PatternValidationException>(() => _animalValidator.IsValidAnimalStartingPoint(listofDirections, animalStartingPoint, seperator));
            Assert.Equal("Direction parameters are not matching with animal starting point format", exception.Message);
        }

        [Theory]
        [InlineData(new string[] { "N", "W", "S", "E" }, "0 1 N", "")]
        [InlineData(new string[] { "N", "W", "S", "E" }, "5 3 W", "")]
        [InlineData(new string[] { "N", "W", "S", "E" }, "6 2 S", "")]
        public void Should_PatternMatch_When_TheAnimalStartingPointComesValidPattern(IList<string> listofDirections, string animalStartingPoint, string seperator)
        {
            var directionsString = string.Join(seperator, listofDirections);
            Assert.Matches(@"^\d+ \d+ [" + directionsString + "]$", animalStartingPoint);
        }

        [Theory]
        [InlineData(new string[] { "M", "L", "R" }, null)]
        [InlineData(new string[] { "M", "L", "R" }, " ")]
        [InlineData(new string[] { "M", "L", "R" }, "")]
        public void Should_ThrowArgumentNullException_When_TheAnimalMovementsParameterComesNullOrWhitespaceOrEmpty(IList<string> listofMovements, string animalMovements)
        {
            var exception = Assert.Throws<ArgumentNullException>(() => _animalValidator.IsValidAnimalMovements(listofMovements, animalMovements));
            Assert.Equal("Animal movements parameter cannot be null or empty", exception.Message);
        }

        [Theory]
        [InlineData(null, "M L R")]
        [InlineData(new string[] { }, "M L R")]
        public void Should_ThrowArgumentNullException_When_TheListOfMovementsParameterComesNullOrEmptyList(IList<string> listofMovements, string animalMovements)
        {

            var exception = Assert.Throws<ArgumentNullException>(() => _animalValidator.IsValidAnimalMovements(listofMovements, animalMovements));
            Assert.Equal("List of movements parameter cannot be null or empty", exception.Message);

        }

        [Theory]
        [InlineData(new string[] { "L", "R", "M" }, "A L R", " ")]
        [InlineData(new string[] { "L", "R", "M" }, "A 1 R", " ")]
        [InlineData(new string[] { "L", "R", "M" }, "LRS", " ")]
        [InlineData(new string[] { "L", "R", "M" }, "L33", " ")]
        [InlineData(new string[] { "L", "R", "M" }, "53 E", " ")]
        public void Should_PatternValidationException_When_TheAnimalMovementsComesInvalidPattern(IList<string> listofMovements, string animalMovements, string seperator)
        {
            var exception = Assert.Throws<PatternValidationException>(() => _animalValidator.IsValidAnimalMovements(listofMovements, animalMovements, seperator));
            Assert.Equal("Movement parameters are not matching with animal movements format", exception.Message);
        }

        [Theory]
        [InlineData(new string[] { "L", "R", "M" }, "R M L M M", " ")]
        [InlineData(new string[] { "L", "R", "M" }, "R M M M", " ")]
        [InlineData(new string[] { "L", "R", "M" }, "R L L L L L R R M M M", " ")]
        [InlineData(new string[] { "L", "R", "M" }, "M L L R", " ")]
        public void Should_PatternMatch_When_TheAnimalMovementsComesValidPattern(IList<string> listofMovements, string animalMovements, string seperator)
        {
            var movementsString = string.Join(seperator, listofMovements);
            Assert.Matches(@"^[" + movementsString + "]+$", animalMovements);
        }


    }
}
