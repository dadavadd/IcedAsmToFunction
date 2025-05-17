using Iced.Intel;
using System.Runtime.Versioning;
using static Iced.Intel.AssemblerRegisters;

namespace IcedAsmToFunction.Tests;

[SupportedOSPlatform("windows5.1.2600")]
public class AsmExtensionsTests
{
    [Fact]
    public unsafe void ToFunction_NoParameters_NoResult_ExecutesCorrectly()
    {
        // Arrange
        var asm = new Assembler(64);
        asm.ret();

        // Act
        using var func = asm.ToFunction();

        // Assert - if it executes without throwing, the test passes
        func.Invoke();
    }

    [Fact]
    public unsafe void ToFunction_WithSimple32Result_ReturnsCorrectValue()
    {
        var asm = new Assembler(32);

        asm.mov(eax, 22);
        asm.ret();

        using var func = asm.ToFunction<int>();
        int result = func.Invoke();

        Assert.Equal(22, result);
    }

    [Fact]
    public unsafe void ToFunction_WithSimpleResult_ReturnsCorrectValue()
    {
        // Arrange
        var asm = new Assembler(64);
        asm.mov(eax, 42);  // Return value in eax
        asm.ret();

        // Act
        using var func = asm.ToFunction<int>();
        int result = func.Invoke();

        // Assert
        Assert.Equal(42, result);
    }

    [Fact]
    public unsafe void ToFunction_WithParameter_ProcessesCorrectly()
    {
        // Arrange
        var asm = new Assembler(64);
        // Parameter is in ECX (first param in Windows x64 calling convention)
        asm.mov(eax, ecx);  // Move first param to return register
        asm.add(eax, 10);   // Add 10 to the value
        asm.ret();

        // Act
        using var func = asm.ToFunction<int, int>();
        int result = func.Invoke(32);

        // Assert
        Assert.Equal(42, result);
    }

    [Fact]
    public unsafe void ToFunction_WithTwoParameters_AddsCorrectly()
    {
        // Arrange
        var asm = new Assembler(64);
        // First parameter is in ECX, second in EDX (Windows x64 calling convention)
        asm.mov(eax, ecx);  // Move first param to return register
        asm.add(eax, edx);  // Add second param
        asm.ret();

        // Act
        using var func = asm.ToFunction<int, int, int>();
        int result = func.Invoke(20, 22);

        // Assert
        Assert.Equal(42, result);
    }

    [Fact]
    public unsafe void ToFunction_WithThreeParameters_MultiplicationTest()
    {
        // Arrange
        var asm = new Assembler(64);
        // Parameters in ECX, EDX, R8D
        asm.mov(eax, ecx);  // First param
        asm.imul(eax, edx); // Multiply by second param
        asm.add(eax, r8d);  // Add third param
        asm.ret();

        // Act
        using var func = asm.ToFunction<int, int, int, int>();
        int result = func.Invoke(10, 4, 2);

        // Assert
        Assert.Equal(42, result);
    }


    [Fact]
    public unsafe void ToFunction_WithFourParameters_ComplexOperation()
    {
        // Arrange
        var asm = new Assembler(64);
        // Parameters in ECX, EDX, R8D, R9D
        asm.mov(eax, ecx);    // Move first param to return register
        asm.add(eax, edx);    // Add second param
        asm.imul(eax, r8d);   // Multiply by third param
        asm.sub(eax, r9d);    // Subtract fourth param
        asm.ret();

        // Act
        using var func = asm.ToFunction<int, int, int, int, int>();
        int result = func.Invoke(10, 6, 3, 6);

        // Assert
        Assert.Equal(42, result);  // (10 + 6) * 3 - 6 = 48 - 6 = 42
    }

    [Fact]
    public unsafe void ToFunction_WithDifferentSizes_AllocatesCorrectly()
    {
        // Small allocation
        var asmSmall = new Assembler(64);
        asmSmall.mov(eax, 1);
        asmSmall.ret();
        using var funcSmall = asmSmall.ToFunction<int>(baseSize: 1024);

        // Large allocation
        var asmLarge = new Assembler(64);
        asmLarge.mov(eax, 2);
        asmLarge.ret();
        using var funcLarge = asmLarge.ToFunction<int>(baseSize: 8192);

        // Both should work correctly despite different allocation sizes
        Assert.Equal(1, funcSmall.Invoke());
        Assert.Equal(2, funcLarge.Invoke());
    }
}
