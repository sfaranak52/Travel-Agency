namespace Travelagency.Infrastructure.EntityConfigurations;

public class PayEntityConfiguration : IEntityTypeConfiguration<Pay>
{
    public void Configure(EntityTypeBuilder<Pay> builder)
    {
        builder.ToTable("Pay", schema: "TravelAgency");
        builder.HasKey(r => r.Id);
        builder.Property(r => r.Id).ValueGeneratedNever();
        builder.HasOne<Invoice>().WithMany().HasForeignKey(r => r.InvoiceId);
    }
}
