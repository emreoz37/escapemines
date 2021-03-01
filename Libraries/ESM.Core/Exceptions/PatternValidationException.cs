using System;

namespace ESM.Core.Exceptions
{
    /// <summary>
    /// Represents the expcetion type of pattern validation exception
    /// </summary>
    public class PatternValidationException : Exception
    {
        public PatternValidationException(string message) : base(message)
        {
        }
    }
}
