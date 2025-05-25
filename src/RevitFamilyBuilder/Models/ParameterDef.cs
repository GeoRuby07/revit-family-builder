using Newtonsoft.Json;

namespace RevitFamilyBuilder.Models {
    /// <summary>
    /// Описание семейного параметра (модель-DTO).
    /// </summary>
    public class ParameterDef {
        /// <summary>Имя параметра в семействе.</summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>Тип параметра как строка, например "Length" или "Integer".</summary>
        [JsonProperty("typeName")]
        public string TypeName { get; set; }

        /// <summary>True, если Instance-параметр; false — Family.</summary>
        [JsonProperty("isInstance")]
        public bool IsInstance { get; set; }

        /// <summary>Значение по умолчанию (в единицах Revit, например в футах).</summary>
        [JsonProperty("defaultValue")]
        public double DefaultValue { get; set; }

        // Пустой конструктор для JSON.NET
        public ParameterDef() { }

        public ParameterDef(string name, string typeName, bool isInstance, double defaultValue)
        {
            Name = name;
            TypeName = typeName;
            IsInstance = isInstance;
            DefaultValue = defaultValue;
        }
    }
}
