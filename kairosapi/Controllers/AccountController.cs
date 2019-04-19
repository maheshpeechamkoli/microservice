using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon;
using Amazon.CognitoIdentityProvider;
using Amazon.CognitoIdentityProvider.Model;
using kairosapi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace kairosapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private const string _clientId = "41emtvd3i56r64r5sg95c211e5";
        private readonly RegionEndpoint _region = RegionEndpoint.USEast1;

        [HttpPost("register")]
        public async Task<ActionResult<string>> Register(User user)
        {
            var cognito = new AmazonCognitoIdentityProviderClient(_region);

            var request = new SignUpRequest
            {
                ClientId = _clientId,
                Password = user.Password,
                Username = user.Username
            };

            var emailAttribute = new AttributeType
            {
                Name = "email",
                Value = user.Email
            };
            request.UserAttributes.Add(emailAttribute);

            var response = await cognito.SignUpAsync(request);

            return Ok();
        }

        [HttpPost("signin")]
        public async Task<ActionResult<string>> SignIn(User user)
        {
            var cognito = new AmazonCognitoIdentityProviderClient(_region);

            var request = new AdminInitiateAuthRequest
            {
                UserPoolId = "us-east-1_YoiGbLcnw",
                ClientId = _clientId,
                AuthFlow = AuthFlowType.ADMIN_NO_SRP_AUTH
            };

            request.AuthParameters.Add("USERNAME", user.Username);
            request.AuthParameters.Add("PASSWORD", user.Password);

            var response = await cognito.AdminInitiateAuthAsync(request);

            return Ok(response.AuthenticationResult.IdToken);
        }

    }
}