namespace HRApp.Communication;

public class TaskDTO
{
    public string Name { get; set; }

    public string Description { get; set; }

    public string Status { get; set; }

    public int Priority { get; set; }

    public string AssignedTo { get; set; }

    public string CreatedBy { get; set; }

    public TaskActionDTO Action { get; set; }
}

public class TaskActionDTO
{
    public string Type { get; set; }
    public string Url { get; set; }
}
