# Карта загрязнения Казахстана

Данная программа позволяет заносить новые данные по загрязнению почвы в Казахстане

Бұл бағдарлама Қазақстандағы топырақтың ластануы туралы жаңа деректерді енгізуге мүмкіндік береді.

## How to add dependency

```
dotnet restore --locked-mode
```

## How to run

```shell
dotnet run --project soilpollution/soilpollution.csproj
```

## How to add migrations

```shell
dotnet ef migrations add Identity --project soilpollution/soilpollution.csproj --startup-project soilpollution/soilpollution.csproj --context SoilDbContext --output-dir Data/Migrations
dotnet ef migrations add Identity --project soilpollution/soilpollution.csproj
```