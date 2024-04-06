namespace Travelagency.Infrastructure.EntityConfigurations;

public class CustomerEntityConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable("Customer", schema: "TravelAgency");
        builder.HasKey(r => r.Id);
    }
}
