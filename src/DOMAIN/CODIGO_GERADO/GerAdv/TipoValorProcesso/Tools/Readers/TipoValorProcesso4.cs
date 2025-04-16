#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface ITipoValorProcessoReader
{
    TipoValorProcessoResponse? Read(int id, SqlConnection oCnn);
    TipoValorProcessoResponse? Read(string where, SqlConnection oCnn);
    TipoValorProcessoResponse? Read(Entity.DBTipoValorProcesso dbRec);
    TipoValorProcessoResponse? Read(DBTipoValorProcesso dbRec);
}

public partial class TipoValorProcesso : ITipoValorProcessoReader
{
    public TipoValorProcessoResponse? Read(int id, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBTipoValorProcesso(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public TipoValorProcessoResponse? Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBTipoValorProcesso(sqlWhere: where, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public TipoValorProcessoResponse? Read(Entity.DBTipoValorProcesso dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var tipovalorprocesso = new TipoValorProcessoResponse
        {
            Id = dbRec.ID,
            Descricao = dbRec.FDescricao ?? string.Empty,
            Guid = dbRec.FGUID ?? string.Empty,
        };
        return tipovalorprocesso;
    }

    public TipoValorProcessoResponse? Read(DBTipoValorProcesso dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var tipovalorprocesso = new TipoValorProcessoResponse
        {
            Id = dbRec.ID,
            Descricao = dbRec.FDescricao ?? string.Empty,
            Guid = dbRec.FGUID ?? string.Empty,
        };
        return tipovalorprocesso;
    }
}