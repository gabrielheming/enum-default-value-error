# Enum with default value

Repository created to demonstrate the [issue #2392](https://github.com/npgsql/efcore.pg/issues/2392)

Requirements:
 * PostgreSQL database
 * .NET Core 6


Version used to test:

 * Latest version of .NET Core >= 6.0.3 (SDK 6.0.300): link to download: https://dotnet.microsoft.com/download/dotnet/5.0
 * PostgreSQL 11

 # How to proceed

 After cloning the repository, run the following commands using `dotnet cli`:

 ```
 $ dotnet restore
 $ dotnet build
 ```

 It is necessary to configure the database connection using the appsettings.json
`WepApp\appsettings.json`
 ```
  "ConnectionStrings": {
    "DefaultConnection": "Server=database;Port=5432;Database=enum-error;Ssl Mode=Prefer"
  },
  "Connection": {
    "DefaultConnection": {
      "UserId": "user",
      "Password": "password"
    }
  },
 ```

 After properly configured, run the migration:

 dotnet cli with `dotnet-ef` 6.0.5
 ```
 $ dotnet ef database update --project WebApp/
 ```

 PowerShell:
 ```
 Update-Database -StartUpProjectName WebApp/WebApp.csproj
 ```

Testing:

 Go to EnumResetTest project and run the tests.

 * NpgsqlEnumResetTest: Runs against a PostgreSQL database, shows the odd behaviour
 * InMemoryEnumRestTest: Runs against an InMemory database, works fine
