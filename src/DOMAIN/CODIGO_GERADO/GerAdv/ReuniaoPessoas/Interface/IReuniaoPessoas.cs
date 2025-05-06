namespace MenphisSI.GerAdv.Interface;
public partial interface IReuniaoPessoasService
{
    Task<IEnumerable<ReuniaoPessoasResponse>> Filter(Filters.FilterReuniaoPessoas filter, [FromRoute, Required] string uri = "");
    Task<ReuniaoPessoasResponse?> AddAndUpdate(Models.ReuniaoPessoas regReuniaoPessoas, [FromRoute, Required] string uri = "");
    Task<ReuniaoPessoasResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<ReuniaoPessoasResponse>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<ReuniaoPessoasResponse?> Delete(int id, [FromRoute, Required] string uri = "");
}