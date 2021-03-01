using ESM.Core.Base.Animals;
using ESM.Core.Base.Boards;
using ESM.Core.Base.Obstacles;
using ESM.Core.Infrastructure;
using System.Collections.Generic;

namespace ESM.Services.Initializations
{
    /// <summary>
    /// Represents the conctract of initialization service
    /// </summary>
    /// <typeparam name="T">Animal</typeparam>
    /// <typeparam name="Y">Obstacle</typeparam>
    public interface IInitializationService<T,Y> 
        where T: IAnimal
        where Y: IObstacle
    {
        /// <summary>
        /// Initialization Board Set Command
        /// </summary>
        /// <param name="board">Board</param>
        /// <param name="command">Command</param>
        void InitializationBoardSetCommand(IBoard board, ICommand command);

        /// <summary>
        /// Initialization Exit Set Command
        /// </summary>
        /// <param name="board">Board</param>
        /// <param name="exit">Exit</param>
        /// <param name="command">Command</param>
        void InitializationExitSetCommand(IBoard board, IExit exit, ICommand command);

        /// <summary>
        /// Initialization Obstacle Set Command
        /// </summary>
        /// <param name="board">Board</param>
        /// <param name="obstacles">Obstacles</param>
        /// <param name="command">Command</param>
        void InitializationObstacleSetCommand(IBoard board, IList<Y> obstacles, ICommand command);

        /// <summary>
        /// Initialization Animal Set Command
        /// </summary>
        /// <param name="board">Board</param>
        /// <param name="animal">Animal</param>
        /// <param name="command">Command</param>
        void InitializationAnimalSetCommand(IBoard board, T animal, ICommand command);

        /// <summary>
        /// Initializatiob animal move command
        /// </summary>
        /// <param name="animal">Animal</param>
        /// <param name="obstacles">Obstacles</param>
        /// <param name="exit">Exit</param>
        /// <param name="command">Command</param>
        void InitializationAnimalMoveCommand(T animal, IEnumerable<Y> obstacles, IExit exit, ICommand command);
    }
}
