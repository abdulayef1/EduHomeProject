namespace EduHome.Domain.Entities.Common;

public abstract class BaseEntity
{
     public int Id  { get; set; }
     public DateTime OnCreated { get; set; }
}
