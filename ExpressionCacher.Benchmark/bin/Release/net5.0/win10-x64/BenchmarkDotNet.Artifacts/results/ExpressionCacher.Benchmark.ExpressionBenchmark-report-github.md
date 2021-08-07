``` ini

BenchmarkDotNet=v0.13.0, OS=Windows 10.0.19043.1110 (21H1/May2021Update)
Intel Core i7-8700 CPU 3.20GHz (Coffee Lake), 1 CPU, 12 logical and 6 physical cores
.NET SDK=5.0.300
  [Host]     : .NET 5.0.6 (5.0.621.22011), X64 RyuJIT
  DefaultJob : .NET 5.0.6 (5.0.621.22011), X64 RyuJIT


```
|           Method |           Mean |       Error |        StdDev |
|----------------- |---------------:|------------:|--------------:|
|  RegularProperty |      0.1341 ns |   0.0584 ns |     0.0518 ns |
|          Compile | 48,623.4293 ns | 961.3695 ns | 2,321.8155 ns |
| ExpressionCacher |  1,111.2344 ns |  22.1578 ns |    33.8374 ns |
