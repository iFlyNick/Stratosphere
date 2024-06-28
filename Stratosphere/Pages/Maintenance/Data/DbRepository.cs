using Dapper;
using Stratosphere.Data.Postgres.Context;
using Stratosphere.Pages.Maintenance.Models.DTOs;

namespace Stratosphere.Pages.Maintenance.Data;

public class DbRepository : IDbRepository
{
    private readonly IPostgresContext _context;
    private readonly ILogger<DbRepository> _logger;

    private readonly int _timeout = 30;

    public DbRepository(IPostgresContext context, ILogger<DbRepository> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<int> CreateMaintenanceRequest(MaintenanceRequestDto? request, CancellationToken cancellationToken = default)
    {
        if (request is null)
            return 0;
        
        var sql = @"insert into stratosphere.maintenancerequest (maintenancerequestid, description, completionnote, actualstarttime, actualendtime, scheduledstarttime, scheduledendtime, automaticstartenabled, automaticendenabled, createdby, createddate, modifiedby, modifieddate)
                    values (:maintenancerequestid, :description, :completionnote, :actualstarttime, :actualendtime, :scheduledstarttime, :scheduledendtime, :automaticstartenabled, :automaticendenabled, :createdby, :createddate, :modifiedby, :modifieddate)"
        ;

        var parms = new { request.MaintenanceRequestId, request.Description, request.CompletionNote, request.ActualStartTime, request.ActualEndTime, request.ScheduledStartTime, request.ScheduledEndTime, request.AutomaticStartEnabled, request.AutomaticEndEnabled, request.CreatedBy, request.CreatedDate, request.ModifiedBy, request.ModifiedDate };

        using var transaction = _context.Connection.BeginTransaction();

        try
        {
            var cmd = new CommandDefinition(sql, parms, transaction: transaction, commandTimeout: _timeout, cancellationToken: cancellationToken);

            var resp = await _context.Connection.ExecuteAsync(cmd);

            if (resp == 0)
                throw new Exception("Failed to insert record to db.");

            transaction.Commit();

            return resp;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            transaction.Rollback();

            return 0;
        }
    }

    public async Task<int> CreateMaintenanceRequestDetails(Guid? id, List<MaintenanceRequestDetailDto>? requestDetails, CancellationToken cancellationToken = default)
    {
        if (id is null || id.Equals(Guid.Empty) || requestDetails is null || !requestDetails.Any()) 
            return 0;

        var sql = @"insert into stratosphere.maintenancerequestdetail (maintenancerequestid, serviceid, environmentid, assetid, createdby, createddate, modifiedby, modifieddate, stoptime, starttime, issuccess, statusmessage)
                    values (:maintenancerequestid, :serviceid, :environmentid, :assetid, :createdby, :createddate, :modifiedby, :modifieddate, :stoptime, :starttime, :issuccess, :statusmessage)";
        
        using var transaction = _context.Connection.BeginTransaction();
        var totalRows = 0;
        
        try
        {
            foreach (var item in requestDetails)
            {
                if (item is null)
                    continue;
                
                var parms = new { item.MaintenanceRequestId, item.ServiceId, item.EnvironmentId, item.AssetId, item.CreatedBy, item.CreatedDate, item.ModifiedBy, item.ModifiedDate, item.StopTime, item.StartTime, item.IsSuccess, item.StatusMessage };

                var cmd = new CommandDefinition(sql, parms, transaction: transaction, commandTimeout: _timeout, cancellationToken: cancellationToken);

                var resp = await _context.Connection.ExecuteAsync(cmd);

                if (resp == 0)
                    throw new Exception("Failed to insert record into db.");

                totalRows += resp;
            }

            transaction.Commit();

            return totalRows;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            transaction.Rollback();

            return 0;
        }
    }

    public async Task<MaintenanceRequestDto?>? GetMaintenanceRequestById(Guid? id, CancellationToken cancellationToken = default)
    {
        if (id is null || id.Equals(Guid.Empty))
            return null;

        var sql = @"select maintenancerequestid, description, completionnote, actualstarttime, actualendtime, scheduledstarttime, scheduledendtime, automaticstartenabled, automaticendenabled, createdby, createddate,                         modifiedby, modifieddate
                    from stratosphere.maintenancerequest
                    where maintenancerequestid = :id";

        var parms = new { id };

        var cmd = new CommandDefinition(sql, parms, commandTimeout: _timeout, cancellationToken: cancellationToken);

        var resp = await _context.Connection.QueryFirstOrDefaultAsync<MaintenanceRequestDto?>(cmd);

        return resp;
    }

    public async Task<List<MaintenanceRequestDetailDto>?>? GetMaintenanceRequestDetailsById(Guid? id, CancellationToken cancellationToken = default)
    {
        if (id is null || id.Equals(Guid.Empty))
            return null;

        var sql = @"select maintenancerequestdetailid, maintenancerequestid, serviceid, environmentid, assetid, createdby, createddate, modifiedby, modifieddate, stoptime, starttime, issuccess, statusmessage
                    from stratosphere.maintenancerequestdetail
                    where maintenancerequestid = :id";

        var parms = new { id };

        var cmd = new CommandDefinition(sql, parms, commandTimeout: _timeout, cancellationToken: cancellationToken);

        var resp = await _context.Connection.QueryAsync<MaintenanceRequestDetailDto>(cmd);

        return resp.ToList();
    }

    public async Task<List<MaintenanceRequestDetailHistoryDto>?>? GetMaintenanceRequestDetailHistoryById(Guid? id, CancellationToken cancellationToken = default)
    {
        if (id is null || id.Equals(Guid.Empty))
            return null;

        var sql = @"select maintenancerequestdetailhistoryid, maintenancerequestdetailid, maintenancerequestid, createdby, createddate, modifiedby, modifieddate, serviceid, environmentid, assetid, executiontime, action, issuccess, statusmessage
                    where maintenancerequestid = :id";

        var parms = new { id };

        var cmd = new CommandDefinition(sql, parms, commandTimeout: _timeout, cancellationToken: cancellationToken);

        var resp = await _context.Connection.QueryAsync<MaintenanceRequestDetailHistoryDto>(cmd);

        return resp.ToList();
    }

    public async Task<int> CreateMaintenanceTemplate(MaintenanceTemplateDto? template, CancellationToken cancellationToken = default)
    {
        if (template is null)
            return 0;

        var sql = @"insert into maintenancetemplate (maintenancetemplateid, createdby, createddate, modifiedby, modifieddate, name, description)
                    values (:maintenancetemplateid, :createdby, :createddate, :modifiedby, :modifieddate, :name, :description)";

        var parms = new { };

        using var transaction = _context.Connection.BeginTransaction();
        
        try
        {
            var cmd = new CommandDefinition(sql, parms, transaction: transaction, commandTimeout: _timeout, cancellationToken: cancellationToken);
        
            var resp = await _context.Connection.ExecuteAsync(cmd);
            
            if (resp == 0)
                throw new Exception("Failed to insert record to db.");
            
            transaction.Commit();
            
            return resp;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            transaction.Rollback();

            return 0;
        }
    }

    public async Task<int> CreateMaintenanceTemplateDetails(Guid? id, List<MaintenanceTemplateDetailDto>? templateDetails, CancellationToken cancellationToken = default)
    {
        if (id is null || id.Equals(Guid.Empty) || templateDetails is null || !templateDetails.Any())
            return 0;

        var sql = @"insert into stratosphere.maintenancetemplatedetail (maintenancetemplateid, serviceid, environmentid, createdby, createddate, modifiedby, modifieddate, startorder, stoporder, waitforqueueclearonstart, waitforqueueclearonstop)
                    values (:maintenancetemplateid, :serviceid, :environmentid, :createdby, :createddate, :modifiedby, :modifieddate, :startorder, :stoporder, :waitforqueueclearonstart, :waitforqueueclearonstop)";

        using var transaction = _context.Connection.BeginTransaction();
        var totalRows = 0;

        try
        {
            foreach (var item in templateDetails)
            {
                if (item is null)
                    continue;

                var parms = new { item.MaintenanceTemplateId, item.ServiceId, item.EnvironmentId, item.CreatedBy, item.CreatedDate, item.ModifiedBy, item.ModifiedDate, item.StartOrder, item.StopOrder, item.WaitForQueueClearOnStart, item.WaitForQueueClearOnStop };

                var cmd = new CommandDefinition(sql, parms, transaction: transaction, commandTimeout: _timeout, cancellationToken: cancellationToken);

                var resp = await _context.Connection.ExecuteAsync(cmd);

                if (resp == 0)
                    throw new Exception("Failed to insert record into db.");

                totalRows += resp;
            }

            transaction.Commit();

            return totalRows;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            transaction.Rollback();

            return 0;
        }
    }

    public async Task<MaintenanceTemplateDto?>? GetMaintenanceTemplateById(Guid? id, CancellationToken cancellationToken = default)
    {
        if (id is null || id.Equals(Guid.Empty))
            return null;
     
        var sql = @"select maintenancetemplateid, createdby, createddate, modifiedby, modifieddate, name, description
                    from maintenancetemplate
                    where maintenancetemplateid = :id";

        var parms = new { id };
        
        var cmd = new CommandDefinition(sql, parms, commandTimeout: _timeout, cancellationToken: cancellationToken);
        
        var resp = await _context.Connection.QueryFirstOrDefaultAsync<MaintenanceTemplateDto>(cmd);

        return resp;
    }

    public async Task<List<MaintenanceTemplateDetailDto>?>? GetMaintenanceTemplateDetailsById(Guid? id, CancellationToken cancellationToken = default)
    {
        if (id is null || id.Equals(Guid.Empty))
            return null;

        var sql = @"select maintenancetemplateid, serviceid, environmentid, createdby, createddate, modifiedby, modifieddate, startorder, stoporder, waitforqueueclearonstart, waitforqueueclearonstop
                    from maintenancetemplatedetail
                    where maintenancetemplateid = :id";

        var parms = new { id };
        
        var cmd = new CommandDefinition(sql, parms, commandTimeout: _timeout, cancellationToken: cancellationToken);
        
        var resp = await _context.Connection.QueryAsync<MaintenanceTemplateDetailDto>(cmd);

        return resp.ToList();
    }
}
