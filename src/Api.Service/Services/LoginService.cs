using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using Api.Domain.DTO;
using Api.Domain.Interfaces.Services;
using Api.Domain.Repository;
using Api.Domain.Security;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Api.Service.Services
{
    public class LoginService : ILoginService
    {
        private IPessoaRepository _repository;
        private SigningConfigurations _signingConfigurations;
        private TokenConfigurations _tokenConfiguration;
        private IConfiguration _configuration;
        public LoginService(IPessoaRepository repository, 
                            SigningConfigurations signingConfigurations, 
                            TokenConfigurations tokenConfiguration,
                            IConfiguration configuration)
        {
            _repository = repository;
            _signingConfigurations = signingConfigurations;
            _tokenConfiguration = tokenConfiguration;
            _configuration = configuration;
        }

        public async Task<object> FindByLogin(string email, string senha)
        {
            if(string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(senha))
                return null;

            var baseUser = await _repository.FindByLogin(email, senha);
            if(baseUser == null){
                return new {
                    authenticated = false,
                    message = "Falha ao autenticar."
                };
            } else {
               
                ClaimsIdentity identity = new ClaimsIdentity(
                    new GenericIdentity(baseUser.Login),
                    new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.UniqueName, baseUser.Login),
                    }
                );

                DateTime createDate = DateTime.Now;
                DateTime expirationDate = createDate + TimeSpan.FromSeconds(_tokenConfiguration.Seconds);
                string token = CreateToken(identity,createDate, expirationDate);
                return SucessObject(createDate, expirationDate, token, email);
                
                
                
                
            }
        }
    
        private string CreateToken(ClaimsIdentity identity, DateTime createDate, DateTime expirationDate){
            
            var handler = new JwtSecurityTokenHandler();

            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _tokenConfiguration.Issuer,
                Audience = _tokenConfiguration.Audience,
                SigningCredentials = _signingConfigurations.SigningCredentials,
                Subject = identity,
                NotBefore = createDate,
                Expires = expirationDate
            });

            var token = handler.WriteToken(securityToken);
            return token;
        }

        private object SucessObject(DateTime createDate, DateTime expirationDate, string token, string emailUser){
            return new {
                authenticated = true,
                created = createDate.ToString("yyyy-MM-dd HH:mm:ss"),
                expiration = expirationDate.ToString("yyyy-MM-dd HH:mm:ss"),
                acessToken = token,
                userName = emailUser,
                message = "Usuário logado com sucesso."
            };
        }

    }
}