using Petfolio.Comunication.Responses;

namespace Petfolio.Aplication.UseCases.Pet.GetById;

public class GetPetByIdUseCase
{
    public ResponsePetJson Execute(int id)
    {
        return new ResponsePetJson
        {
            Id = id,
            Name = "Firulais",
            BirthDate = DateTime.Now,
            Type = Comunication.Enums.PetType.Dog,
        };
    }
}
