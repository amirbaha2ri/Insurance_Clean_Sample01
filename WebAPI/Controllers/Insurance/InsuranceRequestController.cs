using Application.Interfaces.InsuranceCharges.Queries;
using Application.Interfaces.InsuranceRequests.Commands;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.Insurance;

public class InsuranceRequestController : BaseController
{
    [HttpPost("[action]")]
    public async Task<IActionResult> Add(AddInsuranceRequestCommand command) =>
        Ok(await Mediator.Send(command));
    
    
    [HttpPost("[action]")]
    public async Task<IActionResult> CalculateCharge(GetInsuranceRequestListQuery request) =>
    Ok(await Mediator.Send(request));
}