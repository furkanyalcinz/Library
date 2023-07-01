using System.Xml.Linq;

namespace Client.Schemas
{
    public class Result<T> where T : class
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public List<T> Data { get; set; }
    }
    public class Result
    {
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
