using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Config;

public class BookConfig : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        
        builder.Property(b => b.Title)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(b => b.Description)
            .IsRequired();

        builder.Property(b => b.BookCoverPhoto)
            .IsRequired();

        builder.Property(b => b.Price)
            .IsRequired()
            .HasPrecision(10, 2);

        
        builder.Property(b => b.AverageRating)
            .HasDefaultValue(0f);

        builder.Property(b => b.TotalReviews)
            .HasDefaultValue(0);
    }
}
