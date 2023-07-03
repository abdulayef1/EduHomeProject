using EduHome.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduHome.Persistence.Configuration;

public class CourseConfiguration : IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        builder.Property(course => course.Title)
             .IsRequired()
             .HasMaxLength(40);
        builder.Property(course=> course.Description)
            .IsRequired()
            .HasMaxLength (250);
        builder.Property(course => course.ImageName)
            .IsRequired();        
        builder.Property(course => course.ImageUri)
            .HasMaxLength(255)
            .IsRequired();
    }
}
