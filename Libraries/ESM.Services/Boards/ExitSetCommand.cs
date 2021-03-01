using ESM.Core.Base.Boards;
using ESM.Core.Base.Points;

namespace ESM.Services.Boards
{
    /// <summary>
    /// Represents the concrete class of the exit set command
    /// </summary>
    public class ExitSetCommand : IExitSetCommand
    {
        #region Fields
        private readonly Point _point;
        private IBoard _board;
        private IExit _exit;
        #endregion

        #region CtOr

        #endregion
        public ExitSetCommand(Point point)
        {
            _point = point;
        }

        #region Methods
        /// <summary>
        /// Set
        /// </summary>
        /// <param name="board">Board</param>
        /// <param name="exit">Exit</param>
        public void Set(IBoard board, IExit exit)
        {
            _board = board;
            _exit = exit;
        }

        /// <summary>
        /// Execute
        /// </summary>
        public void Execute()
        {
            _exit.Set(_board, _point);
        }
        #endregion


    }
}
