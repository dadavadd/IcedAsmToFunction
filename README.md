## IcedAsmToFunction

Библиотека `IcedAsmToFunction` предоставляет удобные обёртки для работы с собранным машинным кодом (генерируемым через [Iced.Intel](https://github.com/icedland/iced)) и его выполнением в памяти как функции с произвольным числом аргументов.

---

### Особенности

* **Генерация исполняемой памяти** для кода, собранного через `Assembler` из Iced.Intel.
* **Обёртка `AsmFunction`** под function pointers с поддержкой до 12 параметров.
* **Безопасное освобождение памяти**: реализован `IDisposable`, у которого в `Dispose` вызывается `VirtualFree`.
* **Implicit conversion** в `delegate* unmanaged[Cdecl]<...>` для удобства вызова.

---

### Быстрый старт

```csharp
using Iced.Intel;
using IcedAsmToFunction;

// 1. Собираем код (пример: функция, возвращающая константу 42)
var asm = new Assembler(64);
asm.mov(rax, 42);
asm.ret();

// 2. Конвертируем в функцию без аргументов
using var func = asm.ToFunction();

// 3. Вызываем
func.Invoke();  // возвращает void

// Для функции с возвращаемым значением:
var asm2 = new Assembler(64);
asm2.mov(rax, 123);
asm2.ret();
using var func2 = asm2.ToFunction<int>();
int result = func2.Invoke(); // result == 123
```

---

### API

* `extension Assembler.ToFunction(baseSize = 4096)`
  Возвращает `AsmFunction` для кода без параметров.

* `extension Assembler.ToFunction<T>(baseSize = 4096)`
  Возвращает `AsmFunction<TResult>`.

* `extension Assembler.ToFunction<T1, TResult>(baseSize = 4096)`
  Возвращает `AsmFunction<T1, TResult>`.

* И так далее до `AsmFunction<T1,..,T12, TResult>`.

Каждый `AsmFunction` реализует:

```csharp
void* FunctionPointer { get; }
Delegate pointer Delegate* unmanaged[Cdecl]<...>
TResult Invoke(arg1, ..., argN);
---
