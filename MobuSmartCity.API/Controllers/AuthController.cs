using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MobuSmartCity.API.Data;
using MobuSmartCity.API.Models;
using MobuSmartCity.API.Models.DTOs;

namespace MobuSmartCity.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Auth")]
    public class AuthController : Controller
    {
        private IAuthRepository _authRepository;
        private IConfiguration _configuration;
        private IAppRepository _appRepository;
        public AuthController(IAppRepository appRepository, IAuthRepository authRepository, IConfiguration configuration)
        {
            _appRepository = appRepository;
            _authRepository = authRepository;
            _configuration = configuration;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]UserForRegisterDto userForRegisterDto)
        {
            if (await _authRepository.UserExist(userForRegisterDto.UserName))
            {
                ModelState.AddModelError("UserName", "Username already exist");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            int cityId = _appRepository.GetCities().Where(s => s.Name == userForRegisterDto.CityName).FirstOrDefault().Id;
            var userRegister = new User
            {
                UserName = userForRegisterDto.UserName,
                Ad = userForRegisterDto.Ad,
                Soyad = userForRegisterDto.Soyad,
                Birthday = userForRegisterDto.Birthday,
                CityId = cityId,
                IsAuthorized = false
            };
            var createdUser = await _authRepository.Register(userRegister, userForRegisterDto.Password);
            return StatusCode(201);
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]UserforLoginDto userforLoginDto)
        {
            var user = await _authRepository.Login(userforLoginDto.UserName, userforLoginDto.Password);

            if (user == null)
            {
                return Unauthorized();
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration.GetSection("AppSettings:Token").Value);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.Role,user.IsAuthorized.ToString())
                }),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key)
                    , SecurityAlgorithms.HmacSha512Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return Ok(tokenString);

        }
    }
}