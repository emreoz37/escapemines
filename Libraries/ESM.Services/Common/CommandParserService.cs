using ESM.Core.Base.Animals.Turtles;
using ESM.Core.Base.Boards;
using ESM.Core.Base.Directions;
using ESM.Core.Base.Points;
using ESM.Core.Base.Movements;
using ESM.Core.Exceptions;
using ESM.Core.Infrastructure;
using ESM.Core.Validators.Animals;
using ESM.Core.Validators.Boards;
using ESM.Core.Validators.Obstacles;
using ESM.Services.Animals.Turtles.Commands;
using ESM.Services.Boards;
using ESM.Services.Obstacles.Mines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ESM.Services.Common
{
    /// <summary>
    /// Represents the concrete class of the command parser service
    /// </summary>
    public class CommandParserService : ICommandParserService
    {
        #region Fields
        private readonly IAnimalValidator _animalValidator;
        private readonly IBoardValidator _boardValidator;
        private readonly IExitValidator _exitValidator;
        private readonly IObstaclesValidator _obstaclesValidator;
        #endregion

        #region CtOr
        public CommandParserService(IAnimalValidator animalValidator,
            IBoardValidator boardValidator,
            IExitValidator exitValidator,
            IObstaclesValidator obstaclesValidator)
        {
            _animalValidator = animalValidator;
            _boardValidator = boardValidator;
            _exitValidator = exitValidator;
            _obstaclesValidator = obstaclesValidator;
        }
        #endregion

        #region Utilities
        private ICommand ParseBoardSetCommand(string instruction)
        {
            // Sample instruction input: "5 4"
            var instructions = instruction.Split(' '); // 5, 4
            var x = int.Parse(instructions[0]); // 5
            var y = int.Parse(instructions[1]); // 4

            return new BoardSetCommand(new Size(x, y));
        }

        private ICommand ParseMineSetCommand(string instruction)
        {
            // Sample instruction input: "1,1"
            var instructions = instruction.Split(','); // 1, 2
            var x = int.Parse(instructions[0]); // 1
            var y = int.Parse(instructions[1]); // 2

            return new MineSetCommand(new Point(x, y));
        }

        private ICommand ParseExitSetCommand(string instruction)
        {
            // Sample instruction input: "1 2"
            var instructions = instruction.Split(' '); // 1, 2
            var x = int.Parse(instructions[0]); // 1
            var y = int.Parse(instructions[1]); // 2

            return new ExitSetCommand(new Point(x, y));
        }

        private ICommand ParseTurtleSetCommand(string instruction)
        {
            // Sample instruction input: "1 2 N"
            var instructions = instruction.Split(' '); // 1, 2, N
            var x = int.Parse(instructions[0]); // 1
            var y = int.Parse(instructions[1]); // 2
            var directionString = instructions[2][0]; // N

            return new TurtleSetCommand(new TurtlePoint(x, y, (Direction)directionString));
        }

        private ICommand ParseTurtleMoveCommand(string instruction)
        {
            // Sample instruction input: "R M L M M"
            var instructions = instruction.Split(' ');

            string ParseToEnumName(string value)
            {
                switch (value)
                {
                    case "M":
                        return "Move";
                    case "R":
                        return "Right";
                    case "L":
                        return "Left";
                    default:
                        throw new ApplicationException($"'{value}' is not a valid instruction");
                }
            }

            var moves = instructions.Select(move => Enum.Parse<Movement>(ParseToEnumName(move))).ToList();

            return new TurtleMoveCommand(moves);
        }
        #endregion

        #region Methods
        /// <summary>
        /// Parses all instructions and returns the command interface list.
        /// </summary>
        /// <param name="instructions">String</param>
        /// <returns>Commands</returns>
        public IEnumerable<ICommand> Parse(string instructions)
        {
            if (string.IsNullOrWhiteSpace(instructions))
                throw new ArgumentNullException(null,"Instructions parameter cannot be null or empty");

            var instructionLines = instructions.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);

            if (instructionLines.Length < GameSettingsDefaults.MinimumFormatLength)
                throw new ArgumentException($"The length of the settings cannot be lower than minimum length {GameSettingsDefaults.MinimumFormatLength}");

            var commands = new List<ICommand>();

            #region Line 1: The first line should define the board size

            var boardSize = instructionLines[0];
            _boardValidator.IsValidBoardSize(boardSize);

            commands.Add(ParseBoardSetCommand(boardSize));


            #endregion

            #region Line 2: The second line should contain a list of mines (i.e. list of co-ordinates separate by a space)

            var listOfMines = instructionLines[1];
            _obstaclesValidator.IsValidListOfObstacles(listOfMines);

            var point = listOfMines.Split(' '); // 1,1 1,3 3,3
            commands.AddRange(point.Select(ParseMineSetCommand));


            #endregion

            #region Line 3: The third line of the file should contain the exit point

            var exitPoint = instructionLines[2];
            _exitValidator.IsValidExitPoint(exitPoint);

            commands.Add(ParseExitSetCommand(exitPoint));


            #endregion

            #region Line 4: The fourth line of the file should contain the starting position of the turtle.

            var turtleStartingPosition = instructionLines[3];
            var directions = Enum.GetValues(typeof(Direction)).Cast<Direction>().Select(x => x.ToString()).ToList();
            _animalValidator.IsValidAnimalStartingPoint(directions, turtleStartingPosition);

            commands.Add(ParseTurtleSetCommand(turtleStartingPosition));


            #endregion

            #region Line 5, ...: The fifth line to the end of the file should contain a series of moves.

            var movementInstructions = new StringBuilder();

            foreach (var instructionLine in instructionLines.Skip(4))
            {
                var movements = Enum.GetValues(typeof(Movement)).Cast<Movement>().Select(x => x.ToString()).ToList();
                _animalValidator.IsValidAnimalMovements(movements, instructionLine);

                movementInstructions.AppendFormat("{0} ", instructionLine);

            }

            if (!string.IsNullOrEmpty(movementInstructions.ToString()))
            {
                commands.Add(ParseTurtleMoveCommand(movementInstructions.ToString().Trim()));
            }

            #endregion

            return commands;
        }
        #endregion



    }
}
