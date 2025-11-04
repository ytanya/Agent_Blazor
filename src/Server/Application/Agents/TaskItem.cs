using System;

namespace BlazorHero.CleanArchitecture.Server.Application.Agents
{
    public class TaskItem
    {
        public int Id { get; set; }
        public string Title { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string Status { get; set; } = "Pending";
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
    }

}
