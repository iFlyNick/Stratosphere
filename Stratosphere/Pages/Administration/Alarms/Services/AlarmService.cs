using Stratosphere.Pages.Administration.Alarms.ViewModels;

namespace Stratosphere.Pages.Administration.Alarms.Services;

public class AlarmService : IAlarmService
{
    public async Task<List<AlarmVM>?> GetAlarms()
    {
        var retVal = new List<AlarmVM>();

        return retVal;
    }
}
