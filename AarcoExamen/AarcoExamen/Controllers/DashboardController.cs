using AarcoExamen.Application.Models.RequestModels;
using AarcoExamen.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AarcoExamen.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly ICarRepository _repository;

        public DashboardController(ICarRepository repository)
        {
            _repository = repository;
        }

        [HttpPost("dashboard")]
        public async Task<IActionResult> GetDashboard([FromBody] DashboardRequest request)
        {
            var result = await _repository.GetDashboardData(request.FilterType, request.FilterValue);
            return Ok(result);
        }
    }
}
