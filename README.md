# TechService ERP

Система за управление на ИТ сервиз и склад – учебен проект (Junior C# Developer).

## Архитектура

| Проект | Тип | Референции |
|---|---|---|
| `TechService.Models` | Class Library | – |
| `TechService.DataStructures` | Class Library | – |
| `TechService.Core` | Class Library | Models, DataStructures |
| `TechService.ConsoleApp` | Console App | Core, Models, DataStructures |
| `TechService.Tests` | NUnit Test Project | Core, Models, DataStructures |

## Стартиране

```bash
dotnet build TechService.sln
dotnet test TechService.sln
dotnet run --project src/TechService.ConsoleApp
```

Изисква .NET 8 SDK.
