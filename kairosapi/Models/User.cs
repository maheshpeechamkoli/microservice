using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon;
using Amazon.CognitoIdentityProvider;
using Amazon.CognitoIdentityProvider.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace kairosapi.Models
{       public class User
        {
            public string Username { get; set; }
            public string Password { get; set; }
            public string Email { get; set; }
        }
}