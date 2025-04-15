namespace MenphisSI.GerAdv.Interface;
public partial interface IHonorariosDadosContratoService
{
    Task<IEnumerable<HonorariosDadosContratoResponse>> Filter(Filters.FilterHonorariosDadosContrato filter, [FromRoute, Required] string uri = "");
    Task<HonorariosDadosContratoResponse?> AddAndUpdate(Models.HonorariosDadosContrato regHonorariosDadosContrato, [FromRoute, Required] string uri = "");
    Task<HonorariosDadosContratoResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<HonorariosDadosContratoResponse>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<bool> UpdateColumns(UpdateColumnsRequest columns, [FromRoute, Required] string uri = "");
    Task<GetColumnsResponse?> GetColumns(GetColumns parameters, [FromRoute, Required] string uri = "");
    Task<HonorariosDadosContratoResponse?> Delete(int id, [FromRoute, Required] string uri = "");
}