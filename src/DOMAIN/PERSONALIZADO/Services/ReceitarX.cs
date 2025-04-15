namespace MenphisSI.GerMDS.Interface
{
    public partial interface IReceitasXService
    {
        Task<IEnumerable<ReceitasXResponse>> Filter(Filters.FilterReceitasX filtro, [FromRoute, Required] string uri);

    }
}
namespace MenphisSI.GerMDS.Services
{
    public partial class ReceitasXService
    {

        public async Task<IEnumerable<ReceitasXResponse>> Filter(Filters.FilterReceitasX filtro, [FromRoute, Required] string uri)
        {
            if (!Uris.ValidaUri(uri, _uris))
            {
                throw new Exception("ReceitasX: URI inválida");
            }

            if (filtro.Operator.IsEmpty() || (filtro.Operator.NotEquals(TSql.And) && filtro.Operator.NotEquals(TSql.OR)))
            {
                filtro.Operator = TSql.And;
            }

            return await Task.Run(() =>
            {
                using var scope = Configuracoes.CreateConnectionScope(uri);
                var oCnn = scope.Connection;
                if (oCnn == null)
                {
                    return [];
                }

                var result = new List<ReceitasXResponse>();
                var cWhere = filtro.Cliente == -2147483648 ? string.Empty : DBReceitasXDicInfo.ClienteSql(filtro.Cliente);
                cWhere += filtro.Nome.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBReceitasXDicInfo.NomeSql(filtro.Nome);
                cWhere += filtro.ReceitaJson.IsEmpty() ? string.Empty : (cWhere.Length == 0 ? string.Empty : filtro.Operator) + DBReceitasXDicInfo.ReceitaJsonSql(filtro.ReceitaJson);

                var list = DBReceitasX.ListarX("", cWhere, "", Configuracoes.ConnectionByUri(uri));
                if (list != null)
                {
                    foreach (var item in list)
                        result.Add(reader.Read(item)!);
                }

                return result;
            });
        }

    }
}