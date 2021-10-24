using System;

namespace Application.DTOs.Users
{
    public class RefreshToken
    {
        public string Token { get; set; }
        public DateTime Created { get; set; }
        public DateTime Expires { get; set; }
        public string CreatedByIp { get; set; }
        public DateTime? Revoked { get; set; }

        public bool IsExpired => DateTime.Now >= Expires;
    }
}
