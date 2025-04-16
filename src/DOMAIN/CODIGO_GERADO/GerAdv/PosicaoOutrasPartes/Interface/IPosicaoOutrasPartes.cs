namespace MenphisSI.GerAdv.Interface;
public partial interface IPosicaoOutrasPartesService
{
    Task<IEnumerable<PosicaoOutrasPartesResponse>> Filter(Filters.FilterPosicaoOutrasPartes filter, [FromRoute, Required] string uri = "");
    Task<PosicaoOutrasPartesResponse?> AddAndUpdate(Models.PosicaoOutrasPartes regPosicaoOutrasPartes, [FromRoute, Required] string uri = "");
    Task<PosicaoOutrasPartesResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<PosicaoOutrasPartesResponse>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<bool> UpdateColumns(UpdateColumnsRequest columns, [FromRoute, Required] string uri = "");
    Task<GetColumnsResponse?> GetColumns(GetColumns parameters, [FromRoute, Required] string uri = "");
    Task<PosicaoOutrasPartesResponse?> Delete(int id, [FromRoute, Required] string uri = "");
    Task<PosicaoOutrasPartesResponse?> GetByName(string name, [FromRoute, Required] string uri = "");
    Task<IEnumerable<NomeID>> GetListN([FromQuery] int max, [FromBody] Filters.FilterPosicaoOutrasPartes? filter, [FromRoute, Required] string uri = "", CancellationToken token = default);
}