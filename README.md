
# RoomBooking.CoreWcfSolution

Учебный проект на **CoreWCF + .NET 8 + ASP.NET Core MVC + EF Core + SQLite**.

Тема проекта: **система бронирования переговорных комнат**.

## Что внутри

- CoreWCF-сервис с документированными контрактами и WSDL
- CRUD по комнатам
- CRUD по бронированиям
- Простая аутентификация через логин/пароль и сессионный токен
- Веб-клиент с админкой на ASP.NET Core MVC
- Бизнес-правила:
  - нельзя бронировать в прошлом;
  - нельзя создавать пересекающиеся бронирования одной комнаты;
  - нельзя удалять комнату, если у неё есть активные будущие бронирования;
  - операции управления комнатами доступны только администратору;
  - сотрудник видит и редактирует только свои бронирования.
- Юнит-тесты для бизнес-логики

## Иерархия решения

- `RoomBooking.Contracts` — сервисные и дата-контракты
- `RoomBooking.Domain` — сущности, интерфейсы репозиториев, хеширование пароля
- `RoomBooking.Application` — бизнес-логика и маппинг
- `RoomBooking.Infrastructure` — EF Core, DbContext, репозитории, seed
- `RoomBooking.ServiceHost` — CoreWCF host
- `RoomBooking.WebClient` — веб-клиент и админка
- `RoomBooking.Tests` — тесты

## Стек

- .NET 8
- CoreWCF 1.8.0
- EF Core 8.0.19
- SQLite
- ASP.NET Core MVC
- xUnit

CoreWCF работает поверх ASP.NET Core, поддерживает публикацию metadata/WSDL через `AddServiceModelMetadata`, а клиентские прокси для WCF в .NET можно генерировать через `dotnet-svcutil`. Для этого решения клиент реализован вручную через WCF `ChannelFactory` и `BasicHttpBinding`. citeturn930226search1turn930226search2turn750775search2turn162442search9

## Как открыть в Visual Studio 2022

1. Распакуй архив.
2. Открой файл `RoomBooking.CoreWcfSolution.sln`.
3. Дождись восстановления пакетов.

## Что нужно сделать после распаковки

### 1) Создать первую миграцию

Открой **Консоль диспетчера пакетов**:

**Сервис** → **Диспетчер пакетов NuGet** → **Консоль диспетчера пакетов**

Выбери:
- **Проект по умолчанию**: `RoomBooking.Infrastructure`
- **Запускаемый проект**: `RoomBooking.ServiceHost`

Выполни:

```powershell
Add-Migration InitialCreate -Project RoomBooking.Infrastructure -StartupProject RoomBooking.ServiceHost
Update-Database -Project RoomBooking.Infrastructure -StartupProject RoomBooking.ServiceHost
```

### 2) Запустить проекты

Поставь несколько запускаемых проектов:

- `RoomBooking.ServiceHost`
- `RoomBooking.WebClient`


## URL по умолчанию

### CoreWCF host
- `http://localhost:5050/`
- `http://localhost:5050/Services/AuthService.svc?wsdl`
- `http://localhost:5050/Services/RoomService.svc?wsdl`
- `http://localhost:5050/Services/BookingService.svc?wsdl`

### Web client
- `http://localhost:5051/`

## Тестовые пользователи

Seed создаёт двух пользователей:

### Администратор
- email: `admin@room-booking.local`
- password: `Admin123!`

### Сотрудник
- email: `employee@room-booking.local`
- password: `Employee123!`

