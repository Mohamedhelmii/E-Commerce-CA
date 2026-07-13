using E_Commerce.Core.Entities.OrderAggregate;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core.Entities.Identity
{
    public class Appuser : IdentityUser
    {
        public string Name { get; set; }

        public Adress adress { get; set; }

        public List<RefreshToken>? RefreshTokens { get; set; }

        public DateTime? RefreshTokenExpiration { get; set; }

    }
}