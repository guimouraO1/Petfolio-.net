using Microsoft.AspNetCore.Mvc;
using Petfolio.Aplication.UseCases.Pet.Register;
using Petfolio.Aplication.UseCases.Pet.Update;
using Petfolio.Comunication.Requests;
using Petfolio.Comunication.Responses;

namespace Petfolio.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PetController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(ResponseRegisteredPetJson), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    public IActionResult Register([FromBody] RequestPetJson request)
    {
        var response = new RegisterPetUseCase().Execute(request);
 
        return Created(string.Empty, response);
    }


    [HttpPut]
    [Route("[id]")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    public IActionResult Update([FromRoute] int id, [FromBody] RequestPetJson request)
    {
        new UpdatePetUseCase().Execute(id, request);

        return NoContent();
    }

}
