namespace Client.Schemas
{
    public class ImageView
    {
   
            public string? FileContents { get; set; }
            public string? ContentType { get; set; }
            public string? FileDownloadName { get; set; }
            public DateTime? LastModified { get; set; }
            public string? EntityTag { get; set; }
            public bool? EnableRangeProcessing { get; set; }
     }
    
}
