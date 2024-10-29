using ExternalLibrary;

namespace GeneratedClasses
{
    public class SRURepairMethods
    {
        [MapFrom(typeof(ExternalClass1), "arasProp1")]
        public string? SruId { get; set; }

        [MapFrom(typeof(ExternalClass1), "arasProp2")]
        public string? SruName { get; set; }

        [MapFrom(typeof(ExternalClass2), "arasProp1")]
        public string? ResourceId { get; set; }

        [MapFrom(typeof(ExternalClass2), "arasProp2")]
        public string? ResourceName { get; set; }

        [MapFrom(typeof(ExternalClass2), "arasProp3")]
        public string? ResourceUtilizationTime { get; set; }
    }
}
