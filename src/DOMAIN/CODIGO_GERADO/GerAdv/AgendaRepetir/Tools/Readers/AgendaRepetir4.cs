#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IAgendaRepetirReader
{
    AgendaRepetirResponse? Read(int id, MsiSqlConnection oCnn);
    AgendaRepetirResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    AgendaRepetirResponse? Read(Entity.DBAgendaRepetir dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    AgendaRepetirResponse? Read(DBAgendaRepetir dbRec);
    AgendaRepetirResponseAll? ReadAll(DBAgendaRepetir dbRec, DataRow dr);
}

public partial class AgendaRepetir : IAgendaRepetirReader
{
    public AgendaRepetirResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBAgendaRepetir(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public AgendaRepetirResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBAgendaRepetir(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public AgendaRepetirResponse? Read(Entity.DBAgendaRepetir dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var agendarepetir = new AgendaRepetirResponse
        {
            Id = dbRec.ID,
            Advogado = dbRec.FAdvogado,
            Cliente = dbRec.FCliente,
            Funcionario = dbRec.FFuncionario,
            Processo = dbRec.FProcesso,
            Pessoal = dbRec.FPessoal,
            Frequencia = dbRec.FFrequencia,
            Dia = dbRec.FDia,
            Mes = dbRec.FMes,
            IDQuem = dbRec.FIDQuem,
            IDQuem2 = dbRec.FIDQuem2,
            Mensagem = dbRec.FMensagem ?? string.Empty,
            IDTipo = dbRec.FIDTipo,
            ID1 = dbRec.FID1,
            ID2 = dbRec.FID2,
            ID3 = dbRec.FID3,
            ID4 = dbRec.FID4,
            Segunda = dbRec.FSegunda,
            Quarta = dbRec.FQuarta,
            Quinta = dbRec.FQuinta,
            Sexta = dbRec.FSexta,
            Sabado = dbRec.FSabado,
            Domingo = dbRec.FDomingo,
            Terca = dbRec.FTerca,
        };
        if (DateTime.TryParse(dbRec.FDataFinal, out _))
            agendarepetir.DataFinal = dbRec.FDataFinal;
        if (DateTime.TryParse(dbRec.FHoraFinal, out _))
            agendarepetir.HoraFinal = dbRec.FHoraFinal;
        if (DateTime.TryParse(dbRec.FHora, out _))
            agendarepetir.Hora = dbRec.FHora;
        return agendarepetir;
    }

    public AgendaRepetirResponse? Read(DBAgendaRepetir dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var agendarepetir = new AgendaRepetirResponse
        {
            Id = dbRec.ID,
            Advogado = dbRec.FAdvogado,
            Cliente = dbRec.FCliente,
            Funcionario = dbRec.FFuncionario,
            Processo = dbRec.FProcesso,
            Pessoal = dbRec.FPessoal,
            Frequencia = dbRec.FFrequencia,
            Dia = dbRec.FDia,
            Mes = dbRec.FMes,
            IDQuem = dbRec.FIDQuem,
            IDQuem2 = dbRec.FIDQuem2,
            Mensagem = dbRec.FMensagem ?? string.Empty,
            IDTipo = dbRec.FIDTipo,
            ID1 = dbRec.FID1,
            ID2 = dbRec.FID2,
            ID3 = dbRec.FID3,
            ID4 = dbRec.FID4,
            Segunda = dbRec.FSegunda,
            Quarta = dbRec.FQuarta,
            Quinta = dbRec.FQuinta,
            Sexta = dbRec.FSexta,
            Sabado = dbRec.FSabado,
            Domingo = dbRec.FDomingo,
            Terca = dbRec.FTerca,
        };
        if (DateTime.TryParse(dbRec.FDataFinal, out _))
            agendarepetir.DataFinal = dbRec.FDataFinal;
        if (DateTime.TryParse(dbRec.FHoraFinal, out _))
            agendarepetir.HoraFinal = dbRec.FHoraFinal;
        if (DateTime.TryParse(dbRec.FHora, out _))
            agendarepetir.Hora = dbRec.FHora;
        return agendarepetir;
    }

    public AgendaRepetirResponseAll? ReadAll(DBAgendaRepetir dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var agendarepetir = new AgendaRepetirResponseAll
        {
            Id = dbRec.ID,
            Advogado = dbRec.FAdvogado,
            Cliente = dbRec.FCliente,
            Funcionario = dbRec.FFuncionario,
            Processo = dbRec.FProcesso,
            Pessoal = dbRec.FPessoal,
            Frequencia = dbRec.FFrequencia,
            Dia = dbRec.FDia,
            Mes = dbRec.FMes,
            IDQuem = dbRec.FIDQuem,
            IDQuem2 = dbRec.FIDQuem2,
            Mensagem = dbRec.FMensagem ?? string.Empty,
            IDTipo = dbRec.FIDTipo,
            ID1 = dbRec.FID1,
            ID2 = dbRec.FID2,
            ID3 = dbRec.FID3,
            ID4 = dbRec.FID4,
            Segunda = dbRec.FSegunda,
            Quarta = dbRec.FQuarta,
            Quinta = dbRec.FQuinta,
            Sexta = dbRec.FSexta,
            Sabado = dbRec.FSabado,
            Domingo = dbRec.FDomingo,
            Terca = dbRec.FTerca,
        };
        if (DateTime.TryParse(dbRec.FDataFinal, out _))
            agendarepetir.DataFinal = dbRec.FDataFinal;
        if (DateTime.TryParse(dbRec.FHoraFinal, out _))
            agendarepetir.HoraFinal = dbRec.FHoraFinal;
        if (DateTime.TryParse(dbRec.FHora, out _))
            agendarepetir.Hora = dbRec.FHora;
        agendarepetir.NomeAdvogados = dr["advNome"]?.ToString() ?? string.Empty;
        agendarepetir.NomeClientes = dr["cliNome"]?.ToString() ?? string.Empty;
        agendarepetir.NomeFuncionarios = dr["funNome"]?.ToString() ?? string.Empty;
        agendarepetir.NroPastaProcessos = dr["proNroPasta"]?.ToString() ?? string.Empty;
        return agendarepetir;
    }
}