using Application.Interfaces.InsuranceCharges.Queries;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.Insurance;

public class InsuranceController : BaseController
{
    [HttpGet]
    public async Task<IActionResult> CalculateCharge()
    {
        var result = await Mediator.Send(new GetInsuranceCharge());
        return Ok(result);
    }
}