using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using Mindscape.Raygun4Net.AspNetCore;
using Mindscape.Raygun4Net.Extensions.Logging;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRaygun(builder.Configuration);

builder.Logging.AddRaygunLogger(builder.Configuration, options =>
{
    options.MinimumLogLevel = LogLevel.Debug;
    options.OnlyLogExceptions = false;
});

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/throw", (Func<string>)(() => throw new Exception("Exception in request pipeline")));

app.MapGet("/logger", (Func<string>)(() =>
{
    // Use the app provided logger
    var logger = app.Logger;
    logger.BeginScope(new Dictionary<string, object?> { { "NullKey", null } });
    logger.LogError("I am an error with implicit contextual logging informations, e.g. NullKey");
    return "Logged a message";
}));

app.UseRaygun();

app.Run();
