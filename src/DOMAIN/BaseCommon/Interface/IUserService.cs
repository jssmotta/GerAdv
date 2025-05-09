﻿namespace MenphisSI.BaseCommon;

public interface IUserService
{
    Task<AuthenticateResponse?> Authenticate(AuthenticateRequest model, [FromRoute] string uri);
    Task<AuthenticateResponse?> ResetSenha(AuthenticateRequest model, [FromRoute] string uri);
    Task<OperadorResponse?> GetById(int id, [FromRoute] string uri);
    string Reset([FromRoute] string uri);
    Task<bool> SetPassword(int id, string password, [FromRoute] string uri);
    Task<ValidaUsernameResponse?> ValidaUsername(ValidaUsernameRequest model, string uri);
}