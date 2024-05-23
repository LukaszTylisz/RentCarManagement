using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RentCarManagement.Server.Configurations.Entities;

public class RoleSeedConfiguration : IEntityTypeConfiguration<IdentityRole>
{
    public void Configure(EntityTypeBuilder<IdentityRole> builder)
    {
        builder.HasData(
            new IdentityRole
            {
                Id = "9B7D1F69-015B-4710-A874-7397420B8A6D",
                Name = "User",
                NormalizedName = "USER"
            },
            new IdentityRole
            {
                Id = "BF02692A-7022-4C57-ADD2-859FADD4E8EB",
                Name = "Administrator",
                NormalizedName = "ADMINISTRATOR"
            }
        );
    }
}