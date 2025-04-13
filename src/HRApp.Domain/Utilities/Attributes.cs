namespace HRApp.Domain;


[AttributeUsage(AttributeTargets.Class)]
public class DbTableAttribute : Attribute
{
    public string TableName { get; }
        
    public DbTableAttribute(string tableName)
    {
        TableName = tableName;
    }
}
