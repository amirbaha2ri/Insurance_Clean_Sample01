using Application.Interfaces.InsuranceCoverages.Commands;
using Application.Interfaces.InsuranceCoverages.Queries;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.Insurance;

public class InsuranceCoverageController : BaseController
{
    [HttpPost("[action]")]
    public async Task<IActionResult> Add(AddInsuranceCoverageCommand command) =>
        Ok(await Mediator.Send(command));
    
    [HttpGet("[action]")]
    public async Task<IActionResult> GetList() =>
        Ok(await Mediator.Send(new GetInsuranceCoverageListQuery()));
}