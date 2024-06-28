using Stratosphere.Data.Postgres.Repository;

namespace Stratosphere.Services.Database;

public class DatabaseService : IDatabaseService
{
    protected readonly IConfiguration _config;
    protected readonly IPostgresRepository _repo;
    private readonly ILogger<DatabaseService> _logger;

    public DatabaseService(IConfiguration config, IPostgresRepository repo, ILogger<DatabaseService> logger)
    {
        _config = config;
        _repo = repo;
        _logger = logger;
    }

    public async Task CreateSchema(CancellationToken cancellationToken = default)
    {
        await _repo.CreateSchema(cancellationToken);
    }

    public async Task CreateDatabase(CancellationToken cancellationToken = default)
    {
        var tables = new List<string>()
        {
            "ServiceType",
            "Service",
            "Environment",
            "AssetType",
            "Asset",
            "ContactType",
            "Contact",
            "HealthStatusType",
            "Alarm",
            "VirtualHost",
            "Queue",
            "QueueSnapshot",
            "AlertProfile",
            "AlertProfileDetail",
            "ServiceAsset",
            "ServiceQueue",
            "ServiceAlert",
            "ServiceEnvironmentDetail",
            "ServiceHealthReport",
            "ServiceHealthReportDetail",
            "AlertHistory",
            "MaintenanceTemplate",
            "MaintenanceTemplateDetail",
            "MaintenanceRequest",
            "MaintenanceRequestDetail",
            "MaintenanceRequestDetailHistory"
        };

        foreach (var table in tables)
            await _repo.CreateTable(table, cancellationToken);
    }
}
