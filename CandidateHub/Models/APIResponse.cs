namespace CandidateHub.Models
{
    public class APIResponse
    {
        public int StatusCode { get; set; }
        public object Data { get; set; }
        public string Message { get; set; }
        public string Status { get; set; }
        public List<string> Errors { get; set; }

        public APIResponse()
        {
            Errors = new List<string>();
        }
    }
}
