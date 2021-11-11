namespace HW7Project.Models
{
    public class Commit
    {
        public string ShortShaHash { get; set; }
        public string TimeStamp { get; set; }
        public string Committer { get; set; }
        public string CommitMessage { get; set; }
        public string CommitPageUrl { get; set; }
    }
}