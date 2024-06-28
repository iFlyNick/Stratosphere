using Stratosphere.Pages.Maintenance.Models.DTOs;

namespace Stratosphere.Pages.Maintenance.Data;

public interface IDbRepository
{
    Task<int> CreateMaintenanceRequest(MaintenanceRequestDto? request, CancellationToken cancellationToken = default);
    Task<int> CreateMaintenanceRequestDetails(Guid? id, List<MaintenanceRequestDetailDto>? requestDetails, CancellationToken cancellationToken = default);
    Task<MaintenanceRequestDto?>? GetMaintenanceRequestById(Guid? id, CancellationToken cancellationToken = default);
    Task<List<MaintenanceRequestDetailDto>?>? GetMaintenanceRequestDetailsById(Guid? id, CancellationToken cancellationToken = default);
    Task<List<MaintenanceRequestDetailHistoryDto>?>? GetMaintenanceRequestDetailHistoryById(Guid? id, CancellationToken cancellationToken = default);
    //Task UpdateMaintenanceRequest();
    //Task UpdateMaintenanceRequestDetail();
    //Task DeleteMaintenanceRequest();
    //Task DeleteMaintenanceRequestDetail();

    Task<int> CreateMaintenanceTemplate(MaintenanceTemplateDto? template, CancellationToken cancellationToken = default);
    Task<int> CreateMaintenanceTemplateDetails(Guid? id, List<MaintenanceTemplateDetailDto>? templateDetails, CancellationToken cancellationToken = default);
    Task<MaintenanceTemplateDto?>? GetMaintenanceTemplateById(Guid? id, CancellationToken cancellationToken = default);
    Task<List<MaintenanceTemplateDetailDto>?>? GetMaintenanceTemplateDetailsById(Guid? id, CancellationToken cancellationToken = default);
}
