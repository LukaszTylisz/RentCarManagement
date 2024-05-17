using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shared.Domain;

namespace RentCarManagement.Server.Configurations.Entities;

public class ModelSeedConfiguration : IEntityTypeConfiguration<Model>
{
    public void Configure(EntityTypeBuilder<Model> builder)
    {
        builder.HasData(
            new Model
            {
                Id = 1,
                CreatedBy = "System",
                DateCreated = DateTime.Now,
                DateUpdated = DateTime.Now,
                Name = "ISF",
                UpdatedBy = "System"
            },
            new Model
            {
                Id = 2,
                CreatedBy = "System",
                DateCreated = DateTime.Now,
                DateUpdated = DateTime.Now,
                Name = "LS500",
                UpdatedBy = "System"
            },
            new Model
            {
                Id = 3,
                CreatedBy = "System",
                DateCreated = DateTime.Now,
                DateUpdated = DateTime.Now,
                Name = "A4",
                UpdatedBy = "System"
            },
            new Model
            {
                Id = 4,
                CreatedBy = "System",
                DateCreated = DateTime.Now,
                DateUpdated = DateTime.Now,
                Name = "A8",
                UpdatedBy = "System"
            }
        );
    }
}