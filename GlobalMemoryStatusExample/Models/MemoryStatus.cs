using System.Runtime.InteropServices;

namespace GlobalMemoryStatusExample.Models;

[StructLayout(LayoutKind.Sequential)]
public struct MemoryStatus
{ 
    public readonly uint dwLength { get; init; }
    public uint dwMemoryLoad { get; }
    public ulong ullTotalPhys { get; }
    public ulong ullAvailPhys { get; }
    public ulong ullTotalPageFile { get; }
    public ulong ullAvailPageFile { get; }
    public ulong ullTotalVirtual { get; }
    public ulong ullAvailVirtual { get; }
    public ulong ullAvailExtendedVirtual { get; }
}