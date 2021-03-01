using ESM.Core.Base.Boards;
using ESM.Core.Infrastructure;

namespace ESM.Services.Boards
{
    /// <summary>
    /// Represents the conctract of board set command <see cref="ICommand"/>
    /// </summary>
    public interface IBoardSetCommand : ICommand
    {
        /// <summary>
        /// Set
        /// </summary>
        /// <param name="board">Board</param>
        void Set(IBoard board);

    }
}
