namespace HRApp.Communication;

public class ColleagueDto
{
    public int Id { get; set; }
    public string Name { get; set; }         
    public string Role { get; set; }
    public string Responsibilities { get; set; }  
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Avatar { get; set; }
    public List<string> Projects { get; set; }
}