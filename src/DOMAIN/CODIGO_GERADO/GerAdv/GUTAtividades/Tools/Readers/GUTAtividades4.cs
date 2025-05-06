#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IGUTAtividadesReader
{
    GUTAtividadesResponse? Read(int id, SqlConnection oCnn);
    GUTAtividadesResponse? Read(string where, SqlConnection oCnn);
    GUTAtividadesResponse? Read(Entity.DBGUTAtividades dbRec);
    Task<string> ReadStringAuditor(int id, string uri, SqlConnection oCnn);
    GUTAtividadesResponse? Read(DBGUTAtividades dbRec);
}

public partial class GUTAtividades : IGUTAtividadesReader
{
    public GUTAtividadesResponse? Read(int id, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBGUTAtividades(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public GUTAtividadesResponse? Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBGUTAtividades(sqlWhere: where, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public GUTAtividadesResponse? Read(Entity.DBGUTAtividades dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var gutatividades = new GUTAtividadesResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            Observacao = dbRec.FObservacao ?? string.Empty,
            GUTGrupo = dbRec.FGUTGrupo,
            GUTPeriodicidade = dbRec.FGUTPeriodicidade,
            Operador = dbRec.FOperador,
            Concluido = dbRec.FConcluido,
            DiasParaIniciar = dbRec.FDiasParaIniciar,
            MinutosParaRealizar = dbRec.FMinutosParaRealizar,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FDataConcluido, out _))
            gutatividades.DataConcluido = dbRec.FDataConcluido;
        var auditor = new Auditor
        {
            Visto = dbRec.FVisto,
            QuemCad = dbRec.FQuemCad
        };
        if (auditor.QuemAtu > 0)
            auditor.QuemAtu = dbRec.FQuemAtu;
        if (dbRec.FDtCad.NotIsEmpty())
            auditor.DtCad = Convert.ToDateTime(dbRec.FDtCad);
        if (!(dbRec.FDtAtu is { }))
            auditor.DtAtu = Convert.ToDateTime(dbRec.FDtAtu);
        gutatividades.Auditor = auditor;
        return gutatividades;
    }

    public GUTAtividadesResponse? Read(DBGUTAtividades dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var gutatividades = new GUTAtividadesResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            Observacao = dbRec.FObservacao ?? string.Empty,
            GUTGrupo = dbRec.FGUTGrupo,
            GUTPeriodicidade = dbRec.FGUTPeriodicidade,
            Operador = dbRec.FOperador,
            Concluido = dbRec.FConcluido,
            DiasParaIniciar = dbRec.FDiasParaIniciar,
            MinutosParaRealizar = dbRec.FMinutosParaRealizar,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FDataConcluido, out _))
            gutatividades.DataConcluido = dbRec.FDataConcluido;
        var auditor = new Auditor
        {
            Visto = dbRec.FVisto,
            QuemCad = dbRec.FQuemCad
        };
        if (auditor.QuemAtu > 0)
            auditor.QuemAtu = dbRec.FQuemAtu;
        if (dbRec.FDtCad.NotIsEmpty())
            auditor.DtCad = Convert.ToDateTime(dbRec.FDtCad);
        if (!(dbRec.FDtAtu is { }))
            auditor.DtAtu = Convert.ToDateTime(dbRec.FDtAtu);
        gutatividades.Auditor = auditor;
        return gutatividades;
    }
}