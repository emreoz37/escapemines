using ESM.Core.Base.Boards;
using ESM.Core.Infrastructure;

namespace ESM.Services.Boards
{
    /// <summary>
    /// Represents the conctract of command
    /// </summary>
    public interface IExitSetCommand : ICommand
    {
        /// <summary>
        /// Set
        /// </summary>
        /// <param name="board">Board</param>
        /// <param name="exit">Exit</param>
        void Set(IBoard board, IExit exit);
    }
}
