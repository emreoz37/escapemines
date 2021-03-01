using ESM.Core.Base.Boards;

namespace ESM.Services.Boards
{
    /// <summary>
    /// Represents the concrete class of the board set command
    /// </summary>
    public class BoardSetCommand : IBoardSetCommand
    {
        #region Fields
        private IBoard _board;

        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the value of size
        /// </summary>
        public Size Size { get; }

        #endregion

        #region CtOr
        public BoardSetCommand(Size size)
        {
            Size = size;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Set
        /// </summary>
        /// <param name="board">Board</param>
        public void Set(IBoard board)
        {
            _board = board;
        }

        /// <summary>
        /// Execute
        /// </summary>
        public void Execute()
        {
            _board.SetSize(Size);
        }
        #endregion


    }
}
