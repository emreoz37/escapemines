using ESM.Core.Infrastructure;
using System.Collections.Generic;

namespace ESM.Services.Common
{
    /// <summary>
    /// Represents the conctract of command parser
    /// </summary>
    public interface ICommandParserService
    {
        /// <summary>
        /// Parses all instructions and returns the command interface list.
        /// </summary>
        /// <param name="instructions">String</param>
        /// <returns>Commands</returns>
        IEnumerable<ICommand> Parse(string instructions);
    }
}
