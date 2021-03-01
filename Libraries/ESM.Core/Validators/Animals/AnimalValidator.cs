using ESM.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ESM.Core.Validators.Animals
{
    public class AnimalValidator : IAnimalValidator
    {
        public void IsValidAnimalStartingPoint(IList<string> listOfDirections, string animalStartingPoint, string separator = "")
        {
            if(listOfDirections == null || listOfDirections.Count <= 0)
                throw new ArgumentNullException(null,"List of directions parameter cannot be null or empty");

            if(string.IsNullOrWhiteSpace(animalStartingPoint))
                throw new ArgumentNullException(null,"Animal starting point parameter cannot be null or empty");

            var directionsString = string.Join(separator, listOfDirections);
            var pattern = new Regex(@"^\d+ \d+ [" + directionsString + "]$").IsMatch(animalStartingPoint);
            if(!pattern)
                throw new PatternValidationException("Direction parameters are not matching with animal starting point format");

        }
        public void IsValidAnimalMovements(IList<string> listOfMovements, string animalMovements, string seperator = " ")
        {
            if (listOfMovements == null || listOfMovements.Count <= 0)
                throw new ArgumentNullException(null,"List of movements parameter cannot be null or empty");

            if (string.IsNullOrWhiteSpace(animalMovements))
                throw new ArgumentNullException(null,"Animal movements parameter cannot be null or empty");

            var movementsString = string.Join(seperator, listOfMovements);
            var pattern = new Regex(@"^[" + movementsString + "]+$").IsMatch(animalMovements);
            if (!pattern)
                throw new PatternValidationException("Movement parameters are not matching with animal movements format");
        }


    }
}
