using ESM.Core.Exceptions;
using System;
using System.Text.RegularExpressions;

namespace ESM.Core.Validators.Obstacles
{
    public class ObstaclesValidator : IObstaclesValidator
    {
        public void IsValidListOfObstacles(string listOfObstacles)
        {
            if (string.IsNullOrWhiteSpace(listOfObstacles))
                throw new ArgumentNullException(null,"List of obstacles parameter cannot be null or empty");

            var pattern = new Regex(@"").IsMatch(listOfObstacles);
            if (!pattern)
                throw new PatternValidationException("List of obstacles parameter pattern is not valid");
        }
    }

}
