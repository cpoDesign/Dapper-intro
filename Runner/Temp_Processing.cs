using System;

namespace Runner
{
    public class Temp_Processing
    {
        public Guid Id { get; set; }
        public int Type { get; set; }
        public string Message { get; set; }
        public int Status { get; set; }
        public string Errors { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Completed { get; set; }
        public Boolean Processed { get; set; }
    }
}
