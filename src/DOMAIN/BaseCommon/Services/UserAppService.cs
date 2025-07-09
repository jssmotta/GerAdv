using IdentityModel.Client;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
namespace MenphisSI.BaseCommon;

public partial class UserService : IUserService, IDisposable
{


    private async Task<string> GenerateJwtToken(OperadorResponse user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_appSettings.Value.Secret);

        var claims = new[]
        {
            new Claim("id", user.Id.ToString()),
            new Claim("tipo", user.CadID == 1 ? "Advogado" : "Funcionario"),
        };

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddDays(7),
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
        };

        var token = await Task.Run(() => tokenHandler.CreateToken(tokenDescriptor))
            .ConfigureAwait(false);

        return tokenHandler.WriteToken(token);
    }

    public async Task<AuthenticateResponse?> Authenticate3(AuthenticateRequest model, string uri)
    {
        return await ExecuteWithMetrics("Authenticate", async () =>
        {
            ArgumentNullException.ThrowIfNull(model);
            if (string.IsNullOrEmpty(uri)) throw new ArgumentNullException(nameof(uri));

           if (!Uris.ValidaUri(uri, _appSettings))
            {
                _logger.Warn("Authenticate: URI não é valida {Uri}", uri);
                throw new Exception("User: URI inválida");
            }

            using var scope = Configuracoes.CreateConnectionScope(uri);
            var oCnn = scope.Connection;
            if (oCnn == null)
            {
                _logger.Warn("Authenticate: Conexão nula");
                return null;
            }

            var user = await AuthenticateUserAsync(model, oCnn).ConfigureAwait(false);
            if (user == null) return null;

            try
            {
                var parameters = new List<SqlParameter>
                {
                    new SqlParameter("@email", user.EMailNet),                    
                };
                var dbMed = new DBAdvogados(
                                    parameters,
                                    sqlWhere: DBAdvogadosDicInfo.EMail + " = @email",
                                    oCnn: oCnn);

                var tipo = dbMed.ID == 0 ? "Funcionario" : "Medico";
#if (DEBUG)
                tipo = "Medico";
#endif

                var token = await GenerateJwtToken(user).ConfigureAwait(false);
                var token64 = Convert.ToBase64String(Encoding.ASCII.GetBytes(token));

                return new AuthenticateResponse(user, token64, tipo, uri);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Authenticate: Erro ao gerar token");
                return null;
            }
        });
    }


}