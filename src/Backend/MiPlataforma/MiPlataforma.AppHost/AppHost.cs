var builder = DistributedApplication.CreateBuilder(args);

var api = builder.AddProject<Projects.MiPlataforma_App_Api>("api");
var bff = builder.AddProject<Projects.MiPlataforma_App_Bff>("bff").WithReference(api);

var frontWorkingDir = Path.Combine(builder.AppHostDirectory, "../../../Frontend/MiPlataforma.Web");

var web = builder
    .AddJavaScriptApp(name: "web", appDirectory: frontWorkingDir)
    .WithRunScript("dev")
    .WithHttpEndpoint(port: 5174, env: "VITE_PORT", isProxied: false, targetPort: 5174)
    .WithReference(bff);

builder.Build().Run();
