using CleanArchitecture.Core.DTOs.Account;
using CleanArchitecture.Core.Interfaces.Repositories;
using CleanArchitecture.Core.Settings;
using CleanArchitecture.Core.Wrappers;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Core.Features.User.Commands.UserAuthentication
{
    public class UserAuthenticationCommand : IRequest<Response<AuthenticationResponse>>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
    public class UserAuthenticationCommandHandler : IRequestHandler<UserAuthenticationCommand, Response<AuthenticationResponse>>
    {
        private readonly IUserRepositoryAsync _userRepositoryAsync;
        private readonly IConfiguration configuration;
        public UserAuthenticationCommandHandler(IUserRepositoryAsync userRepositoryAsync, IConfiguration configuration)
        {
            _userRepositoryAsync = userRepositoryAsync;
            this.configuration = configuration;
        }
        public async Task<Response<AuthenticationResponse>> Handle(UserAuthenticationCommand request, CancellationToken cancellationToken)
        {
            Entities.User user =await _userRepositoryAsync.GetByUsernameAsync(request.Username);
            if(user == null)
            {
                return new Response<AuthenticationResponse>(
                    message: $"No user found matching the username {request.Username}");
            }else if(user.Password != request.Password ) {
                return new Response<AuthenticationResponse>(
                    message: $"The password is incorrect");
            }
            else
            {
                List<Claim> claims = new() { new Claim(ClaimTypes.Name,user.Username)};
                var key = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(configuration.GetSection("JWTSettings:Key").Value!));
                var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
                var token = new JwtSecurityToken(
                    claims:claims,
                    signingCredentials:credentials,
                    expires:DateTime.Now.AddHours(1)
                    );
                    
                var jwt = new JwtSecurityTokenHandler().WriteToken(token);
                var response = new AuthenticationResponse() {
                    Id = user.Id,
                    Email = user.Email,
                    UserName = user.Email, 
                    IsVerified = true,
                    JWToken = jwt };

                return new Response<AuthenticationResponse>(response,message:"authenticated");

            }
        }
    }
}
