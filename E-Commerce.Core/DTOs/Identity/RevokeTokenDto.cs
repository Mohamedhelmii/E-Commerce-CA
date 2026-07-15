using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core.DTOs.Identity
{
    public class RevokeTokenDto
    {
        // net required to make it avaliable to sent with cookies not only in body
        public string? Token { get; set; }
    }
}
