﻿using Microsoft.AspNetCore.Identity;

namespace DemoAttendenceFeature.Infrastructure.Interface
{
    public interface ITokenRepository
    {
        string CreateToken(IdentityUser user, List<string> roles);
    }
}
