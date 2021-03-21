using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace testInter.Data
{
    public class EmployeeMap
    {
        public EmployeeMap(EntityTypeBuilder<Employee> entityBuilder)
        {
            entityBuilder.HasKey(t => t.Id);
            entityBuilder.Property(t => t.FirstName).IsRequired();
            entityBuilder.Property(t => t.LastName).IsRequired();
            entityBuilder.Property(t => t.DocumentId).IsRequired();
            entityBuilder.Property(t => t.Position).IsRequired();
        }
    }
}
