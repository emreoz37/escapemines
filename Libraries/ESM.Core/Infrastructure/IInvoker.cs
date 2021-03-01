using System.Collections.Generic;

namespace ESM.Core.Infrastructure
{
    /// <summary>
    /// Represents the contract of invoker
    /// </summary>
    public interface IInvoker
    {
        /// <summary>
        /// Set commands
        /// </summary>
        /// <param name="commands">Commands</param>
        void SetCommands(IEnumerable<ICommand> commands);

        /// <summary>
        /// Invoke commands
        /// </summary>
        void InvokeCommands();

        /// <summary>
        /// Get result
        /// </summary>
        /// <returns></returns>
        string GetResult();
    }
}
