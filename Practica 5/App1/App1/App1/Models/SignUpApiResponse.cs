using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace App1.Models
{
    class SignUpApiResponse
    {
        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("data")]
        public User User { get; set; }
        
        [JsonPropertyName("errorMessage")]
        public string ErrorMessage { get; set; }
    }
}
