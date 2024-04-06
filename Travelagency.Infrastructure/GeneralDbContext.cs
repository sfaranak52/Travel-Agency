using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using TravelAgency.Application.Interfaces.Common;
using TravelAgency.Domain.Aggregates.InvoiceAggregate;
using TravelAgency.Domain.Aggregates.PayAggregate;
using TravelAgency.Domain.Aggregates.Trip;

namespace Travelagency.Infrastructure;

public class GeneralDbContext : DbContext, IUnitOfWork
{
    private readonly IMediator _mediator;

    public GeneralDbContext(DbContextOptions<GeneralDbContext> options, IMediator mediator) : base(options)
    {
        _mediator = mediator;
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }

    public DbSet<Invoice> Invoices { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Trip> Trips { get; set; }
    public DbSet<Pay> Pays { get; set; }
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        //do some detail like creatby,etc;
        return base.SaveChangesAsync(cancellationToken);
    }

    public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken))
    {
        await SaveChangesAsync(cancellationToken);
        return true;
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(typeof(GeneralDbContext).Assembly);
        builder.HasPostgresExtension("postgis");
    }

}
