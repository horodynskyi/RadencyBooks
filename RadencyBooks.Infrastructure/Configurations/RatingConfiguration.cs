﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RadencyBooks.Application.Models;

namespace RadencyBooks.Infrastructure.Configurations;

public class RatingConfiguration:IEntityTypeConfiguration<Rating>
{
    public void Configure(EntityTypeBuilder<Rating> builder)
    {
        builder
            .HasKey(x => x.Id);
        builder
            .HasOne(x => x.Book)
            .WithMany(x => x.Ratings)
            .HasForeignKey(x => x.BookId);
    }
}