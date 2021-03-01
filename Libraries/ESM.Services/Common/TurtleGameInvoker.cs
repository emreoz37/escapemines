using ESM.Core.Base.Boards;
using ESM.Core.Base.Obstacles.Mines;
using ESM.Core.Infrastructure;
using ESM.Services.Animals.Turtles;
using ESM.Services.Animals.Turtles.Commands;
using ESM.Services.Boards;
using ESM.Services.Initializations;
using ESM.Services.Obstacles.Mines;
using System.Collections.Generic;

namespace ESM.Services.Common
{
    /// <summary>
    /// Represents the concrete class of the turtle game invoker
    /// </summary>
    public class TurtleGameInvoker : IInvoker
    {
        #region Fields
        private readonly IBoard _board;
        private readonly IList<IMine> _mines;
        private readonly IExit _exit;
        private readonly ITurtle _turtle;
        private readonly IInitializationService<ITurtle, IMine> _initializationService;
        private IEnumerable<ICommand> _commands;
        #endregion

        #region CtOr
        public TurtleGameInvoker(IBoard board,
            IExit exit,
            ITurtle turtle,
            IInitializationService<ITurtle, IMine> initializationService)
        {
            _board = board;
            _mines = new List<IMine>();
            _exit = exit;
            _turtle = turtle;
            _initializationService = initializationService;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Set commands
        /// </summary>
        /// <param name="commands">Commands</param>
        public void SetCommands(IEnumerable<ICommand> commands)
        {
            _commands = commands;
        }
        #endregion

        /// <summary>
        /// Invoke commands
        /// </summary>
        public void InvokeCommands()
        {
            foreach (var command in _commands)
            {
                var name = command.GetType().GetInterfaces()[0].Name;
                switch (name)
                {
                    case nameof(IBoardSetCommand):
                        _initializationService.InitializationBoardSetCommand(_board, command);
                        break;

                    case nameof(IExitSetCommand):
                        _initializationService.InitializationExitSetCommand(_board, _exit, command);
                        break;

                    case nameof(IMineSetCommand):
                        _initializationService.InitializationObstacleSetCommand(_board, _mines, command);
                        break;

                    case nameof(ITurtleSetCommand):
                        _initializationService.InitializationAnimalSetCommand(_board, _turtle, command);
                        break;

                    case nameof(ITurtleMoveCommand):
                        _initializationService.InitializationAnimalMoveCommand(_turtle, _mines, _exit, command);
                        break;
                }
                command.Execute();
            }
        }

        /// <summary>
        /// Get result
        /// </summary>
        /// <returns></returns>
        public string GetResult()
        {
            return _turtle.Result;
        }
    }
}
