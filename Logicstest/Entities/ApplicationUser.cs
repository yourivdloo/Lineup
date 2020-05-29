using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Logics.Entities
{
    public class ApplicationUser
    {
        public Guid Id { get; set; }

        public string UserName { get; set; }

        [EmailAddress]
        public string Email { get; set; }
    }
}
