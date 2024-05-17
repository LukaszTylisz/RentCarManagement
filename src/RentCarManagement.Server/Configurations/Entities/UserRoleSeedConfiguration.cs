using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RentCarManagement.Configurations.Entities;

public class UserRoleSeedConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
{
    public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
    {
        builder.HasData(
            new IdentityUserRole<string>
            {
                RoleId = "9B7D1F69-015B-4710-A874-7397420B8A6D",
                UserId = "DAF25D9A-752C-4037-A9A6-2E9C0ECD1A67"
            },
            new IdentityUserRole<string>
            {
                RoleId = "BF02692A-7022-4C57-ADD2-859FADD4E8EB",
                UserId = "481601A2-3964-4151-A686-4DA8FE2E8490"
            }
        );
    }
}