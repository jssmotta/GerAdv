#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IViaRecebimentoReader
{
    ViaRecebimentoResponse? Read(int id, SqlConnection oCnn);
    ViaRecebimentoResponse? Read(string where, SqlConnection oCnn);
    ViaRecebimentoResponse? Read(Entity.DBViaRecebimento dbRec);
    ViaRecebimentoResponse? Read(DBViaRecebimento dbRec);
}

public partial class ViaRecebimento : IViaRecebimentoReader
{
    public ViaRecebimentoResponse? Read(int id, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBViaRecebimento(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public ViaRecebimentoResponse? Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBViaRecebimento(sqlWhere: where, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public ViaRecebimentoResponse? Read(Entity.DBViaRecebimento dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var viarecebimento = new ViaRecebimentoResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
        };
        return viarecebimento;
    }

    public ViaRecebimentoResponse? Read(DBViaRecebimento dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var viarecebimento = new ViaRecebimentoResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
        };
        return viarecebimento;
    }
}