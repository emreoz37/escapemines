using ESM.Core.Base.Animals.Turtles;
using ESM.Core.Base.Boards;
using ESM.Core.Base.Directions;
using ESM.Core.Base.Movements;
using ESM.Core.Base.Obstacles.Mines;
using ESM.Core.Base.Points;
using ESM.Core.Exceptions;
using ESM.Services.Animals.Turtles;
using ESM.Services.Animals.Turtles.Commands;
using ESM.Services.Animals.Turtles.Services;
using ESM.Services.Boards;
using ESM.Services.Obstacles.Mines;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace ESM.Tests.ESM.Services.Tests.Animals.Turtles
{
    public class TurtleMoveCommandTests
    {

        private readonly IBoard _board;
        private readonly IMine _mine;
        private readonly IExit _exit;
        private readonly ITurtle _turtle;
        private IBoardSetCommand _boardSetCommand;
        private IExitSetCommand _exitSetCommand;
        private IMineSetCommand _mineSetCommand;
        private ITurtleSetCommand _turtleSetCommand;
        private ITurtleMoveCommand _turtleMoveCommand;

        public TurtleMoveCommandTests()
        {
            ITurtleMoveService turtleMoveService = Mock.Of<TurtleMoveService>();
            _board = Mock.Of<Board>();
            _mine = Mock.Of<Mine>();
            _exit = Mock.Of<Exit>();
            _turtle = new Turtle(turtleMoveService);
        }

        [Fact]
        public void Should_ReturnMineHit_When_GivenTheSpecifiedInputs()
        {
            var movements = new List<Movement>
            {
                Movement.Right,
                Movement.Move,
                Movement.Left,
                Movement.Move
            };

            var mines = new List<IMine> { _mine };

            _boardSetCommand = new BoardSetCommand(new Size(5, 4));
            _boardSetCommand.Set(_board);
            _boardSetCommand.Execute();

            _mineSetCommand = new MineSetCommand(new Point(1, 2));
            _mineSetCommand.Set(_board, _mine);
            _mineSetCommand.Execute();

            _exitSetCommand = new ExitSetCommand(new Point(3, 3));
            _exitSetCommand.Set(_board, _exit);
            _exitSetCommand.Execute();

            _turtleSetCommand = new TurtleSetCommand(new TurtlePoint(0, 1, Direction.North));
            _turtleSetCommand.Set(_board, _turtle);
            _turtleSetCommand.Execute();

            _turtleMoveCommand = new TurtleMoveCommand(movements);
            _turtleMoveCommand.Set(_turtle, mines, _exit);
            _turtleMoveCommand.Execute();

            Assert.Equal("Mine Hit", _turtle.Result);

           
        }

        [Fact]
        public void Should_ReturnSuccess_When_GivenTheSpecifiedInputs()
        {
            var movements = new List<Movement>
            {
                Movement.Right,
                Movement.Move,
                Movement.Move,
                Movement.Move
            };

            var mines = new List<IMine>();

            _boardSetCommand = new BoardSetCommand(new Size(5, 4));
            _boardSetCommand.Set(_board);
            _boardSetCommand.Execute();

            _exitSetCommand = new ExitSetCommand(new Point(3, 1));
            _exitSetCommand.Set(_board, _exit);
            _exitSetCommand.Execute();

            _turtleSetCommand = new TurtleSetCommand(new TurtlePoint(0, 1, Direction.North));
            _turtleSetCommand.Set(_board, _turtle);
            _turtleSetCommand.Execute();

            _turtleMoveCommand = new TurtleMoveCommand(movements);
            _turtleMoveCommand.Set(_turtle, mines, _exit);
            _turtleMoveCommand.Execute();

            Assert.Equal("Success", _turtle.Result);

         
        }

        [Fact]
        public void Should_ReturnStillInDanger_When_GivenTheSpecifiedInputs()
        {
            var movements = new List<Movement>
            {
                Movement.Right,
                Movement.Move
            };

            var mines = new List<IMine>();

            _boardSetCommand = new BoardSetCommand(new Size(5, 4));
            _boardSetCommand.Set(_board);
            _boardSetCommand.Execute();

            _exitSetCommand = new ExitSetCommand(new Point(3, 3));
            _exitSetCommand.Set(_board, _exit);
            _exitSetCommand.Execute();

            _turtleSetCommand = new TurtleSetCommand(new TurtlePoint(0, 1, Direction.North));
            _turtleSetCommand.Set(_board, _turtle);
            _turtleSetCommand.Execute();

            _turtleMoveCommand = new TurtleMoveCommand(movements);
            _turtleMoveCommand.Set(_turtle, mines, _exit);
            _turtleMoveCommand.Execute();

            Assert.Equal("Still In Danger", _turtle.Result);

          
        }

        [Fact]
        public void Should_ThrowPointValidationException_When_TheAppHasInvalidPoints()
        {
            var movements = new List<Movement>
            {
                Movement.Right,
                Movement.Move,
                Movement.Move,
                Movement.Move,
                Movement.Move,
                Movement.Move,
                Movement.Move
            };

            var mines = new List<IMine>();

            _boardSetCommand = new BoardSetCommand(new Size(5, 4));
            _boardSetCommand.Set(_board);
            _boardSetCommand.Execute();

            _exitSetCommand = new ExitSetCommand(new Point(3, 1));
            _exitSetCommand.Set(_board, _exit);
            _exitSetCommand.Execute();

            _turtleSetCommand = new TurtleSetCommand(new TurtlePoint(0, 1, Direction.North));
            _turtleSetCommand.Set(_board, _turtle);
            _turtleSetCommand.Execute();

            _turtleMoveCommand = new TurtleMoveCommand(movements);
            _turtleMoveCommand.Set(_turtle, mines, _exit);
            _turtleMoveCommand.Execute();

           var exception =  Assert.Throws<PointValidationException>(() => _turtleMoveCommand.Execute());
            Assert.Equal("Turtle cannot go out of board!", exception.Message);
        }
    }
}
