﻿using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using DakSite.Data;
using Volo.Abp.DependencyInjection;

namespace DakSite.EntityFrameworkCore;

public class EntityFrameworkCoreDakSiteDbSchemaMigrator
    : IDakSiteDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreDakSiteDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolve the DakSiteDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<DakSiteDbContext>()
            .Database
            .MigrateAsync();
    }
}
