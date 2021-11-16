using System;

namespace WebApplicationNew.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
        public ErrorViewModel(string message)
        {
            RequestId = message;
        }
    }
}
