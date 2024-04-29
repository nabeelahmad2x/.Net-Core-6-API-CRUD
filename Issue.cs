using System.ComponentModel.DataAnnotations;

namespace myCoreAPI
{
    public class Issue
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }

        public priority Priority { get; set; }
        public issueType IssueType { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Completed { get; set; }
    }

    public enum priority { Low, Medium, High }
    public enum issueType { Feature, Bug, Documentation }
}