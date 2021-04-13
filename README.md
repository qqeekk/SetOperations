Set Operations Test Project
===

### Вариант 3: Множество.

Протестированы следующие функции:  
- Сравнение (IsSetEquals)
- Объединение (GetUnion)
- Пересечение (GetIntersection)
- Разность (GetDifference, GetSymmetricDifference)
- Проверка на включение в данное множество в качестве подмножества (IsProperSubsetOf)

Исходный код тестируемого класса расположен в файле SetOperationExtensions.cs  
Исходный код тестов расположен в файле SetOperationExtensions.Tests.cs  

## Системные требования:  
- Одна из поддерживаемых платформ: 
    - Wndows 7+ (Any CPU)
    - Linux (Arm32 | Arm64 | x64 | x64 Alpine)
    - macOS (x64)
- .NET Core 3.1.x SDK (https://dotnet.microsoft.com/download/dotnet/3.1)

---    
Выполните следующую комманду чтобы убедиться, что указанные пакеты установленны корректно.
```bash
> dotnet --list-sdks
```

---
## Инструкции по запуску
Для запуска тестов выполните:

```bash
> cd ./src
> dotnet test -l:"console;verbosity=normal" /p:CollectCoverage=true
```
