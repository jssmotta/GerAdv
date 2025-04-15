#pragma warning disable IDE0130 // Namespace does not match folder structure


namespace MenphisSI.GerAdv.Services;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial class AgendaRelatorioService
{
    public Task<AgendaRelatorioResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default)
    {
        throw new NotImplementedException();
    }
}
