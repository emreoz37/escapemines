using ESM.Core.Base.Animals;
using ESM.Core.Base.Boards;
using ESM.Core.Infrastructure;

namespace ESM.Services.Animals
{
    /// <summary>
    /// Generic animal set command of <see cref="ICommand">
    /// </summary>
    /// <typeparam name="TAnimal">Animal</typeparam>
    public interface IAnimalSetCommand<TAnimal>  : ICommand where TAnimal : IAnimal
    {
        /// <summary>
        /// Set
        /// </summary>
        /// <param name="board">Board</param>
        /// <param name="animal">Animal</param>
        void Set(IBoard board, TAnimal animal);
    }
}
