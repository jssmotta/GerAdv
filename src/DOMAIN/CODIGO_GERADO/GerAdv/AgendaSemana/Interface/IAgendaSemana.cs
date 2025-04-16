#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Interface;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IAgendaSemanaService
{
    Task<AgendaSemanaResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
}