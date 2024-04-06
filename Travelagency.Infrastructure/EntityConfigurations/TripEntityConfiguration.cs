using TravelAgency.Domain.Aggregates.Trip;

namespace Travelagency.Infrastructure.EntityConfigurations;

public class TripEntityConfiguration : IEntityTypeConfiguration<Trip>
{
    public void Configure(EntityTypeBuilder<Trip> builder)
    {
        builder.ToTable("Trip", schema: "TravelAgency");
        builder.HasKey(r => r.Id);
        builder.Property(r => r.Id).ValueGeneratedNever();
        builder.HasOne<Invoice>().WithMany().HasForeignKey(r => r.InvoiceId);
    }
}
