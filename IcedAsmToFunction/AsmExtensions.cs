using Iced.Intel;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;

using static Windows.Win32.System.Memory.PAGE_PROTECTION_FLAGS;
using static Windows.Win32.System.Memory.VIRTUAL_ALLOCATION_TYPE;
using static Windows.Win32.Windows;


[assembly: SupportedOSPlatform("windows5.1.2600")]

namespace IcedAsmToFunction;

public static unsafe class AsmExtensions
{
    extension(Assembler asm)
    {
        public AsmFunction ToFunction(CallingConvention convention = CallingConvention.Cdecl, int baseSize = 4096)
            => new(AllocateExecutableMemory(asm, baseSize), convention);

        public AsmFunction<TResult> ToFunction<TResult>(CallingConvention convention = CallingConvention.Cdecl, int baseSize = 4096)
            => new(AllocateExecutableMemory(asm, baseSize), convention);

        public AsmFunction<T1, TResult> ToFunction<T1, TResult>(CallingConvention convention = CallingConvention.Cdecl, int baseSize = 4096)
            => new(AllocateExecutableMemory(asm, baseSize), convention);

        public AsmFunction<T1, T2, TResult> ToFunction<T1, T2, TResult>(CallingConvention convention = CallingConvention.Cdecl, int baseSize = 4096)
            => new(AllocateExecutableMemory(asm, baseSize), convention);

        public AsmFunction<T1, T2, T3, TResult> ToFunction<T1, T2, T3, TResult>(CallingConvention convention = CallingConvention.Cdecl, int baseSize = 4096)
            => new(AllocateExecutableMemory(asm, baseSize), convention);

        public AsmFunction<T1, T2, T3, T4, TResult> ToFunction<T1, T2, T3, T4, TResult>(CallingConvention convention = CallingConvention.Cdecl, int baseSize = 4096)
            => new(AllocateExecutableMemory(asm, baseSize), convention);

        public AsmFunction<T1, T2, T3, T4, T5, TResult> ToFunction<T1, T2, T3, T4, T5, TResult>(CallingConvention convention = CallingConvention.Cdecl, int baseSize = 4096)
            => new(AllocateExecutableMemory(asm, baseSize), convention);

        public AsmFunction<T1, T2, T3, T4, T5, T6, TResult> ToFunction<T1, T2, T3, T4, T5, T6, TResult>(CallingConvention convention = CallingConvention.Cdecl, int baseSize = 4096)
            => new(AllocateExecutableMemory(asm, baseSize), convention);

        public AsmFunction<T1, T2, T3, T4, T5, T6, T7, TResult> ToFunction<T1, T2, T3, T4, T5, T6, T7, TResult>(CallingConvention convention = CallingConvention.Cdecl, int baseSize = 4096)
            => new(AllocateExecutableMemory(asm, baseSize), convention);

        public AsmFunction<T1, T2, T3, T4, T5, T6, T7, T8, TResult> ToFunction<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(CallingConvention convention = CallingConvention.Cdecl, int baseSize = 4096)
            => new(AllocateExecutableMemory(asm, baseSize), convention);

        public AsmFunction<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> ToFunction<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>(CallingConvention convention = CallingConvention.Cdecl, int baseSize = 4096)
            => new(AllocateExecutableMemory(asm, baseSize), convention);

        public AsmFunction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> ToFunction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>(CallingConvention convention = CallingConvention.Cdecl, int baseSize = 4096)
            => new(AllocateExecutableMemory(asm, baseSize), convention);

        public AsmFunction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> ToFunction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>(CallingConvention convention = CallingConvention.Cdecl, int baseSize = 4096)
            => new(AllocateExecutableMemory(asm, baseSize), convention);

        public AsmFunction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> ToFunction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>(CallingConvention convention = CallingConvention.Cdecl, int baseSize = 4096)
            => new(AllocateExecutableMemory(asm, baseSize), convention);
    }

    private static void* AllocateExecutableMemory(Assembler asm, int baseSize = 4096)
    {
        void* memory = VirtualAlloc(null, (nuint)baseSize, MEM_COMMIT | MEM_RESERVE, PAGE_READWRITE);
        if (memory == null)
            throw new Win32Exception(Marshal.GetLastWin32Error());

        using var stream = new MemoryStream();
        var writer = new StreamCodeWriter(stream);
        asm.Assemble(writer, (ulong)memory);

        byte[] asmBytes = stream.ToArray();
        Marshal.Copy(asmBytes, 0, (IntPtr)memory, asmBytes.Length);

        if (!VirtualProtect(memory, (nuint)baseSize, PAGE_EXECUTE_READ, out _))
            throw new Win32Exception(Marshal.GetLastWin32Error());

        return memory;
    }
}