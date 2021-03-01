namespace ESM.Core.Infrastructure
{
    /// <summary>
    /// Represents the conctract of command
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// Execute
        /// </summary>
        void Execute();
    }
}
