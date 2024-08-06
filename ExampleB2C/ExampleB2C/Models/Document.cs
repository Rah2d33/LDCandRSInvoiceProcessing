namespace ExampleB2C.Models
{
    public class Document
    {
        public int DocumentId { get; set; }
        public int UserId { get; set; }
        public string BlobStorageUrl { get; set; }
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public long FileSize { get; set; }
        public DateTime UploadDate { get; set; }

        public User User { get; set; }
        public ICollection<DocumentMetaData> Metadata { get; set; }
    }
}
