using System.IO;
using System.Threading.Tasks;

namespace BlazorHero.CleanArchitecture.Server.Application.Agents
{
    public class AgentService
    {
        public async Task GenerateCodeAsync(TaskItem task)
        {
            await File.WriteAllTextAsync($"Generated_{task.Title}.txt", $"Generated code for: {task.Description}");
            task.Status = "Done";
        }
    }

}
