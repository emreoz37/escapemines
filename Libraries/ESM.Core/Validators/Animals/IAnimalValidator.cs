using System.Collections.Generic;

namespace ESM.Core.Validators.Animals
{
    public interface IAnimalValidator
    {
        void IsValidAnimalStartingPoint(IList<string> directions, string animalStartingPoint, string separator = "");
        void IsValidAnimalMovements(IList<string> listOfMovements, string animalMovements, string seperator = " ");
    }
}
