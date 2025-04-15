namespace MenphisSI.GerMDS.Interface;
public partial interface IClientesService
{
    Task<IEnumerable<ClientesResponse>> Pesquisa(string texto, string uri);
    Task<ClientesResponse?> GetByNomeSobrenome(string name, string uri);
   // Task<IEnumerable<LeaoResponse>?>? Leao(string data, string dataFinal, bool comRecibo, string uri);

}