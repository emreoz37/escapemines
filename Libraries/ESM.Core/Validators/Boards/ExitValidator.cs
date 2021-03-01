using ESM.Core.Exceptions;
using System;
using System.Text.RegularExpressions;

namespace ESM.Core.Validators.Boards
{
    public class ExitValidator : IExitValidator
    {
        public void IsValidExitPoint(string exitPoint)
        {
            if (string.IsNullOrWhiteSpace(exitPoint))
                throw new ArgumentNullException(null,"Exit point parameter cannot be null or empty");

            var pattern = new Regex(@"^\d+ \d+$").IsMatch(exitPoint);
            if (!pattern)
                throw new PatternValidationException("Exit point parameter pattern is not valid");
        }
    }
}
