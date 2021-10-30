using Application.Interfaces;
using System;

namespace Shared.Services
{
    public class UtilityService : IUtilityService
    {
        public DateTime NowUtc => DateTime.UtcNow;
    }
}
