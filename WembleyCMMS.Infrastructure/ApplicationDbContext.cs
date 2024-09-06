using Microsoft.EntityFrameworkCore.Storage;
using WembleyCMMS.Domain.SeedWork;
using WembleyCMMS.Domain.AggregateModels.MaintenanceRequestAggregate;
using WembleyCMMS.Domain.AggregateModels.PersonAggregate;
using WembleyCMMS.Domain.AggregateModels.MaintenanceResponseAggregate;
using WembleyCMMS.Domain.AggregateModels.MaterialInforAggregate;
using WembleyCMMS.Infrastructure.EntityConfigurations.MaintenanceRequests;
using WembleyCMMS.Infrastructure.EntityConfigurations.MaterialInfors;
using WembleyCMMS.Domain.AggregateModels.CauseAggregate;
using WembleyCMMS.Infrastructure.EntityConfigurations.Persons;
using WembleyCMMS.Infrastructure.EntityConfigurations.MaintenanceResponses;
using WembleyCMMS.Domain.AggregateModels.CorrectionAggregate;
using WembleyCMMS.Infrastructure.EntityConfigurations.Corrections;
using WembleyCMMS.Domain.AggregateModels.EquipmentMaterialAggregate;
using WembleyCMMS.Infrastructure.EntityConfigurations.EquipmentMaterials;
using WembleyCMMS.Domain.AggregateModels.TimeSeriesObjectAggregate;
using WembleyCMMS.Infrastructure.EntityConfigurations.TimeSeriesObjects;
using WembleyCMMS.Domain.AggregateModels.PerformanceIndexAggregate;
using WembleyCMMS.Infrastructure.EntityConfigurations.PerformanceIndexs;
using WembleyCMMS.Infrastructure.EntityConfigurations.Equipments;
using WembleyCMMS.Infrastructure.EntityConfigurations.Causes;
using WembleyCMMS.Domain.AggregateModels.WorkingTimeAggregate;
using WembleyCMMS.Infrastructure.EntityConfigurations.WorkingTimes;
using WembleyCMMS.Domain.AggregateModels.EquipmentAggregate;
using WembleyCMMS.Domain.AggregateModels.InspectionReportAggregate;
using WembleyCMMS.Infrastructure.EntityConfigurations.InspectionReports;
using WembleyCMMS.Domain.AggregateModels.EquipmentClassAggregate;
using WembleyCMMS.Infrastructure.EntityConfigurations.EquipmentClasses;

namespace WembleyCMMS.Infrastructure
{
    public class ApplicationDbContext : DbContext, IUnitOfWork
    {
        public const string DEFAULT_SCHEMA = "application";

        public DbSet<EquipmentClass> EquipmentClasses { get; set; }
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<MaintenanceRequest> MaintenanceRequests { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<MaterialInfor> MaterialInfors { get; set; }

        public DbSet<Cause> Causes { get; set; }
        public DbSet<Correction> Corrections { get; set; }
        public DbSet<MaintenanceResponse> MaintenanceResponses { get; set; }

        public DbSet<EquipmentMaterial> EquipmentMaterials { get; set; }
        public DbSet<TimeSeriesObject> TimeSeriesObjects { get; set; }
        public DbSet<PerformanceIndex> PerformanceIndexs { get; set; }
        public DbSet<WorkingTime> WorkingTimes { get; set; }
        public DbSet<InspectionReport> InspectionReports { get; set; }

        private IDbContextTransaction? _currentTransaction;
        private readonly IMediator _mediator;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public ApplicationDbContext(DbContextOptions options) : base(options) { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        public IDbContextTransaction? GetCurrentTransaction() => _currentTransaction;
        public bool HasActiveTransaction => _currentTransaction != null;

        public ApplicationDbContext(DbContextOptions options, IMediator mediator) : base(options)
        {
            _mediator = mediator;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MaintenanceRequestEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new MaterialInforEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new MaterialRequestEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new MaterialEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new CauseEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new PersonEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new MaintenanceResponseEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new CorrectionEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new EquipmentMaterialEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new TimeSeriesObjectsEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new PerformanceIndexEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new EquipmentClassEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new EquipmentEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new WorkingTimeEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new MaterialHistoryCardEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new InspectionReportEntityTypeConfiguration());
        }

        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
        {
            await _mediator.DispatchDomainEventsAsync(this);
            await base.SaveChangesAsync(cancellationToken);

            return true;
        }

        public async Task<IDbContextTransaction?> BeginTransactionAsync()
        {
            if (_currentTransaction != null) return null;

            _currentTransaction = await Database.BeginTransactionAsync();

            return _currentTransaction;
        }

        public async Task CommitTransactionAsync(IDbContextTransaction transaction)
        {
            if (transaction == null) throw new ArgumentNullException(nameof(transaction));
            if (transaction != _currentTransaction) throw new InvalidOperationException($"Transaction {transaction.TransactionId} is not current");

            try
            {
                await SaveChangesAsync();
                transaction.Commit();
            }
            catch
            {
                RollbackTransaction();
                throw;
            }
            finally
            {
                if (_currentTransaction != null)
                {
                    _currentTransaction.Dispose();
                    _currentTransaction = null;
                }
            }
        }

        public void RollbackTransaction()
        {
            try
            {
                _currentTransaction?.Rollback();
            }
            finally
            {
                if (_currentTransaction != null)
                {
                    _currentTransaction.Dispose();
                    _currentTransaction = null;
                }
            }
        }
    }
}