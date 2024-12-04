using Media_Api.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Media_Api.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
{
    public void Configure(EntityTypeBuilder<UserEntity> builder)
    {
        builder.ToTable("user");

        builder.HasKey(x => x.Id)
            .HasName("pk_user");

        builder.Property(x => x.Id)
            .HasColumnName("id");

        builder.Property(x => x.Login)
            .HasMaxLength(45)
            .IsRequired()
            .HasColumnName("login");

        builder.Property(x => x.Name)
            .HasMaxLength(45)
            .IsRequired()
            .HasColumnName("name");

        builder.Property(x => x.Password)
            .HasMaxLength(45)
            .IsRequired()
            .HasColumnName("password");

        builder.Property(x => x.Email)
            .HasMaxLength(45)
            .IsRequired()
            .HasColumnName("email");

        builder.Property(x => x.Age)
            .HasColumnName("age");

        builder.HasMany(u => u.Posts)
            .WithOne(p => p.Author)
            .HasForeignKey(p => p.AuthorId);

        builder.HasMany(u => u.Comments)
            .WithOne(c => c.User)
            .HasForeignKey(c => c.UserId);
    }
}