using Autodesk.Revit.DB;
using Newtonsoft.Json;

namespace RevitFamilyBuilder.Models {
    /// <summary>
    /// Описание опорной плоскости семейства.
    /// </summary>
    public class PlaneDef {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("origin")]
        public XYZ Origin { get; set; }

        [JsonProperty("normal")]
        public XYZ Normal { get; set; }

        // Пустой конструктор для JSON.NET
        public PlaneDef() { }

        public PlaneDef(string name, XYZ origin, XYZ normal)
        {
            Name = name;
            Origin = origin;
            Normal = normal;
        }
    }
}
