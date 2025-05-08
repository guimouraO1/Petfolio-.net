using Petfolio.Comunication.Responses;

namespace Petfolio.Aplication.UseCases.Pet.GetAll;

public class GetAllPetsUseCase
{
    public ResponseAllPetJson Execute()
    {
        return new ResponseAllPetJson
        {
            Pets = new List<ResponseShortPetJson>
            {
                new ResponseShortPetJson
                {
                    Id = 1,
                    Name = "Firulais",
                    Type = Comunication.Enums.PetType.Dog,
                }
            }
        };
    }
}
