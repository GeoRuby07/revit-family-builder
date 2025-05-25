using System.Collections.Generic;
using Newtonsoft.Json;

namespace RevitFamilyBuilder.Models {
    /// <summary>
    /// Корневой класс, описывающий все элементы семейства для сериализации.
    /// </summary>
    public class FamilyDefinition {
        [JsonProperty("planes")]
        public List<PlaneDef> Planes { get; set; } = new List<PlaneDef>();

        [JsonProperty("parameters")]
        public List<ParameterDef> Parameters { get; set; } = new List<ParameterDef>();

        [JsonProperty("extrusions")]
        public List<ExtrusionDef> Extrusions { get; set; } = new List<ExtrusionDef>();

        [JsonProperty("dimensions")]
        public List<DimensionDef> Dimensions { get; set; } = new List<DimensionDef>();

        public FamilyDefinition() { }
    }
}
