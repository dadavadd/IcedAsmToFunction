using static Windows.Win32.System.Memory.VIRTUAL_FREE_TYPE;
using static Windows.Win32.Windows;

namespace IcedAsmToFunction;

public unsafe readonly struct AsmFunctionBase(void* functionPtr, bool isOwner = true) : IDisposable
{
    public void* FunctionPointer => functionPtr;
    public bool IsOwner => isOwner;

    public void Dispose()
    {
        
        if (isOwner && functionPtr != null)
        {
            VirtualFree(functionPtr, 0, MEM_RELEASE);
        }
    }
}
