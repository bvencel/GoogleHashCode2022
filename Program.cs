using GoogleHashCode2022;
using GoogleHashCode2022.Constants;
using GoogleHashCode2022.Helpers;

using Newtonsoft.Json;

using System.Text;

InputHelper.ProcessInput(Inputs.InputB, out List<Contributor> contributors, out List<Project> projects);

//string contributorsString = JsonConvert.SerializeObject(contributors, Formatting.Indented);
//string projectsString = JsonConvert.SerializeObject(projects, Formatting.Indented);

StringBuilder result = ProcessDay(0, projects, contributors);

Console.WriteLine(result.ToString());

static StringBuilder ProcessDay(int day, List<Project> projects, List<Contributor> freeContributors)
{
    StringBuilder result = new();

    // Try to start projects
    projects = projects.OrderByDescending(p => p.SortingScore).ToList();

    foreach (Project project in projects)
    {
        foreach (Skill skill in project.RolesWithTechnologies)
        {
            Contributor? candidate = GetBestContributorForSkill(skill, freeContributors);

            if (candidate is null)
            {
                freeContributors.AddRange(project.AssignedContributors);
                project.AssignedContributors.RemoveRange(0, project.AssignedContributors.Count);

                break;
            }

            freeContributors.Remove(candidate);
            project.AssignedContributors.Add(candidate);
        }

        project.IsStarted = true;
        result.Append($"");
    }

    List<Project> startedProjects = projects.Where(p => p.IsStarted).ToList();

    bool progressWasMade = false;

    foreach (Project project in startedProjects)
    {
        // Increase ellapsed day in projects that were started
        // Eliberate resources from projects that are finished

        // If any opf the projects was running
        progressWasMade = true;
    }

    if (progressWasMade)
    {
        ProcessDay(day++, projects, freeContributors);
    }

    return result;
}

static Contributor? GetBestContributorForSkill(Skill skill, List<Contributor> freeContributors)
{
    if (freeContributors.Count == 0)
    {
        return null;
    }
    List<Contributor> candidates = freeContributors.Where(c => c.Skills.Any(s => s.SkillName == skill.SkillName && s.Level >= skill.Level)).ToList().OrderBy(c => c.Skills.Sum(s => s.Level)).ToList();

    if (candidates.Count > 0)
    {
        return candidates[0];
    }
    else
    {
        return null;
    }
}