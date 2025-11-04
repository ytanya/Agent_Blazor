using System.Threading.Tasks;
using BlazorHero.CleanArchitecture.Server.Application.Agents;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml.Core;

namespace BlazorHero.CleanArchitecture.Server.Controllers.Agents
{
    [ApiController]
    [Route("api/[controller]")]

    public class AgentController : ControllerBase
    {
        private readonly AgentService _agent;

        public AgentController(AgentService agent)
        {
            _agent = agent;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(TaskItem task)
        {
            await _agent.GenerateCodeAsync(task);
            return Ok(task);
        }

        [HttpPost("reopen")]
        public IActionResult Reopen(TaskItem task)
        {
            task.Status = "Reopened";
            return Ok(task);
        }

        [HttpPost("close")]
        public async Task<IActionResult> Close(TaskItem task)
        {
            task.Status = "Closed";
            await GitHelper.CommitAndPushAsync($"Close task {task.Title}");
            return Ok(task);
        }

    }
}
