using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shared.Domain;

namespace RentCarManagement.Configurations.Entities;

public class MakeSeedConfiguration : IEntityTypeConfiguration<Make>
{
    public void Configure(EntityTypeBuilder<Make> builder)
    {
        builder.HasData(
            new Make
            {
                Id = 1,
                CreatedBy = "System",
                DateCreated = DateTime.Now,
                DateUpdated = DateTime.Now,
                Name = "Lexus",
                UpdatedBy = "System"
            },
            new Make
            {
                Id = 2,
                CreatedBy = "System",
                DateCreated = DateTime.Now,
                DateUpdated = DateTime.Now,
                Name = "Audi",
                UpdatedBy = "System"
            }
        );
    }
}