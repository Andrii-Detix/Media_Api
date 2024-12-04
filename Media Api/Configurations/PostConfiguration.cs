using Media_Api.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Media_Api.Configurations;

public class PostConfiguration : IEntityTypeConfiguration<PostEntity>
{
    public void Configure(EntityTypeBuilder<PostEntity> builder)
    {
        builder.ToTable("post");

        builder.HasKey(x => x.Id)
            .HasName("pk_post");

        builder.Property(x => x.Id)
            .HasColumnName("id");

        builder.Property(x => x.Title)
            .HasMaxLength(45)
            .IsRequired()
            .HasColumnName("title");

        builder.Property(x => x.Content)
            .HasColumnType("text")
            .IsRequired()
            .HasColumnName("content");

        builder.Property(x => x.PublishDate)
            .IsRequired()
            .HasColumnName("publish_date");

        builder.Property(x => x.AuthorId)
            .IsRequired()
            .HasColumnName("author_id");

        builder.HasMany(p => p.Comments)
            .WithOne(c => c.Post)
            .HasForeignKey(c => c.PostId);
    }
}