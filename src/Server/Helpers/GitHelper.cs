namespace BlazorHero.CleanArchitecture.Server.Helpers
{
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using LibGit2Sharp;

    public static class GitHelper
    {
        public static async Task CommitAndPushAsync(string message)
        {
            var repoPath = Directory.GetCurrentDirectory();
            using var repo = new Repository(repoPath);
            Commands.Stage(repo, "*");

            var author = new Signature("Agent Bot", "agent@localhost", DateTime.Now);
            repo.Commit(message, author, author);

            var remote = repo.Network.Remotes["origin"];
            var options = new PushOptions
            {
                CredentialsProvider = (_, _, _) =>
                    new UsernamePasswordCredentials
                    {
                        Username = "YOUR_GITHUB_USERNAME",
                        Password = "YOUR_GITHUB_TOKEN"
                    }
            };

            repo.Network.Push(remote, @"refs/heads/main", options);
        }
    }

}
