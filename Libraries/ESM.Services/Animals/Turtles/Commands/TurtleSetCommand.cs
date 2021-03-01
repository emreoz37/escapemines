using ESM.Core.Base.Animals.Turtles;
using ESM.Core.Base.Boards;

namespace ESM.Services.Animals.Turtles.Commands
{
    /// <summary>
    /// Represents the concrete class of the turtle set command
    /// </summary>
    public class TurtleSetCommand : ITurtleSetCommand
    {
        #region Fields
        private readonly TurtlePoint _point;
        private IBoard _board;
        private ITurtle _turtle;
        #endregion

        #region CtOr
        public TurtleSetCommand(TurtlePoint point)
        {
            _point = point;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Set
        /// </summary>
        /// <param name="board">Board</param>
        /// <param name="turtle">Turtle</param>
        public void Set(IBoard board, ITurtle turtle)
        {
            _board = board;
            _turtle = turtle;
        }

        /// <summary>
        /// Execute
        /// </summary>
        public void Execute()
        {
            _turtle.Set(_board, _point);
        }
        #endregion

    }
}
