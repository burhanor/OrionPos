using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrionPos.DataAccess.Configurations.SeedDatas;
using OrionPos.Entity.Entities;

namespace OrionPos.DataAccess.Configurations
{
    internal class TelephoneDirectoryConfiguration : IEntityTypeConfiguration<TelephoneDirectory>
    {
        public void Configure(EntityTypeBuilder<TelephoneDirectory> builder)
        {
            builder.HasOne(m => m.CreatedUser)
                .WithMany(m => m.TelephoneDirectories)
                .HasForeignKey(m => m.CreatedUserId);

            builder.HasData(TelephoneDirectories.GetSeedData());

        }
    }
}
