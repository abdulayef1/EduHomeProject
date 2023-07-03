using EduHome.Domain.Entities.Common;

namespace EduHome.Domain.Entities;

public class Course:BaseEntity
{
    public string? Title{ get; set; }
    public string? Description{ get; set; }
    public string? ImageName{ get; set; }
    public string? ImageUri{ get; set; }
}
