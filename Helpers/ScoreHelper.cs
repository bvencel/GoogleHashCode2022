namespace GoogleHashCode2022
{
    public static class ScoreHelper
    {
        public static int CalculateScore(int promisedScore, int bestBefore, int usedDays)
        {
            int difference = usedDays - bestBefore;

            if (difference <= 0)
            {
                return promisedScore;
            }

            int scoreToReturn = promisedScore - difference < 0 ? 0 : difference;

            return scoreToReturn;
        }

        public static decimal CalculateSortingScore(Project project)
        {
            return (decimal)project.Score / (decimal)project.DurationInDays / (decimal)project.RolesWithTechnologies.Sum(t => t.Level);
        }

    }
}