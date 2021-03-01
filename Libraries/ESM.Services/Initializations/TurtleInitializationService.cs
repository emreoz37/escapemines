using ESM.Core.Base.Boards;
using ESM.Core.Base.Obstacles.Mines;
using ESM.Core.Infrastructure;
using ESM.Services.Animals.Turtles;
using ESM.Services.Animals.Turtles.Commands;
using ESM.Services.Boards;
using ESM.Services.Obstacles.Mines;
using System.Collections.Generic;

namespace ESM.Services.Initializations
{
    /// <summary>
    /// Represents the concrete class of the turtle initialization service
    /// </summary>
    public class TurtleInitializationService : IInitializationService<ITurtle, IMine>
    {
        #region Methods
        /// <summary>
        /// Initialization Board Set Command
        /// </summary>
        /// <param name="board">Board</param>
        /// <param name="command">Command</param>
        public void InitializationBoardSetCommand(IBoard board, ICommand command)
        {
            var boardSetCommand = (IBoardSetCommand)command;
            boardSetCommand.Set(board);
        }

        /// <summary>
        /// Initialization Exit Set Command
        /// </summary>
        /// <param name="board">Board</param>
        /// <param name="exit">Exit</param>
        /// <param name="command">Command</param>
        public void InitializationExitSetCommand(IBoard board, IExit exit, ICommand command)
        {
            var exitSetCommand = (IExitSetCommand)command;
            exitSetCommand.Set(board, exit);
        }

        /// <summary>
        /// Initialization Obstacle Set Command
        /// </summary>
        /// <param name="board">Board</param>
        /// <param name="mines">Mines</param>
        /// <param name="command">Command</param>
        public void InitializationObstacleSetCommand(IBoard board, IList<IMine> mines, ICommand command)
        {
            var mine = new Mine();
            mines.Add(mine);
            var mineSetCommand = (IMineSetCommand)command;
            mineSetCommand.Set(board, mine);
        }


        /// <summary>
        /// Initialization Animal Set Command
        /// </summary>
        /// <param name="board">Board</param>
        /// <param name="turtle">Turtle</param>
        /// <param name="command">Command</param>
        public void InitializationAnimalSetCommand(IBoard board, ITurtle turtle, ICommand command)
        {
            var turtleSetCommand = (ITurtleSetCommand)command;
            turtleSetCommand.Set(board, turtle);
        }

        /// <summary>
        /// Initializatiob animal move command
        /// </summary>
        /// <param name="turtle">Animal</param>
        /// <param name="mines">Obstacles</param>
        /// <param name="exit">Exit</param>
        /// <param name="command">Command</param>
        public void InitializationAnimalMoveCommand(ITurtle turtle, IEnumerable<IMine> mines, IExit exit, ICommand command)
        {
            var turtleMoveCommand = (ITurtleMoveCommand)command;
            turtleMoveCommand.Set(turtle, mines, exit);
        }
        #endregion

    }
}
