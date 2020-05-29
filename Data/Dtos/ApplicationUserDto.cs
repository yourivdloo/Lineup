using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Dtos
{
    public class ApplicationUserDto : IdentityUser<Guid>
    {
    }
}
