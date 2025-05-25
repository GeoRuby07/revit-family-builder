using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RevitFamilyBuilder.Serializers;
using Microsoft.Extensions.Logging.Debug;
using RevitFamilyBuilder.Services;

namespace RevitFamilyBuilder.DI {
    /// <summary>
    /// Строит IServiceProvider с регистрацией всех сервисов приложения.
    /// </summary>
    public static class ServiceCollectionBuilder {
        public static IServiceProvider BuildServiceProvider()
        {
            var services = new ServiceCollection();

            // Логирование (в Revit логируется в Output window)
            services.AddLogging(cfg =>
            {
                cfg.AddDebug();
                cfg.SetMinimumLevel(LogLevel.Information);
            });

            // Регистрация сериализатора JSON
            services.AddSingleton<IFamilyDefinitionSerializer, JsonFamilyDefinitionSerializer>();

            //services.AddTransient<IFamilyBuilderService, RevitFamilyBuilderService>();

            return services.BuildServiceProvider();
        }
    }
}
