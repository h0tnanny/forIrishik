using Scalar.AspNetCore;

namespace LearnProjects.Utils;

public static class SwaggerAndScalarConfiguration
{
    public static IServiceCollection AddSwaggerAndScalar(this IServiceCollection services)
    {
        services.AddSwaggerGen();
        services.AddOpenApi();

        return services;
    }

    public static WebApplication UseSwaggerAndScalar(this WebApplication app)
    {
        app.MapOpenApi();
        app.UseSwagger(opt =>
        {
            opt.RouteTemplate = "openapi/{documentName}.json";
        });
        app.MapScalarApiReference(opt =>
        {
            opt.Title = "Test";
            opt.Theme = ScalarTheme.Mars;
            opt.DefaultHttpClient = new KeyValuePair<ScalarTarget, ScalarClient>(ScalarTarget.Http, ScalarClient.Http11);
            opt.BaseServerUrl = "http://localhost:5000";
        });

        return app;
    }
}