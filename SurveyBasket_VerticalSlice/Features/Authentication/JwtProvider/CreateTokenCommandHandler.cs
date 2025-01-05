
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SurveyBasket_VerticalSlice.Features.Authentication.JwtProvider
{
    public class CreateTokenCommandHandler : BaseRequestHandler<CreateTokenCommand, (string token, int expireIn)>
    {
        private readonly JwtOptions _options;

        public CreateTokenCommandHandler(RequestParameters parameters , IOptions<JwtOptions> options) : base(parameters)
        {
            _options = options.Value;
        }

        public override  Task<(string token, int expireIn)> Handle(CreateTokenCommand request, CancellationToken cancellationToken)
        {
            Claim[] claims =
                [
                    new (JwtRegisteredClaimNames.Sub , request.user.Id),
                    new (JwtRegisteredClaimNames.Email , request.user.Email!),
                    new (JwtRegisteredClaimNames.GivenName , request.user.FirstName),
                    new (JwtRegisteredClaimNames.FamilyName , request.user.LastName),
                    new (JwtRegisteredClaimNames.Jti , request.user.Id),
                    new (JwtRegisteredClaimNames.Sub , Guid.NewGuid().ToString()),
               ];


            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.Key));
            var singingCredential = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken
                (
                    issuer: _options.ValidIssuer, 
                    audience: _options.ValidAudiance,
                    claims: claims,
                    expires: DateTime.UtcNow.AddMinutes( _options.ExpireMinutes),
                    signingCredentials: singingCredential
                );

            return Task.FromResult((token: new JwtSecurityTokenHandler().WriteToken(token), expireIn: _options.ExpireMinutes * 60));
        }
    }
}
