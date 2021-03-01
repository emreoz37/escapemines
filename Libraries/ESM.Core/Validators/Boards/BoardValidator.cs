using ESM.Core.Exceptions;
using System;
using System.Text.RegularExpressions;

namespace ESM.Core.Validators.Boards
{
    public class BoardValidator : IBoardValidator
    {
        public void IsValidBoardSize(string boardSize)
        {
            if (string.IsNullOrWhiteSpace(boardSize))
                throw new ArgumentNullException(null,"Board size parameter cannot be null or empty");

            var pattern = new Regex(@"^\d+ \d+$").IsMatch(boardSize);
            if (!pattern)
                throw new PatternValidationException("Board size parameter pattern is not valid");
        }
    }

}
