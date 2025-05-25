using Newtonsoft.Json;

namespace RevitFamilyBuilder.Models {
    /// <summary>
    /// Описание одной экструзии (профиль + размеры).
    /// </summary>
    public class ExtrusionDef {
        [JsonProperty("planeName")]
        public string PlaneName { get; set; }

        [JsonProperty("width")]
        public double Width { get; set; }

        [JsonProperty("depth")]
        public double Depth { get; set; }

        public ExtrusionDef() { }

        public ExtrusionDef(string planeName, double width, double depth)
        {
            PlaneName = planeName;
            Width = width;
            Depth = depth;
        }
    }
}
