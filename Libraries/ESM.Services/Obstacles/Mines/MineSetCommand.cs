using ESM.Core.Base.Boards;
using ESM.Core.Base.Points;
using ESM.Core.Base.Obstacles.Mines;

namespace ESM.Services.Obstacles.Mines
{
    /// <summary>
    /// Represents the concrete class of the mine set command
    /// </summary>
    public class MineSetCommand : IMineSetCommand
    {
        #region Fields
        private readonly Point _point;
        private IBoard _board;
        private IMine _mine;
        #endregion

        #region CtOr
        public MineSetCommand(Point point)
        {
            _point = point;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Set
        /// </summary>
        /// <param name="board">Board</param>
        /// <param name="mine">Mine</param>
        public void Set(IBoard board, IMine mine)
        {
            _board = board;
            _mine = mine;
        }

        /// <summary>
        /// Execute
        /// </summary>
        public void Execute()
        {
            _mine.Set(_board, _point);
        }
        #endregion

    }
}
