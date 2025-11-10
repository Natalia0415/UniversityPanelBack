using FluentResults;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityBack.Application.Auth;
using UniversityBack.Business.Interfaces;
using UniversityBack.Data.Interfaces;
using UniversityBack.Domain.Entities;

namespace UniversityBack.Business.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IAuthRepository _authRepository;

        public AuthService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IAuthRepository authRepository)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _authRepository = authRepository;
        }

        public async Task<Result<AuthResponseDto>> RegisterAsync(RegisterDto dto)
        {
            var user = new ApplicationUser { UserName = dto.UserName, Email = dto.Email };
            var result = await _authRepository.CreateUserAsync(user, dto.Password);
            if (!result.Succeeded)
            {
                return Result.Fail<AuthResponseDto>($"No se pudo registrar el usuario: {string.Join("; ", result.Errors.Select(e => e.Description))}");

            }
            var Response = new AuthResponseDto
            {
                UserName = user.UserName,
                Expiration = DateTime.UtcNow.AddDays(1),
                Email = user.Email,
            };

            return Result.Ok(Response);
        }
    }
}
