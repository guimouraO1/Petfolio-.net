using Microsoft.AspNetCore.Mvc;
using Petfolio.Aplication.UseCases.Pet.GetAll;
using Petfolio.Aplication.UseCases.Pet.GetById;
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

    [HttpGet]
    [ProducesResponseType(typeof(ResponseAllPetJson), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult GetAll()
    {
        var useCase = new GetAllPetsUseCase();

        var response = useCase.Execute();

        if (response.Pets.Any()) {
            return Ok(response);
        }

        return NoContent();
    }

    [HttpGet]
    [Route("[id]")]
    [ProducesResponseType(typeof(ResponsePetJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public IActionResult Get(int id)
    {
        var useCase = new GetPetByIdUseCase();

        var response = useCase.Execute(id);

        return Ok(response);
    }


}
