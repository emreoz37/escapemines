using ESM.Core.Base.Boards;
using ESM.Core.Base.Movements;
using ESM.Core.Base.Obstacles.Mines;
using System.Collections.Generic;

namespace ESM.Services.Animals.Turtles.Commands
{
    /// <summary>
    /// Represents the concrete class of the turtle move command
    /// </summary>
    public class TurtleMoveCommand : ITurtleMoveCommand
    {
        #region Fields
        private ITurtle _turtle;
        private IEnumerable<IMine> _mines;
        private IExit _exit;
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the value of movements
        /// </summary>
        public IList<Movement> Movements { get; set; }

        #endregion

        #region CtOr
        public TurtleMoveCommand(IList<Movement> movements)
        {
            Movements = movements;
        }

        #endregion

        #region Methods
        /// <summary>
        /// Execute
        /// </summary>
        public void Execute()
        {
            _turtle.Move(Movements, _mines, _exit);
        }

        /// <summary>
        /// Set
        /// </summary>
        /// <param name="turtle">Turtle</param>
        /// <param name="mines">Mines collections</param>
        /// <param name="exit">Exit</param>
        public void Set(ITurtle turtle, IEnumerable<IMine> mines, IExit exit)
        {
            _turtle = turtle;
            _mines = mines;
            _exit = exit;
        }
        #endregion

    }
}
