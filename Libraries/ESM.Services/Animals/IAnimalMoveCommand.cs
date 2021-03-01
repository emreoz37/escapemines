using ESM.Core.Base.Animals;
using ESM.Core.Base.Boards;
using ESM.Core.Base.Movements;
using ESM.Core.Base.Obstacles;
using ESM.Core.Infrastructure;
using System.Collections.Generic;

namespace ESM.Services.Animals
{
    /// <summary>
    /// Generic animal move command of <see cref="ICommand"/>
    /// </summary>
    /// <typeparam name="TAnimal">Animal</typeparam>
    /// <typeparam name="YObstacle">Obstacle</typeparam>
    public interface IAnimalMoveCommand<TAnimal, YObstacle> : ICommand
        where TAnimal: IAnimal
        where YObstacle : IObstacle
    {
        /// <summary>
        /// Gets or sets the value of movements
        /// </summary>
        IList<Movement> Movements { get; set; }

        /// <summary>
        /// Set
        /// </summary>
        /// <param name="animal">Animal</param>
        /// <param name="obstacles">Obstacles</param>
        /// <param name="exit">Exit</param>
        void Set(TAnimal animal, IEnumerable<YObstacle> obstacles, IExit exit);
    }
}
