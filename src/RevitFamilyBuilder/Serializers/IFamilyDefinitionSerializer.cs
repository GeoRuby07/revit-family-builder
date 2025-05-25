using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace RevitFamilyBuilder.Serializers {
    /// <summary>
    /// Сериализует и десериализует описание семейства (FamilyDefinition) в/из внешнего формата.
    /// </summary>
    public interface IFamilyDefinitionSerializer {
        /// <summary>
        /// Читает определение семейства из файла по указанному пути.
        /// </summary>
        /// <param name="path">Путь к JSON-файлу.</param>
        /// <param name="ct">Токен отмены.</param>
        /// <returns>Объект FamilyDefinition.</returns>
        Task<Models.FamilyDefinition> ReadAsync(string path, CancellationToken ct = default);

        /// <summary>
        /// Пишет определение семейства в файл по указанному пути.
        /// </summary>
        /// <param name="def">Объект FamilyDefinition для сохранения.</param>
        /// <param name="path">Путь к JSON-файлу.</param>
        /// <param name="ct">Токен отмены.</param>
        Task WriteAsync(Models.FamilyDefinition def, string path, CancellationToken ct = default);
    }
}