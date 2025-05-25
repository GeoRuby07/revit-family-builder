using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using Autodesk.Revit.DB;

namespace RevitFamilyBuilder.Services {
    /// <summary>
    /// Создаёт Revit-семейство на основе десериализованного описания FamilyDefinition.
    /// </summary>
    public interface IFamilyBuilderService {
        /// <summary>
        /// Построить новое семейство в Revit и вернуть документ.
        /// </summary>
        /// <param name="definition">Описание семейства.</param>
        /// <param name="ct">Токен отмены.</param>
        /// <returns>Документ семейства (RFA) в памяти.</returns>
        Task<Document> BuildAsync(Models.FamilyDefinition definition, CancellationToken ct = default);
    }
}