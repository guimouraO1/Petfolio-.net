using Petfolio.Comunication.Requests;
using Petfolio.Comunication.Responses;

namespace Petfolio.Aplication.UseCases.Pet.Register;

public class RegisterPetUseCase
{
    public ResponseRegisteredPetJson Execute(RequestPetJson request)
    {
        return new ResponseRegisteredPetJson { Id = 7, Name = request.Name };
    }
}
