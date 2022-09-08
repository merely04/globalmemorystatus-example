using System;
using System.Runtime.InteropServices;
using GlobalMemoryStatusExample.Models;

namespace GlobalMemoryStatusExample.Services;

public class MemoryService
{
    [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    private static extern bool GlobalMemoryStatusEx(ref MemoryStatus lpBuffer);

    public Tuple<bool, MemoryStatus> GetGlobalMemoryStatus(MemoryStatus memoryStatus)
    {
        var result = GlobalMemoryStatusEx(ref memoryStatus);
        return new Tuple<bool, MemoryStatus>(result, memoryStatus);
    }
}