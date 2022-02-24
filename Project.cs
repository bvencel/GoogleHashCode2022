namespace GoogleHashCode2022
{
    public class Project
    {
        public int BestBefore { get; set; }

        public int DurationInDays { get; set; }

        public string Name { get; set; } = string.Empty;

        public List<Skill> RolesWithTechnologies { get; set; } = new();

        public int Score { get; set; }

        public decimal SortingScore
        {
            get
            {
                return Score / DurationInDays / RolesWithTechnologies.Sum(t => t.Level);
            }
        }

        public List<Contributor> AssignedContributors { get; set; } = new();

        public int EllapsedDays { get; set; }

        public bool IsStarted { get; set; }
    }
}