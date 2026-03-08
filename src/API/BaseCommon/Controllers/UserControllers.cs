using API.Resilience;
using MenphisSI.BaseCommon.UserController;

namespace MenphisSI.BaseCommon;

/// <summary>
/// Controller de usuários específico para GerMCRM.
/// Herda do controller base genérico e adiciona dependências específicas da aplicação.
/// </summary>
public partial class UsersController(
    IUserService<OperadorResponse> userService, 
    IConfiguration config,
    IResilienceService resilienceService,
    IUsersMetrics usersMetrics,
    IPasswordValidator passwordValidator) 
    : UsersControllerBase<OperadorResponse>(
        userService, 
        config, 
        resilienceService, 
        usersMetrics,
        passwordValidator)
{
   
}