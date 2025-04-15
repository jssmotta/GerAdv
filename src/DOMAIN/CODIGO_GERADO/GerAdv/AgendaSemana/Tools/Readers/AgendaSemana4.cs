#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IAgendaSemanaReader
{
    AgendaSemanaResponse? Read(string where, SqlConnection oCnn);
    AgendaSemanaResponse? Read(Entity.DBAgendaSemana dbRec);
    AgendaSemanaResponse? Read(DBAgendaSemana dbRec);
}

public partial class AgendaSemana : IAgendaSemanaReader
{
    public AgendaSemanaResponse? Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBAgendaSemana(sqlWhere: where, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public AgendaSemanaResponse? Read(Entity.DBAgendaSemana dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var agendasemana = new AgendaSemanaResponse
        {
            Id = dbRec.ID,
            ParaNome = dbRec.FParaNome ?? string.Empty,
            Data = dbRec.FData,
            Funcionario = dbRec.FFuncionario,
            Advogado = dbRec.FAdvogado,
            Hora = dbRec.FHora,
            TipoCompromisso = dbRec.FTipoCompromisso,
            Compromisso = dbRec.FCompromisso ?? string.Empty,
            Concluido = dbRec.FConcluido,
            Liberado = dbRec.FLiberado,
            Importante = dbRec.FImportante,
            HoraFinal = dbRec.FHoraFinal,
            Nome = dbRec.FNome ?? string.Empty,
            Cliente = dbRec.FCliente,
            NomeCliente = dbRec.FNomeCliente ?? string.Empty,
            Tipo = dbRec.FTipo ?? string.Empty,
        };
        return agendasemana;
    }

    public AgendaSemanaResponse? Read(DBAgendaSemana dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var agendasemana = new AgendaSemanaResponse
        {
            Id = dbRec.ID,
            ParaNome = dbRec.FParaNome ?? string.Empty,
            Data = dbRec.FData,
            Funcionario = dbRec.FFuncionario,
            Advogado = dbRec.FAdvogado,
            Hora = dbRec.FHora,
            TipoCompromisso = dbRec.FTipoCompromisso,
            Compromisso = dbRec.FCompromisso ?? string.Empty,
            Concluido = dbRec.FConcluido,
            Liberado = dbRec.FLiberado,
            Importante = dbRec.FImportante,
            HoraFinal = dbRec.FHoraFinal,
            Nome = dbRec.FNome ?? string.Empty,
            Cliente = dbRec.FCliente,
            NomeCliente = dbRec.FNomeCliente ?? string.Empty,
            Tipo = dbRec.FTipo ?? string.Empty,
        };
        return agendasemana;
    }
}