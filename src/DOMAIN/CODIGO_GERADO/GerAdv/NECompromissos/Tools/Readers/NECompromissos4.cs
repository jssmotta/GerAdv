#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface INECompromissosReader
{
    NECompromissosResponse? Read(int id, MsiSqlConnection oCnn);
    NECompromissosResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    NECompromissosResponse? Read(Entity.DBNECompromissos dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    NECompromissosResponse? Read(DBNECompromissos dbRec);
    NECompromissosResponseAll? ReadAll(DBNECompromissos dbRec, DataRow dr);
}

public partial class NECompromissos : INECompromissosReader
{
    public NECompromissosResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBNECompromissos(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public NECompromissosResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBNECompromissos(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public NECompromissosResponse? Read(Entity.DBNECompromissos dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var necompromissos = new NECompromissosResponse
        {
            Id = dbRec.ID,
            PalavraChave = dbRec.FPalavraChave,
            Provisionar = dbRec.FProvisionar,
            TipoCompromisso = dbRec.FTipoCompromisso,
            TextoCompromisso = dbRec.FTextoCompromisso ?? string.Empty,
            Bold = dbRec.FBold,
        };
        return necompromissos;
    }

    public NECompromissosResponse? Read(DBNECompromissos dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var necompromissos = new NECompromissosResponse
        {
            Id = dbRec.ID,
            PalavraChave = dbRec.FPalavraChave,
            Provisionar = dbRec.FProvisionar,
            TipoCompromisso = dbRec.FTipoCompromisso,
            TextoCompromisso = dbRec.FTextoCompromisso ?? string.Empty,
            Bold = dbRec.FBold,
        };
        return necompromissos;
    }

    public NECompromissosResponseAll? ReadAll(DBNECompromissos dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var necompromissos = new NECompromissosResponseAll
        {
            Id = dbRec.ID,
            PalavraChave = dbRec.FPalavraChave,
            Provisionar = dbRec.FProvisionar,
            TipoCompromisso = dbRec.FTipoCompromisso,
            TextoCompromisso = dbRec.FTextoCompromisso ?? string.Empty,
            Bold = dbRec.FBold,
        };
        necompromissos.DescricaoTipoCompromisso = dr["tipDescricao"]?.ToString() ?? string.Empty;
        return necompromissos;
    }
}