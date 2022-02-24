namespace GoogleHashCode2022
{
    public static class MatchingHelper
    {
        private static List<ExecutedProject> executedProjects = new();

        static void MatchContributors(List<Project> projects, List<Contributor> contributors)
        {
            foreach (var project in projects)
            {
                foreach (var role in project.RolesWithTechnologies)
                {
                    //foreach(var contributor in contributors.OrderBy())
                    //{
                    //}
                }
            }
        }
    }
}