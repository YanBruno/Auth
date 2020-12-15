using Auth.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Auth.Domain.Infra.Mappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(user => user.Id);
            builder.Ignore(user => user.Notifications);

            builder.OwnsOne(user => user.Name, name =>
            {
                name.Ignore(name => name.Notifications);
                name.Property(name => name.FirstName)
                .IsRequired()
                .HasColumnName("FirstName")
                .HasColumnType("varchar(15)");

                name.Property(name => name.LastName)
                .IsRequired()
                .HasColumnName("LastName")
                .HasColumnType("varchar(15)");
            });

            builder.OwnsOne(u => u.Email, email =>
            {
                email.Ignore(email => email.Notifications);
                email.Property(email => email.Address)
                .IsRequired()
                .HasColumnName("Email")
                .HasColumnType("varchar(80)")
                ;
            });

            builder.OwnsOne(u => u.Password, pass => 
            {
                pass.Ignore(pass => pass.Notifications);
                pass.Property(pass => pass.Pass)
                .IsRequired()
                .HasColumnName("Password")
                .HasColumnType("varchar(10)")
                ;
            });

            builder.Property(user => user.Role)
                .IsRequired()
                .HasColumnName("Role")
                .HasColumnType("varchar(20)");

            builder.ToTable("tblUser");
        }
    }
}
