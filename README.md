# Expression Cacher

Compilation

The call to Expression.Compile goes through exactly the same process as any other .NET code your application contains in the sense that:

IL code is generated
IL code is JIT-ted to machine code
(the parsing step is skipped because an Expression Tree is already created and does not have to be generated from the input code)

You can look at the source code of the expression compiler to verify that indeed, IL code is generated.

Optimization

Please be aware that almost all of the optimization done by the CLR is done in the JIT step, not from compiling C# source code. This optimization will also be done when compiling the IL code from your lambda delegate to machine code.

-----------------

Intel Core i7-8700 CPU 3.20GHz (Coffee Lake), 1 CPU, 12 logical and 6 physical cores
.NET SDK=5.0.300
  [Host]     : .NET 5.0.6 (5.0.621.22011), X64 RyuJIT
  DefaultJob : .NET 5.0.6 (5.0.621.22011), X64 RyuJIT


|           Method |           Mean |       Error |        StdDev |
|----------------- |---------------:|------------:|--------------:|
|  RegularProperty |      0.1341 ns |   0.0584 ns |     0.0518 ns |
|          Compile | 48,623.4293 ns | 961.3695 ns | 2,321.8155 ns |
| ExpressionCacher |  1,111.2344 ns |  22.1578 ns |    33.8374 ns |

