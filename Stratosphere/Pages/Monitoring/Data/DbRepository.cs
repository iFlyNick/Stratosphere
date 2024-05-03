using Dapper;
using Stratosphere.Data.Postgres.Context;
using Stratosphere.Pages.Monitoring.Models;

namespace Stratosphere.Pages.Monitoring.Data;

public class DbRepository : IDbRepository
{
    protected readonly IPostgresContext _context;
    protected readonly ILogger<DbRepository> _logger;
    
    public DbRepository(IPostgresContext context, ILogger<DbRepository> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<List<Service>?> GetServices()
    {
        var serviceSql = @"select s.serviceid, s.servicename, s.servicedescription, st.name as servicetype, se.serviceid, se.environmentid, se.automaticrestarteligible, se.minimumhealthstatustypeidforaction, se.consecutivefailuresbeforealert, se.consecutivefailuresbeforerestart
                            from stratosphere.service s
                            join stratosphere.servicetype st on st.servicetypeid = s.servicetypeid
                            join stratosphere.serviceenvironmentdetail se on se.serviceid = s.serviceid";

        var dataReader = await _context.Connection.QueryAsync<Service, ServiceEnvironmentDetail, Service>(serviceSql, (service, sEnvironment) =>
        {
            service.ServiceEnvironmentDetail = sEnvironment;
            return service;
        }, splitOn: "serviceid");

        return dataReader.ToList();
    }
}
