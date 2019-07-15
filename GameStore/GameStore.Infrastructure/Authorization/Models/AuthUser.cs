﻿using Microsoft.AspNetCore.Identity;

namespace GameStore.Infrastructure.Authorization.Models
{
    public class AuthUser : IdentityUser
    {
        public AuthUser()
        {
        }

        public AuthUser(string userName, string userLastName)
        {
            UserName = userName;
            UserLastName = userLastName;
        }

        public AuthUser(string userName, string userLastName, string email)
        {
            UserName = userName;
            UserLastName = userLastName;
            Email = email;
        }

        public string UserLastName { get; set; }
    }
}
