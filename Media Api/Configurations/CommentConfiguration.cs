using Media_Api.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Media_Api.Configurations;

public class CommentConfiguration : IEntityTypeConfiguration<CommentEntity>
{
    public void Configure(EntityTypeBuilder<CommentEntity> builder)
    {
        builder.ToTable("comment");

        builder.HasKey(x => x.Id)
            .HasName("pk_comment");

        builder.Property(x => x.Id)
            .HasColumnName("id");

        builder.Property(x => x.Content)
            .HasMaxLength(300)
            .IsRequired()
            .HasColumnName("content");

        builder.Property(x => x.Date)
            .IsRequired()
            .HasColumnName("date");

        builder.Property(x => x.UserId)
            .IsRequired()
            .HasColumnName("user_id");

        builder.Property(x => x.PostId)
            .IsRequired()
            .HasColumnName("post_id");
    }
}