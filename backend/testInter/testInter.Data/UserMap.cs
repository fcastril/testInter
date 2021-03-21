using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace testInter.Data
{
    public class UserMap
    {
        public UserMap(EntityTypeBuilder<User> entityBuilder)
        {
            entityBuilder.HasKey(t => t.Id);
            entityBuilder.Property(t => t.UserName).IsRequired();
            entityBuilder.Property(t => t.Email).IsRequired();
            entityBuilder.Property(t => t.Password);
        }
    }
}
