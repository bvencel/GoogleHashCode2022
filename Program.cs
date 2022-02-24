using GoogleHashCode2022;

using Newtonsoft.Json;

string input = @"3 3
Anna 1
C++ 2
Bob 2
HTML 5
CSS 5
Maria 1
Python 3
Logging 5 10 5 1
C++ 3
WebServer 7 10 7 2
HTML 3
C++ 2
WebChat 10 20 20 2
Python 3
HTML 3";

List<Contributor> contributors = new List<Contributor>();

List<string> lines = input.Split(Environment.NewLine).ToList();

string nrContributorsString = lines[0].Split(' ')[0];
string nrProjectsString = lines[0].Split(' ')[1];

int.TryParse(nrContributorsString, out int nrContributors);
int.TryParse(nrProjectsString, out int nrProjects);

int linesBefore = 1;

for (int i = 0; i < nrContributors; i++)
{
    string contributorString = lines[linesBefore + i];
    string contributorName = contributorString.Split(' ')[0];
    int.TryParse(contributorString.Split(' ')[1], out int nrSkills);

    Contributor contributor = new()
    {
        Name = contributorName
    };

    int linesBeforeSkill = linesBefore + i + 1;

    for (int j = 0; j < nrSkills; j++)
    {
        string skillString = lines[linesBeforeSkill + j];
        string skillName = skillString.Split(' ')[0];
        int.TryParse(skillString.Split(' ')[1], out int skillLevel);

        Skill skill = new()
        {
            SkillName = skillName,
            Level = skillLevel,
        };

        contributor.Skills.Add(skill);
    }

    contributors.Add(contributor);
}

string contributorsString = JsonConvert.SerializeObject(contributors);
Console.WriteLine(contributorsString);
