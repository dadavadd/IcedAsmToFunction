using System.Runtime.Versioning;

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

public unsafe readonly struct AsmFunction(void* functionPtr, bool isOwner = true) : IDisposable
{
    private readonly AsmFunctionBase _base = new(functionPtr, isOwner);

    public delegate* unmanaged[Cdecl]<void> Function =>
        (delegate* unmanaged[Cdecl]<void>)_base.FunctionPointer;

    public void Invoke()
    {
        if (_base.FunctionPointer == null)
            throw new ObjectDisposedException(nameof(AsmFunction));
        Function();
    }

    public void Dispose() => _base.Dispose();

    public static implicit operator delegate* unmanaged[Cdecl]<void>(AsmFunction func) => func.Function;
}

public unsafe readonly struct AsmFunction<TResult>(void* functionPtr, bool isOwner = true) : IDisposable
{
    private readonly AsmFunctionBase _base = new AsmFunctionBase(functionPtr, isOwner);

    public delegate* unmanaged[Cdecl]<TResult> Function =>
        (delegate* unmanaged[Cdecl]<TResult>)_base.FunctionPointer;

    public TResult Invoke()
    {
        if (_base.FunctionPointer == null)
            throw new ObjectDisposedException(nameof(AsmFunction<TResult>));
        return Function();
    }

    public void Dispose() => _base.Dispose();

    public static implicit operator delegate* unmanaged[Cdecl]<TResult>(AsmFunction<TResult> func) =>
        func.Function;
}

public unsafe readonly struct AsmFunction<T1, TResult>(void* functionPtr, bool isOwner = true) : IDisposable
{
    private readonly AsmFunctionBase _base = new(functionPtr, isOwner);

    public delegate* unmanaged[Cdecl]<T1, TResult> Function =>
        (delegate* unmanaged[Cdecl]<T1, TResult>)_base.FunctionPointer;

    public TResult Invoke(T1 arg1)
    {
        if (_base.FunctionPointer == null)
            throw new ObjectDisposedException(nameof(AsmFunction<T1, TResult>));
        return Function(arg1);
    }

    public void Dispose() => _base.Dispose();

    public static implicit operator delegate* unmanaged[Cdecl]<T1, TResult>(AsmFunction<T1, TResult> func) =>
        func.Function;
}

public unsafe readonly struct AsmFunction<T1, T2, TResult>(void* functionPtr, bool isOwner = true) : IDisposable
{
    private readonly AsmFunctionBase _base = new(functionPtr, isOwner);

    public delegate* unmanaged[Cdecl]<T1, T2, TResult> Function =>
        (delegate* unmanaged[Cdecl]<T1, T2, TResult>)_base.FunctionPointer;

    public TResult Invoke(T1 arg1, T2 arg2)
    {
        if (_base.FunctionPointer == null)
            throw new ObjectDisposedException(nameof(AsmFunction<T1, T2, TResult>));
        return Function(arg1, arg2);
    }

    public void Dispose() => _base.Dispose();

    public static implicit operator delegate* unmanaged[Cdecl]<T1, T2, TResult>(AsmFunction<T1, T2, TResult> func) =>
        func.Function;
}


public unsafe readonly struct AsmFunction<T1, T2, T3, TResult>(void* functionPtr, bool isOwner = true) : IDisposable
{
    private readonly AsmFunctionBase _base = new(functionPtr, isOwner);

    public delegate* unmanaged[Cdecl]<T1, T2, T3, TResult> Function =>
        (delegate* unmanaged[Cdecl]<T1, T2, T3, TResult>)_base.FunctionPointer;

    public TResult Invoke(T1 arg1, T2 arg2, T3 arg3)
    {
        if (_base.FunctionPointer == null)
            throw new ObjectDisposedException(nameof(AsmFunction<T1, T2, T3, TResult>));
        return Function(arg1, arg2, arg3);
    }

    public void Dispose() => _base.Dispose();

    public static implicit operator delegate* unmanaged[Cdecl]<T1, T2, T3, TResult>(AsmFunction<T1, T2, T3, TResult> func) =>
        func.Function;
}

public unsafe readonly struct AsmFunction<T1, T2, T3, T4, TResult>(void* functionPtr, bool isOwner = true) : IDisposable
{
    private readonly AsmFunctionBase _base = new AsmFunctionBase(functionPtr, isOwner);

    public delegate* unmanaged[Cdecl]<T1, T2, T3, T4, TResult> Function =>
        (delegate* unmanaged[Cdecl]<T1, T2, T3, T4, TResult>)_base.FunctionPointer;

    public TResult Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4)
    {
        if (_base.FunctionPointer == null)
            throw new ObjectDisposedException(nameof(AsmFunction<T1, T2, T3, T4, TResult>));
        return Function(arg1, arg2, arg3, arg4);
    }

    public void Dispose() => _base.Dispose();

    public static implicit operator delegate* unmanaged[Cdecl]<T1, T2, T3, T4, TResult>(AsmFunction<T1, T2, T3, T4, TResult> func) =>
        func.Function;
}

public unsafe readonly struct AsmFunction<T1, T2, T3, T4, T5, TResult>(void* functionPtr, bool isOwner = true) : IDisposable
{
    private readonly AsmFunctionBase _base = new AsmFunctionBase(functionPtr, isOwner);

    public delegate* unmanaged[Cdecl]<T1, T2, T3, T4, T5, TResult> Function =>
        (delegate* unmanaged[Cdecl]<T1, T2, T3, T4, T5, TResult>)_base.FunctionPointer;

    public TResult Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
    {
        if (_base.FunctionPointer == null)
            throw new ObjectDisposedException(nameof(AsmFunction<T1, T2, T3, T4, T5, TResult>));
        return Function(arg1, arg2, arg3, arg4, arg5);
    }

    public void Dispose() => _base.Dispose();

    public static implicit operator delegate* unmanaged[Cdecl]<T1, T2, T3, T4, T5, TResult>(AsmFunction<T1, T2, T3, T4, T5, TResult> func) =>
        func.Function;
}


public unsafe readonly struct AsmFunction<T1, T2, T3, T4, T5, T6, TResult>(void* functionPtr, bool isOwner = true) : IDisposable
{
    private readonly AsmFunctionBase _base = new AsmFunctionBase(functionPtr, isOwner);

    public delegate* unmanaged[Cdecl]<T1, T2, T3, T4, T5, T6, TResult> Function =>
        (delegate* unmanaged[Cdecl]<T1, T2, T3, T4, T5, T6, TResult>)_base.FunctionPointer;

    public TResult Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
    {
        if (_base.FunctionPointer == null)
            throw new ObjectDisposedException(nameof(AsmFunction<T1, T2, T3, T4, T5, T6, TResult>));
        return Function(arg1, arg2, arg3, arg4, arg5, arg6);
    }

    public void Dispose() => _base.Dispose();

    public static implicit operator delegate* unmanaged[Cdecl]<T1, T2, T3, T4, T5, T6, TResult>(AsmFunction<T1, T2, T3, T4, T5, T6, TResult> func) =>
        func.Function;
}

public unsafe readonly struct AsmFunction<T1, T2, T3, T4, T5, T6, T7, TResult>(void* functionPtr, bool isOwner = true) : IDisposable
{
    private readonly AsmFunctionBase _base = new AsmFunctionBase(functionPtr, isOwner);

    public delegate* unmanaged[Cdecl]<T1, T2, T3, T4, T5, T6, T7, TResult> Function =>
        (delegate* unmanaged[Cdecl]<T1, T2, T3, T4, T5, T6, T7, TResult>)_base.FunctionPointer;

    public TResult Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
    {
        if (_base.FunctionPointer == null)
            throw new ObjectDisposedException(nameof(AsmFunction<T1, T2, T3, T4, T5, T6, T7, TResult>));
        return Function(arg1, arg2, arg3, arg4, arg5, arg6, arg7);
    }

    public void Dispose() => _base.Dispose();

    public static implicit operator delegate* unmanaged[Cdecl]<T1, T2, T3, T4, T5, T6, T7, TResult>(AsmFunction<T1, T2, T3, T4, T5, T6, T7, TResult> func) =>
        func.Function;
}

public unsafe readonly struct AsmFunction<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(void* functionPtr, bool isOwner = true) : IDisposable
{
    private readonly AsmFunctionBase _base = new(functionPtr, isOwner);

    public delegate* unmanaged[Cdecl]<T1, T2, T3, T4, T5, T6, T7, T8, TResult> Function =>
        (delegate* unmanaged[Cdecl]<T1, T2, T3, T4, T5, T6, T7, T8, TResult>)_base.FunctionPointer;

    public TResult Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8)
    {
        if (_base.FunctionPointer == null)
            throw new ObjectDisposedException(nameof(AsmFunction<T1, T2, T3, T4, T5, T6, T7, T8, TResult>));
        return Function(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
    }

    public void Dispose() => _base.Dispose();

    public static implicit operator delegate* unmanaged[Cdecl]<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(AsmFunction<T1, T2, T3, T4, T5, T6, T7, T8, TResult> func) =>
        func.Function;
}

public unsafe readonly struct AsmFunction<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>(void* functionPtr, bool isOwner = true) : IDisposable
{
    private readonly AsmFunctionBase _base = new AsmFunctionBase(functionPtr, isOwner);

    public delegate* unmanaged[Cdecl]<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> Function =>
        (delegate* unmanaged[Cdecl]<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>)_base.FunctionPointer;

    public TResult Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9)
    {
        if (_base.FunctionPointer == null)
            throw new ObjectDisposedException(nameof(AsmFunction<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>));
        return Function(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
    }

    public void Dispose() => _base.Dispose();

    public static implicit operator delegate* unmanaged[Cdecl]<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>(
        AsmFunction<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> func) => func.Function;
}

public unsafe readonly struct AsmFunction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>(void* functionPtr, bool isOwner = true) : IDisposable
{
    private readonly AsmFunctionBase _base = new AsmFunctionBase(functionPtr, isOwner);

    public delegate* unmanaged[Cdecl]<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> Function =>
        (delegate* unmanaged[Cdecl]<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>)_base.FunctionPointer;

    public TResult Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10)
    {
        if (_base.FunctionPointer == null)
            throw new ObjectDisposedException(nameof(AsmFunction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>));
        return Function(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
    }

    public void Dispose() => _base.Dispose();

    public static implicit operator delegate* unmanaged[Cdecl]<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>(
        AsmFunction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> func) => func.Function;
}

public unsafe readonly struct AsmFunction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>(void* functionPtr, bool isOwner = true) : IDisposable
{
    private readonly AsmFunctionBase _base = new AsmFunctionBase(functionPtr, isOwner);

    public delegate* unmanaged[Cdecl]<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> Function =>
        (delegate* unmanaged[Cdecl]<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>)_base.FunctionPointer;

    public TResult Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11)
    {
        if (_base.FunctionPointer == null)
            throw new ObjectDisposedException(nameof(AsmFunction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>));
        return Function(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
    }

    public void Dispose() => _base.Dispose();

    public static implicit operator delegate* unmanaged[Cdecl]<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>(
        AsmFunction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> func) => func.Function;
}

public unsafe readonly struct AsmFunction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> : IDisposable
{
    private readonly AsmFunctionBase _base;

    public AsmFunction(void* functionPtr, bool isOwner = true) => _base = new AsmFunctionBase(functionPtr, isOwner);

    public delegate* unmanaged[Cdecl]<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> Function =>
        (delegate* unmanaged[Cdecl]<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>)_base.FunctionPointer;

    public TResult Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12)
    {
        if (_base.FunctionPointer == null)
            throw new ObjectDisposedException(nameof(AsmFunction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>));
        return Function(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);
    }

    public void Dispose() => _base.Dispose();

    public static implicit operator delegate* unmanaged[Cdecl]<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>(
        AsmFunction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> func) => func.Function;
}
