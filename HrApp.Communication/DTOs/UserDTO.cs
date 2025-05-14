namespace HRApp.Communication;

public class RoleInfoDto
{
    public string Position { get; set; }
    public string Department { get; set; }
    public string Team { get; set; }
    public string Manager { get; set; }
}

public class UserProjectDto
{
    public string Name { get; set; }
    public string Role { get; set; }
    public string Status { get; set; }
    public string StatusClass { get; set; }
}

public class UserDocumentDto
{
    public string Name { get; set; }
    public string Date { get; set; }
}

public class CurrentSalaryDto
{
    public string GrossMonthly { get; set; }
    public string NetMonthly { get; set; }
    public string AnnualBonus { get; set; }
    public string LastReview { get; set; }
}

public class UserHierarchyDto
{
    public TeamMemberDto Manager { get; set; }
    public TeamMemberDto CurrentEmployee { get; set; }
    public List<TeamMemberDto> TeamMembers { get; set; }
}

public class TeamMemberDto
{
    public string Name { get; set; }
    public string Role { get; set; }
    public string Image { get; set; }
}