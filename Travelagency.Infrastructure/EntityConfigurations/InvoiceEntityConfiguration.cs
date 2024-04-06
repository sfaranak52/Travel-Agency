namespace Travelagency.Infrastructure.EntityConfigurations;

public class InvoiceEntityConfiguration : IEntityTypeConfiguration<Invoice>
{
    public void Configure(EntityTypeBuilder<Invoice> builder)
    {
        builder.ToTable("Invoice", schema: "TravelAgency");
        builder.HasKey(r => r.Id);
        builder.Property(r => r.Id).ValueGeneratedNever();
        builder.HasOne<Customer>().WithMany().HasForeignKey(r => r.CustomerId);
    }
}
