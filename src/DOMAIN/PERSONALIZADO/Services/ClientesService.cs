using MenphisSI.DB;
using System.Runtime.ConstrainedExecution;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MenphisSI.GerMDS.Services;
public partial class ClientesService
{
    //public async Task<IEnumerable<LeaoResponse>?> Leao(string data, string dataFinal, bool comRecibo, string uri)
    //{
    //    using var scope = Configuracoes.CreateConnectionScope(uri);
    //    var oCnn = scope.Connection;
    //    if (oCnn == null)
    //    {
    //        return null;
    //    }
    //    string cWhere = " WHERE " + (comRecibo ? " ageRecibo=1 and " : "") + DBClientesDicInfo.CPFSqlNotIsNull;

    //    if (DateTime.TryParse(data, out var dia))
    //    {
    //        cWhere += TSql.And +
    //            $"MONTH({DBAgendaDicInfo.Data}) = {dia.Month}" + TSql.And + 
    //            $"YEAR({DBAgendaDicInfo.Data})  = {dia.Year}";
    //    }

    //    string cSQL = $"select distinct Agenda.ageCodigo as ID, Clientes.cliNome + ' ' +  Clientes.cliSobreNome as [NomePaciente], Clientes.cliCPF as CPF, agenda.ageData as Data, agenda.ageRecibo as [TemRecibo], Clientes.cliRG as [RG] from Agenda join Clientes on Agenda.ageCliente=Clientes.cliCodigo {cWhere} order by ageRecibo, ageData";
    //    var db = await ConfiguracoesDBT.GetDataTable2Async(cSQL, oCnn);
    //    var result = new List<LeaoResponse>();
    //    foreach (DataRow item in db!.Rows)
    //    {
    //        result.Add(new LeaoResponse()
    //        {
    //            ID = item.Field<int>("ID"),
    //            NomePaciente = item.Field<string>("NomePaciente") ?? "",
    //            CPF = item.Field<string>("CPF") ?? "",
    //            Data = item.Field<DateTime?>("Data")?.ToString("dd/MM/yyyy") ?? "",
    //            TemRecibo = item.Field<bool>("TemRecibo") ? "SIM": "NÃO",
    //            RG = item.Field<string>("RG") ?? ""
    //        });
    //    }
    //    return result;
    //}

    public async Task<ClientesResponse?> GetByNomeSobrenome([FromQuery] string name, [FromRoute] string uri) => await Task.Run(() =>
    {
        using var scope = Configuracoes.CreateConnectionScope(uri);
        var oCnn = scope.Connection;
        if (oCnn == null)
        {
            return null;
        }
        
        var result = reader.ReadNome(name, oCnn);
        return result ?? new ClientesResponse();
    });

    public async Task<IEnumerable<ClientesResponse>> Pesquisa(string texto, string uri)
    {
        return await Task.Run(async () =>
    {

        using var scope = Configuracoes.CreateConnectionScope(uri);
        var oCnn = scope.Connection;
        if (oCnn == null)
        {
            return [];
        }

        var cWhere = $"{DBClientesDicInfo.CidadeSqlLike(texto)} OR {DBClientesDicInfo.FoneSqlLikeSpaces(texto)}";

        foreach (var item in texto.Split(' '))
        {

            if (item.Length < 3)
                continue;
            cWhere += TSql.OR + DBClientesDicInfo.NomeSqlLikeSpaces(item) +

                      TSql.OR + DBClientesDicInfo.SobrenomeSqlLikeSpaces(item);
        }
        if (DateTime.TryParse(texto, out var dtNasc))
        {
            cWhere = DBClientesDicInfo.DtNascSqlIgual(dtNasc);
        }
        else if (int.TryParse(texto, out var prontuario))
        {
            cWhere = DBClientesDicInfo.ProntuarioSql(prontuario);
        }

        var max = 100;
        var lista = DBClientes.Listar($"select distinct TOP {max} {DBClientes.SensivelCamposSqlX} FROM {DBClientes.PTabelaNome} WHERE {cWhere} ORDER BY {DBClientesDicInfo.CampoNome}", string.Empty, string.Empty, Configuracoes.ConnectionByUri(uri)).ToList();

        var result = new List<ClientesResponse>();
        foreach (var item in lista)
#pragma warning disable CS8604 // Possible null reference argument.
            result.Add(reader.Read(item));
#pragma warning restore CS8604 // Possible null reference argument.

        return result;
    });
    }
}