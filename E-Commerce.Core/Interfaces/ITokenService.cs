﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using E_Commerce.Core.Entities.Identity;

namespace E_Commerce.Core
{
    public interface ITokenService
    {

        Task<string> CreateTokenAsync(Appuser user, UserManager<Appuser> userManager);
    }
}