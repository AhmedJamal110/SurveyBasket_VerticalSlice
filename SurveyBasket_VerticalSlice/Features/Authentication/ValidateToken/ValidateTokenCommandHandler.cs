
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Diagnostics;

namespace SurveyBasket_VerticalSlice.Features.Authentication.ValidateToken
{
    public class ValidateTokenCommandHandler : BaseRequestHandler<ValidateTokenCommand, string?>
    {
        private readonly JwtOptions _options;
        private readonly ILogger<ValidateTokenCommandHandler> _logger;

        public ValidateTokenCommandHandler(RequestParameters parameters 
            , IOptions<JwtOptions> options , ILogger<ValidateTokenCommandHandler> logger) : base(parameters)
        {
            _options = options.Value;
            _logger = logger;
        }

        public override  Task<string?> Handle(ValidateTokenCommand request, CancellationToken cancellationToken)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.Key));
            try
            {
                 tokenHandler.ValidateToken(request.Token, new TokenValidationParameters
                {
                    ValidateAudience = true,
                    ValidateIssuer = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = key,
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validateToken);

                var jwtToken = (JwtSecurityToken)validateToken;

                var userId= jwtToken.Claims.FirstOrDefault(claim => claim.Type == JwtRegisteredClaimNames.Sub).Value;
                
                return Task.FromResult(!string.IsNullOrEmpty(userId) ? userId : string.Empty);


            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error Valide Token message{Message} on machine:{Machine} with TraceId : {TraceId}",
                    ex.Message
                   , Environment.MachineName
                   , Activity.Current?.TraceId);

                return Task.FromResult(string.Empty);
            }

        } 
    }
}
