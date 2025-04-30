using System.ComponentModel.DataAnnotations.Schema;

namespace HRApp.Domain;

public enum DocumentType
{
    Contract,
    Certificate,
    Policy,
    Report,
    Other
}

[Table("Documents")]
public class Document : BaseEntity
{
    public string FileName { get; set; } = string.Empty;
    public string FilePath { get; set; } = string.Empty;
    public DocumentType Type { get; set; } = DocumentType.Other;
}