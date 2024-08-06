namespace ExampleB2C.Models
{
    public class DocumentMetaData
    {
        public int MetadataId { get; set; }
        public int DocumentId { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }

        public Document Document { get; set; }

    }
}
