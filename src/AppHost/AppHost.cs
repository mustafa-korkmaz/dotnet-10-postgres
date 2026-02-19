var builder = DistributedApplication.CreateBuilder(args);

var username = builder.AddParameter("username", "db_admin");
var password = builder.AddParameter("password", "db_password");

var postgres = builder.AddPostgres("postgres", username, password)
    .WithEndpoint("tcp", endpoint =>
    {
        endpoint.Port = 5432;
        endpoint.TargetPort = 5432;
    })
    .WithDataVolume(isReadOnly: false, name: "postgres-db-volume");


builder.AddProject<Projects.API>("api")
    .WaitFor(postgres);

await builder.Build().RunAsync();
