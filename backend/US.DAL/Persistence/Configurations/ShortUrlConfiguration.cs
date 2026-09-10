using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using US.DAL.Entities;

namespace US.DAL.Persistence.Configurations;

public class ShortUrlConfiguration : IEntityTypeConfiguration<ShortUrl>
{
    public void Configure(EntityTypeBuilder<ShortUrl> builder)
    {
        builder.ToTable("ShortUrls");
        
        builder.HasKey(s => s.Id);
        
        builder.Property(s => s.CreatedAt).IsRequired();
        builder.Property(s => s.OriginalUrl).IsRequired().HasMaxLength(2048);
        builder.Property(s => s.ClickCount).IsRequired();

        builder.HasOne(s => s.CreatedBy)
            .WithMany()
            .HasForeignKey(s => s.CreatedByUserId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();
    }
}