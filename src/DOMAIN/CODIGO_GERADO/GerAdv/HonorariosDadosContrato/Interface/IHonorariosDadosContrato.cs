namespace MenphisSI.GerAdv.Interface;
public partial interface IHonorariosDadosContratoService
{
    Task<IEnumerable<HonorariosDadosContratoResponseAll>> Filter(Filters.FilterHonorariosDadosContrato filter, [FromRoute, Required] string uri = "");
    Task<HonorariosDadosContratoResponse?> AddAndUpdate(Models.HonorariosDadosContrato regHonorariosDadosContrato, [FromRoute, Required] string uri = "");
    Task<HonorariosDadosContratoResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<HonorariosDadosContratoResponseAll>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<HonorariosDadosContratoResponse?> Delete(int id, [FromRoute, Required] string uri = "");
}