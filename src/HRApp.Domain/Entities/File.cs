using System.ComponentModel.DataAnnotations.Schema;

namespace HRApp.Domain;

[Table("Files")]
public class File : BaseEntity
{
    public string FileName { get; set; } = string.Empty;
    public string ContentType { get; set; } = string.Empty;
    public byte[] Data { get; set; } = Array.Empty<byte>();
}

