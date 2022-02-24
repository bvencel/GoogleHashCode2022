using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleHashCode2022.Helpers
{
    internal static class InputHelper
    {
        public static void ProcessInput(string input, out List<Contributor> contributors, out List<Project> projects)
        {
            contributors = new();

            List<string> lines = input.Split(Environment.NewLine).ToList();

            string nrContributorsString = lines[0].Split(' ')[0];
            string nrProjectsString = lines[0].Split(' ')[1];

            _ = int.TryParse(nrContributorsString, out int nrContributors);
            _ = int.TryParse(nrProjectsString, out int nrProjects);

            int currentLine = 1;

            // Parse collaborators
            for (int i = 0; i < nrContributors; i++)
            {
                string contributorString = lines[currentLine];
                string contributorName = contributorString.Split(' ')[0];
                _ = int.TryParse(contributorString.Split(' ')[1], out int nrSkills);

                Contributor contributor = new()
                {
                    Name = contributorName
                };

                contributors.Add(contributor);
                currentLine++;

                // Parse skills
                for (int j = 0; j < nrSkills; j++)
                {
                    string skillString = lines[currentLine];
                    string skillName = skillString.Split(' ')[0];
                    _ = int.TryParse(skillString.Split(' ')[1], out int skillLevel);

                    Skill skill = new()
                    {
                        SkillName = skillName,
                        Level = skillLevel,
                    };

                    contributor.Skills.Add(skill);
                    currentLine++;
                }
            }

            // Parse projects

            projects = new();

            for (int i = 0; i < nrProjects; i++)
            {
                /*
                an integer Di (1 ≤Di ≤ 105) – the number of days it takes to complete the project,
                an integer Si (1 ≤ Si ≤ 105) – the score awarded for project’s completion,
                an integer Bi (1 ≤ Bi ≤ 105) – the “best before” day for the project,
                an integer Ri (1 ≤ Ri ≤ 100) – the number of roles in the project.
                */

                string projectString = lines[currentLine];
                string projectName = projectString.Split(' ')[0];
                _ = int.TryParse(projectString.Split(' ')[1], out int projectDuration);
                _ = int.TryParse(projectString.Split(' ')[2], out int projectScore);
                _ = int.TryParse(projectString.Split(' ')[3], out int projectBestBefore);
                _ = int.TryParse(projectString.Split(' ')[4], out int nrProjectSkills);

                Project project = new()
                {
                    BestBefore = projectBestBefore,
                    DurationInDays = projectDuration,
                    Name = projectName,
                    Score = projectScore,
                };

                projects.Add(project);
                currentLine++;

                // Parse required skills
                for (int j = 0; j < nrProjectSkills; j++)
                {
                    string skillString = lines[currentLine];
                    string skillName = skillString.Split(' ')[0];
                    _ = int.TryParse(skillString.Split(' ')[1], out int skillLevel);

                    Skill skill = new()
                    {
                        SkillName = skillName,
                        Level = skillLevel,
                    };

                    project.RolesWithTechnologies.Add(skill);
                    currentLine++;
                }
            }
        }
    }
}
