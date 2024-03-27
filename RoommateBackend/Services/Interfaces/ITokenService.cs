using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RoommateBackend.Models;

namespace RoommateBackend.Services.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(AppUser user);
    }
}