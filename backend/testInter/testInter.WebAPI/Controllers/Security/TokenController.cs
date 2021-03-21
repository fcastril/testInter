using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using testInter.Data;
using testInter.Repo.Security;
using testInter.Service;

namespace testInter.WebAPI.Controllers.Security
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IUserService _user;
        private ResponseEntity responseEntity;

        public TokenController(IConfiguration configuration, IUserService user)
        {
            _configuration = configuration;
            _user = user;
        }

        [HttpPost]
        public async Task<IActionResult> Post(ViewModels.LoginViewModel userEntity)
        {
            if (userEntity != null && userEntity.Email != null && userEntity.Password != null)
            {
                User user = _user.GetUser(userEntity.Email, userEntity.Password);

                if (user != null)
                {
                    string secretKey = _configuration.GetValue<string>("SecretKey");
                    byte[] key = Encoding.ASCII.GetBytes(secretKey);

                    Claim[] claims = new[]
                    {
                        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                        new Claim(ClaimTypes.Email, user.Email)
                    };

                    SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(claims),
                        // Nuestro token va a durar un día
                        Expires = DateTime.UtcNow.AddDays(1),
                        // Credenciales para generar el token usando nuestro secretykey y el algoritmo hash 256
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                    };

                    JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
                    SecurityToken createdToken = tokenHandler.CreateToken(tokenDescriptor);

                    TokenResponseEntity tokenResponse = new TokenResponseEntity
                    {
                        token = tokenHandler.WriteToken(createdToken),
                        expires = tokenDescriptor.Expires.Value,
                        login = user.Email,
                        userName = Crypto.Decrypt(user.UserName)
                    };


                    responseEntity = new ResponseEntity()
                    {
                        Response = true,
                        Result = tokenResponse,
                        Message = "OK"
                    };

                    return Ok(responseEntity);
                }
                else
                {
                    responseEntity = new ResponseEntity()
                    {
                        Message = "Invalid credentials"
                    };

                    return Ok(responseEntity);
                }
            }
            else
            {
                responseEntity = new ResponseEntity()
                {
                    Message = $"Other Error in Authentication \n {userEntity.Email}"
                };
                return Ok(responseEntity);
            }
        }
    }
}
