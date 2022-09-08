using System.Runtime.InteropServices;
using System.Timers;
using GlobalMemoryStatusExample.Models;
using GlobalMemoryStatusExample.Services;

namespace GlobalMemoryStatusExample.ViewModels;

public class MainViewModel : ViewModelBase
{
    private readonly MemoryService _memoryService;

    private readonly Timer _timer;

    private MemoryStatus _memoryStatus;

    public MemoryStatus MemoryStatus
    {
        get => _memoryStatus;
        set => SetField(ref _memoryStatus, value);
    }

    public MainViewModel(MemoryService memoryService)
    {
        _memoryService = memoryService;

        _memoryStatus = new MemoryStatus()
        {
            dwLength = (uint)Marshal.SizeOf(typeof(MemoryStatus))
        };

        _timer = new Timer(1000);
        _timer.Elapsed += TimerOnElapsed;
        _timer.Start();
    }

    ~MainViewModel()
    {
        _timer.Dispose();
    }

    private void TimerOnElapsed(object? sender, ElapsedEventArgs e)
    {
        var result = _memoryService.GetGlobalMemoryStatus(_memoryStatus);
        if (result.Item1)
            MemoryStatus = result.Item2;
    }

    public override void Dispose()
    {
        _timer.Dispose();

        base.Dispose();
    }
}