namespace MenphisSI.GerAdv.Interface;
public partial interface IPosicaoOutrasPartesService
{
    Task<IEnumerable<PosicaoOutrasPartesResponseAll>> Filter(Filters.FilterPosicaoOutrasPartes filter, [FromRoute, Required] string uri = "");
    Task<PosicaoOutrasPartesResponse?> AddAndUpdate(Models.PosicaoOutrasPartes regPosicaoOutrasPartes, [FromRoute, Required] string uri = "");
    Task<PosicaoOutrasPartesResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<PosicaoOutrasPartesResponse?> Delete(int id, [FromRoute, Required] string uri = "");
    Task<PosicaoOutrasPartesResponse?> Validation(Models.PosicaoOutrasPartes regPosicaoOutrasPartes, [FromRoute, Required] string uri = "");
    Task<IEnumerable<PosicaoOutrasPartesResponseAll>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<NomeID>> GetListN([FromQuery] int max, [FromBody] Filters.FilterPosicaoOutrasPartes? filter, [FromRoute, Required] string uri = "", CancellationToken token = default);
}