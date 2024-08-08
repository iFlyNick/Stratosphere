using Stratosphere.Pages.Administration.Alarms.ViewModels;

namespace Stratosphere.Pages.Administration.Alarms.Services;

public interface IAlarmService
{
    Task<List<AlarmVM>?> GetAlarms();
}
