using Infrastructure.Contexts;
using Infrastructure.GraphQL;
using Infrastructure.GraphQL.Mutations;
using Infrastructure.GraphQL.ObjectTypes;
using Microsoft.Azure.Functions.Worker;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Configuration;
using WebApi.Interfaces;

var host = new HostBuilder()
    .ConfigureFunctionsWebApplication()
    .ConfigureAppConfiguration((context, configBuilder) =>
{
var env = context.HostingEnvironment.EnvironmentName;
configBuilder.AddJsonFile("local.settings.json", optional: true, reloadOnChange: true)
             .AddEnvironmentVariables();
})
    .ConfigureServices((context, services) =>
    {
        var configuration = context.Configuration;

        services.AddApplicationInsightsTelemetryWorkerService();
        services.ConfigureFunctionsApplicationInsights();
        services.AddTransient<ICourseService, CourseService>();

        services.AddDbContextFactory<ApplicationDbContext>(options =>
        {
            var connectionString = configuration["Values:DefaultConnection"];
            options.UseSqlServer(connectionString)
                   .UseLazyLoadingProxies();
        });




        services.AddGraphQLFunction()
                .AddQueryType<CourseQuery>()
                .AddType<CourseType>()
                .AddMutationType<CourseMutation>();

    })
    .Build();

host.Run();
