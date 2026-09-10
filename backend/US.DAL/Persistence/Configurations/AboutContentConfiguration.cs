using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using US.DAL.Entities;

namespace US.DAL.Persistence.Configurations;

public class AboutContentConfiguration : IEntityTypeConfiguration<AboutContent>
{
    public void Configure(EntityTypeBuilder<AboutContent> builder)
    {
        builder.ToTable("AboutContents");
        
        builder.HasKey(a => a.Id);
        
        builder.Property(a => a.CreatedAt).IsRequired();
        builder.Property(a => a.Text).IsRequired().HasMaxLength(5000);

        builder.HasOne(a => a.LastModifiedBy)
            .WithMany()
            .HasForeignKey(a => a.LastModifiedByUserId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();
    }
}