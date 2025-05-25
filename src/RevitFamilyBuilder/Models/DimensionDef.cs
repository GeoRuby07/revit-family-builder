using Newtonsoft.Json;

namespace RevitFamilyBuilder.Models {
    /// <summary>
    /// Описание размерной привязки между двумя элементами и параметром.
    /// </summary>
    public class DimensionDef {
        [JsonProperty("startReference")]
        public string StartReference { get; set; }

        [JsonProperty("endReference")]
        public string EndReference { get; set; }

        [JsonProperty("parameterName")]
        public string ParameterName { get; set; }

        [JsonProperty("isEqualConstraint")]
        public bool IsEqualConstraint { get; set; }

        public DimensionDef() { }

        public DimensionDef(string startReference, string endReference, string parameterName, bool isEqualConstraint)
        {
            StartReference = startReference;
            EndReference = endReference;
            ParameterName = parameterName;
            IsEqualConstraint = isEqualConstraint;
        }
    }
}
