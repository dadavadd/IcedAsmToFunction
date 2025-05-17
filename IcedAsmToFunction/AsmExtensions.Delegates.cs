using System.Runtime.InteropServices;

namespace IcedAsmToFunction;

public unsafe readonly struct AsmFunction : IDisposable
{
    private readonly AsmFunctionBase _base;
    public readonly CallingConvention Convention;

    public AsmFunction(void* functionPtr, CallingConvention convention, bool isOwner = true)
    {
        _base = new AsmFunctionBase(functionPtr, isOwner);
        Convention = convention;
    }
    public delegate* unmanaged[Cdecl]<void> AsCdecl =>
        (delegate* unmanaged[Cdecl]<void>)_base.FunctionPointer;

    public delegate* unmanaged[Stdcall]<void> AsStdcall =>
        (delegate* unmanaged[Stdcall]<void>)_base.FunctionPointer;

    public void Invoke()
    {
        if (_base.FunctionPointer == null)
            throw new ObjectDisposedException(nameof(AsmFunction));

        switch (Convention)
        {
            case CallingConvention.Cdecl:
                AsCdecl();
                break;
            case CallingConvention.StdCall:
                AsStdcall();
                break;
            default:
                throw new InvalidOperationException($"Unsupported calling convention: {Convention}");
        }
    }

    public void Dispose() => _base.Dispose();
}

public unsafe readonly struct AsmFunction<TResult> : IDisposable
{
    private readonly AsmFunctionBase _base;
    public readonly CallingConvention Convention;

    public AsmFunction(void* functionPtr, CallingConvention convention, bool isOwner = true)
    {
        _base = new AsmFunctionBase(functionPtr, isOwner);
        Convention = convention;
    }

    public delegate* unmanaged[Cdecl]<TResult> AsCdecl =>
        (delegate* unmanaged[Cdecl]<TResult>)_base.FunctionPointer;

    public delegate* unmanaged[Stdcall]<TResult> AsStdcall =>
        (delegate* unmanaged[Stdcall]<TResult>)_base.FunctionPointer;

    public TResult Invoke()
    {
        if (_base.FunctionPointer == null)
            throw new ObjectDisposedException(nameof(AsmFunction<TResult>));

        return Convention switch
        {
            CallingConvention.Cdecl => AsCdecl(),
            CallingConvention.StdCall => AsStdcall(),
            _ => throw new InvalidOperationException($"Unsupported calling convention: {Convention}")
        };
    }

    public void Dispose() => _base.Dispose();
}

public unsafe readonly struct AsmFunction<T1, TResult> : IDisposable
{
    private readonly AsmFunctionBase _base;
    public readonly CallingConvention Convention;

    public AsmFunction(void* functionPtr, CallingConvention convention, bool isOwner = true)
    {
        _base = new AsmFunctionBase(functionPtr, isOwner);
        Convention = convention;
    }

    public delegate* unmanaged[Cdecl]<T1, TResult> AsCdecl =>
        (delegate* unmanaged[Cdecl]<T1, TResult>)_base.FunctionPointer;

    public delegate* unmanaged[Stdcall]<T1, TResult> AsStdcall =>
        (delegate* unmanaged[Stdcall]<T1, TResult>)_base.FunctionPointer;

    public TResult Invoke(T1 arg1)
    {
        if (_base.FunctionPointer == null)
            throw new ObjectDisposedException(nameof(AsmFunction<T1, TResult>));

        if (Convention == CallingConvention.Cdecl)
        {
            return AsCdecl(arg1);
        }
        else if (Convention == CallingConvention.StdCall)
        {
            return AsStdcall(arg1);
        }
        else
        {
            throw new InvalidOperationException($"Unsupported calling convention: {Convention}");
        }
    }

    public void Dispose() => _base.Dispose();
}

public unsafe readonly struct AsmFunction<T1, T2, TResult> : IDisposable
{
    private readonly AsmFunctionBase _base;
    public readonly CallingConvention Convention;

    public AsmFunction(void* functionPtr, CallingConvention convention, bool isOwner = true)
    {
        _base = new AsmFunctionBase(functionPtr, isOwner);
        Convention = convention;
    }

    public delegate* unmanaged[Cdecl]<T1, T2, TResult> AsCdecl =>
        (delegate* unmanaged[Cdecl]<T1, T2, TResult>)_base.FunctionPointer;

    public delegate* unmanaged[Stdcall]<T1, T2, TResult> AsStdcall =>
        (delegate* unmanaged[Stdcall]<T1, T2, TResult>)_base.FunctionPointer;

    public TResult Invoke(T1 arg1, T2 arg2)
    {
        if (_base.FunctionPointer == null)
            throw new ObjectDisposedException(nameof(AsmFunction<T1, T2, TResult>));

        if (Convention == CallingConvention.Cdecl)
        {
            return AsCdecl(arg1, arg2);
        }
        else if (Convention == CallingConvention.StdCall)
        {
            return AsStdcall(arg1, arg2);
        }
        else
        {
            throw new InvalidOperationException($"Unsupported calling convention: {Convention}");
        }
    }

    public void Dispose() => _base.Dispose();
}
public unsafe readonly struct AsmFunction<T1, T2, T3, TResult> : IDisposable
{
    private readonly AsmFunctionBase _base;
    public readonly CallingConvention Convention;

    public AsmFunction(void* functionPtr, CallingConvention convention, bool isOwner = true)
    {
        _base = new AsmFunctionBase(functionPtr, isOwner);
        Convention = convention;
    }

    public delegate* unmanaged[Cdecl]<T1, T2, T3, TResult> AsCdecl =>
        (delegate* unmanaged[Cdecl]<T1, T2, T3, TResult>)_base.FunctionPointer;

    public delegate* unmanaged[Stdcall]<T1, T2, T3, TResult> AsStdcall =>
        (delegate* unmanaged[Stdcall]<T1, T2, T3, TResult>)_base.FunctionPointer;

    public TResult Invoke(T1 arg1, T2 arg2, T3 arg3)
    {
        if (_base.FunctionPointer == null)
            throw new ObjectDisposedException(nameof(AsmFunction<T1, T2, T3, TResult>));

        return Convention switch
        {
            CallingConvention.Cdecl => AsCdecl(arg1, arg2, arg3),
            CallingConvention.StdCall => AsStdcall(arg1, arg2, arg3),
            _ => throw new InvalidOperationException($"Unsupported calling convention: {Convention}")
        };
    }

    public void Dispose() => _base.Dispose();
}

public unsafe readonly struct AsmFunction<T1, T2, T3, T4, TResult> : IDisposable
{
    private readonly AsmFunctionBase _base;
    public readonly CallingConvention Convention;

    public AsmFunction(void* functionPtr, CallingConvention convention, bool isOwner = true)
    {
        _base = new AsmFunctionBase(functionPtr, isOwner);
        Convention = convention;
    }

    public delegate* unmanaged[Cdecl]<T1, T2, T3, T4, TResult> AsCdecl =>
        (delegate* unmanaged[Cdecl]<T1, T2, T3, T4, TResult>)_base.FunctionPointer;

    public delegate* unmanaged[Stdcall]<T1, T2, T3, T4, TResult> AsStdcall =>
        (delegate* unmanaged[Stdcall]<T1, T2, T3, T4, TResult>)_base.FunctionPointer;

    public TResult Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4)
    {
        if (_base.FunctionPointer == null)
            throw new ObjectDisposedException(nameof(AsmFunction<T1, T2, T3, T4, TResult>));

        return Convention switch
        {
            CallingConvention.Cdecl => AsCdecl(arg1, arg2, arg3, arg4),
            CallingConvention.StdCall => AsStdcall(arg1, arg2, arg3, arg4),
            _ => throw new InvalidOperationException($"Unsupported calling convention: {Convention}")
        };
    }

    public void Dispose() => _base.Dispose();
}

public unsafe readonly struct AsmFunction<T1, T2, T3, T4, T5, TResult> : IDisposable
{
    private readonly AsmFunctionBase _base;
    public readonly CallingConvention Convention;

    public AsmFunction(void* functionPtr, CallingConvention convention, bool isOwner = true)
    {
        _base = new AsmFunctionBase(functionPtr, isOwner);
        Convention = convention;
    }

    public delegate* unmanaged[Cdecl]<T1, T2, T3, T4, T5, TResult> AsCdecl =>
        (delegate* unmanaged[Cdecl]<T1, T2, T3, T4, T5, TResult>)_base.FunctionPointer;

    public delegate* unmanaged[Stdcall]<T1, T2, T3, T4, T5, TResult> AsStdcall =>
        (delegate* unmanaged[Stdcall]<T1, T2, T3, T4, T5, TResult>)_base.FunctionPointer;

    public TResult Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
    {
        if (_base.FunctionPointer == null)
            throw new ObjectDisposedException(nameof(AsmFunction<T1, T2, T3, T4, T5, TResult>));

        return Convention switch
        {
            CallingConvention.Cdecl => AsCdecl(arg1, arg2, arg3, arg4, arg5),
            CallingConvention.StdCall => AsStdcall(arg1, arg2, arg3, arg4, arg5),
            _ => throw new InvalidOperationException($"Unsupported calling convention: {Convention}")
        };
    }

    public void Dispose() => _base.Dispose();
}

public unsafe readonly struct AsmFunction<T1, T2, T3, T4, T5, T6, TResult> : IDisposable
{
    private readonly AsmFunctionBase _base;
    public readonly CallingConvention Convention;

    public AsmFunction(void* functionPtr, CallingConvention convention, bool isOwner = true)
    {
        _base = new AsmFunctionBase(functionPtr, isOwner);
        Convention = convention;
    }

    public delegate* unmanaged[Cdecl]<T1, T2, T3, T4, T5, T6, TResult> AsCdecl =>
        (delegate* unmanaged[Cdecl]<T1, T2, T3, T4, T5, T6, TResult>)_base.FunctionPointer;

    public delegate* unmanaged[Stdcall]<T1, T2, T3, T4, T5, T6, TResult> AsStdcall =>
        (delegate* unmanaged[Stdcall]<T1, T2, T3, T4, T5, T6, TResult>)_base.FunctionPointer;

    public TResult Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
    {
        if (_base.FunctionPointer == null)
            throw new ObjectDisposedException(nameof(AsmFunction<T1, T2, T3, T4, T5, T6, TResult>));

        return Convention switch
        {
            CallingConvention.Cdecl => AsCdecl(arg1, arg2, arg3, arg4, arg5, arg6),
            CallingConvention.StdCall => AsStdcall(arg1, arg2, arg3, arg4, arg5, arg6),
            _ => throw new InvalidOperationException($"Unsupported calling convention: {Convention}")
        };
    }

    public void Dispose() => _base.Dispose();
}

public unsafe readonly struct AsmFunction<T1, T2, T3, T4, T5, T6, T7, TResult> : IDisposable
{
    private readonly AsmFunctionBase _base;
    public readonly CallingConvention Convention;

    public AsmFunction(void* functionPtr, CallingConvention convention, bool isOwner = true)
    {
        _base = new AsmFunctionBase(functionPtr, isOwner);
        Convention = convention;
    }

    public delegate* unmanaged[Cdecl]<T1, T2, T3, T4, T5, T6, T7, TResult> AsCdecl =>
        (delegate* unmanaged[Cdecl]<T1, T2, T3, T4, T5, T6, T7, TResult>)_base.FunctionPointer;

    public delegate* unmanaged[Stdcall]<T1, T2, T3, T4, T5, T6, T7, TResult> AsStdcall =>
        (delegate* unmanaged[Stdcall]<T1, T2, T3, T4, T5, T6, T7, TResult>)_base.FunctionPointer;

    public TResult Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
    {
        if (_base.FunctionPointer == null)
            throw new ObjectDisposedException(nameof(AsmFunction<T1, T2, T3, T4, T5, T6, T7, TResult>));

        return Convention switch
        {
            CallingConvention.Cdecl => AsCdecl(arg1, arg2, arg3, arg4, arg5, arg6, arg7),
            CallingConvention.StdCall => AsStdcall(arg1, arg2, arg3, arg4, arg5, arg6, arg7),
            _ => throw new InvalidOperationException($"Unsupported calling convention: {Convention}")
        };
    }

    public void Dispose() => _base.Dispose();
}

public unsafe readonly struct AsmFunction<T1, T2, T3, T4, T5, T6, T7, T8, TResult> : IDisposable
{
    private readonly AsmFunctionBase _base;
    public readonly CallingConvention Convention;

    public AsmFunction(void* functionPtr, CallingConvention convention, bool isOwner = true)
    {
        _base = new AsmFunctionBase(functionPtr, isOwner);
        Convention = convention;
    }

    public delegate* unmanaged[Cdecl]<T1, T2, T3, T4, T5, T6, T7, T8, TResult> AsCdecl =>
        (delegate* unmanaged[Cdecl]<T1, T2, T3, T4, T5, T6, T7, T8, TResult>)_base.FunctionPointer;

    public delegate* unmanaged[Stdcall]<T1, T2, T3, T4, T5, T6, T7, T8, TResult> AsStdcall =>
        (delegate* unmanaged[Stdcall]<T1, T2, T3, T4, T5, T6, T7, T8, TResult>)_base.FunctionPointer;

    public TResult Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8)
    {
        if (_base.FunctionPointer == null)
            throw new ObjectDisposedException(nameof(AsmFunction<T1, T2, T3, T4, T5, T6, T7, T8, TResult>));

        return Convention switch
        {
            CallingConvention.Cdecl => AsCdecl(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8),
            CallingConvention.StdCall => AsStdcall(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8),
            _ => throw new InvalidOperationException($"Unsupported calling convention: {Convention}")
        };
    }

    public void Dispose() => _base.Dispose();
}

public unsafe readonly struct AsmFunction<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> : IDisposable
{
    private readonly AsmFunctionBase _base;
    public readonly CallingConvention Convention;

    public AsmFunction(void* functionPtr, CallingConvention convention, bool isOwner = true)
    {
        _base = new AsmFunctionBase(functionPtr, isOwner);
        Convention = convention;
    }

    public delegate* unmanaged[Cdecl]<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> AsCdecl =>
        (delegate* unmanaged[Cdecl]<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>)_base.FunctionPointer;

    public delegate* unmanaged[Stdcall]<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> AsStdcall =>
        (delegate* unmanaged[Stdcall]<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>)_base.FunctionPointer;

    public TResult Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9)
    {
        if (_base.FunctionPointer == null)
            throw new ObjectDisposedException(nameof(AsmFunction<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>));

        return Convention switch
        {
            CallingConvention.Cdecl => AsCdecl(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9),
            CallingConvention.StdCall => AsStdcall(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9),
            _ => throw new InvalidOperationException($"Unsupported calling convention: {Convention}")
        };
    }

    public void Dispose() => _base.Dispose();
}

public unsafe readonly struct AsmFunction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> : IDisposable
{
    private readonly AsmFunctionBase _base;
    public readonly CallingConvention Convention;

    public AsmFunction(void* functionPtr, CallingConvention convention, bool isOwner = true)
    {
        _base = new AsmFunctionBase(functionPtr, isOwner);
        Convention = convention;
    }

    public delegate* unmanaged[Cdecl]<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> AsCdecl =>
        (delegate* unmanaged[Cdecl]<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>)_base.FunctionPointer;

    public delegate* unmanaged[Stdcall]<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> AsStdcall =>
        (delegate* unmanaged[Stdcall]<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>)_base.FunctionPointer;

    public TResult Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10)
    {
        if (_base.FunctionPointer == null)
            throw new ObjectDisposedException(nameof(AsmFunction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>));

        return Convention switch
        {
            CallingConvention.Cdecl => AsCdecl(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10),
            CallingConvention.StdCall => AsStdcall(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10),
            _ => throw new InvalidOperationException($"Unsupported calling convention: {Convention}")
        };
    }

    public void Dispose() => _base.Dispose();
}

public unsafe readonly struct AsmFunction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> : IDisposable
{
    private readonly AsmFunctionBase _base;
    public readonly CallingConvention Convention;

    public AsmFunction(void* functionPtr, CallingConvention convention, bool isOwner = true)
    {
        _base = new AsmFunctionBase(functionPtr, isOwner);
        Convention = convention;
    }

    public delegate* unmanaged[Cdecl]<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> AsCdecl =>
        (delegate* unmanaged[Cdecl]<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>)_base.FunctionPointer;

    public delegate* unmanaged[Stdcall]<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> AsStdcall =>
        (delegate* unmanaged[Stdcall]<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>)_base.FunctionPointer;

    public TResult Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11)
    {
        if (_base.FunctionPointer == null)
            throw new ObjectDisposedException(nameof(AsmFunction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>));

        return Convention switch
        {
            CallingConvention.Cdecl => AsCdecl(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11),
            CallingConvention.StdCall => AsStdcall(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11),
            _ => throw new InvalidOperationException($"Unsupported calling convention: {Convention}")
        };
    }

    public void Dispose() => _base.Dispose();
}

public unsafe readonly struct AsmFunction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> : IDisposable
{
    private readonly AsmFunctionBase _base;
    public readonly CallingConvention Convention;

    public AsmFunction(void* functionPtr, CallingConvention convention, bool isOwner = true)
    {
        _base = new AsmFunctionBase(functionPtr, isOwner);
        Convention = convention;
    }

    public delegate* unmanaged[Cdecl]<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> AsCdecl =>
        (delegate* unmanaged[Cdecl]<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>)_base.FunctionPointer;

    public delegate* unmanaged[Stdcall]<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> AsStdcall =>
        (delegate* unmanaged[Stdcall]<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>)_base.FunctionPointer;

    public TResult Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12)
    {
        if (_base.FunctionPointer == null)
            throw new ObjectDisposedException(nameof(AsmFunction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>));

        return Convention switch
        {
            CallingConvention.Cdecl => AsCdecl(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12),
            CallingConvention.StdCall => AsStdcall(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12),
            _ => throw new InvalidOperationException($"Unsupported calling convention: {Convention}")
        };
    }

    public void Dispose() => _base.Dispose();
}
