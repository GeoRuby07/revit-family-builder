using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RevitFamilyBuilder.Models;

namespace RevitFamilyBuilder.Serializers {
    /// <summary>
    /// Читает и пишет FamilyDefinition в JSON-файл.
    /// </summary>
    public class JsonFamilyDefinitionSerializer : IFamilyDefinitionSerializer {
        private readonly ILogger<JsonFamilyDefinitionSerializer> _logger;

        public JsonFamilyDefinitionSerializer(ILogger<JsonFamilyDefinitionSerializer> logger)
        {
            _logger = logger;
        }

        public async Task<FamilyDefinition> ReadAsync(string path, CancellationToken ct = default)
        {
            _logger.LogInformation("Reading family definition from {Path}", path);

            if (!File.Exists(path))
            {
                _logger.LogError("File not found: {Path}", path);
                throw new FileNotFoundException($"Definition file not found: {path}");
            }

            // Открываем асинхронно для чтения
            using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read, bufferSize: 4096, useAsync: true))
            using (var reader = new StreamReader(fs))
            {
                // Асинхронно читаем всё
                string json = await reader.ReadToEndAsync().ConfigureAwait(false);

                var def = JsonConvert.DeserializeObject<FamilyDefinition>(json);
                if (def == null)
                {
                    _logger.LogError("Failed to deserialize FamilyDefinition from {Path}", path);
                    throw new JsonException($"Unable to deserialize FamilyDefinition from {path}");
                }

                _logger.LogInformation("Successfully read FamilyDefinition ({PlaneCount} planes, {ParamCount} parameters)",
                    def.Planes.Count, def.Parameters.Count);

                return def;
            }
        }

        public async Task WriteAsync(FamilyDefinition def, string path, CancellationToken ct = default)
        {
            _logger.LogInformation("Writing family definition to {Path}", path);

            // Сериализуем с отступами
            string json = JsonConvert.SerializeObject(def, Formatting.Indented);

            // Убедимся, что каталог существует
            string directory = Path.GetDirectoryName(path);
            if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
                _logger.LogInformation("Created directory {Directory}", directory);
            }

            // Открываем асинхронно для записи
            using (var fs = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None, bufferSize: 4096, useAsync: true))
            using (var writer = new StreamWriter(fs))
            {
                // Асинхронно пишем
                await writer.WriteAsync(json).ConfigureAwait(false);
            }

            _logger.LogInformation("Successfully wrote FamilyDefinition ({PlaneCount} planes, {ParamCount} parameters) to {Path}",
                def.Planes.Count, def.Parameters.Count, path);
        }
    }
}
