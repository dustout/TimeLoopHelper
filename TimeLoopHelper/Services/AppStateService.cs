using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeLoopHelper.Services
{
  public class AppStateService
  {
    private int _timeLoopUserCount = -1;

    public int TimeLoopUserCount
    {
      get => _timeLoopUserCount;
      set
      {
        _timeLoopUserCount = value;
        NotifyStateChanged();
      }
    }

    public event Action OnChange;

    private void NotifyStateChanged() => OnChange?.Invoke();
  }
}
