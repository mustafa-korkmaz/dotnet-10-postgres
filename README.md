# Local setup
## Dependencies
 - PostgreSQL database

All dependencies are configured via Aspire orchestration.

## Build docker image
cd to the root folder
```bash
docker build -t app-image:v1 -f .\src\API\Dockerfile .
docker run --name my-container -d -p 8000:80 -e ASPNETCORE_HTTP_PORTS=80 app-image:v1
```

## Database Migrations
Use dotnet ef tools to add a new migration
```bash
dotnet ef migrations add AwesomeMigration --project src/Infrastructure --startup-project src/API --output-dir Persistence/Migrations
```
Aspire configuration has a volume called `postgres-db-volume` for persisting database changes. To apply them locally, use the following steps:
```bash
# Start Aspire services in release mode
dotnet run --configuration Release --project .\src\AppHost

# Open a new terminal and run the database update command
dotnet ef database update --project src/Infrastructure --startup-project src/API
```