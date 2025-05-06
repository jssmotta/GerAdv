#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IForoReader
{
    ForoResponse? Read(int id, SqlConnection oCnn);
    ForoResponse? Read(string where, SqlConnection oCnn);
    ForoResponse? Read(Entity.DBForo dbRec);
    Task<string> ReadStringAuditor(int id, string uri, SqlConnection oCnn);
    ForoResponse? Read(DBForo dbRec);
}

public partial class Foro : IForoReader
{
    public ForoResponse? Read(int id, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBForo(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public ForoResponse? Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBForo(sqlWhere: where, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public ForoResponse? Read(Entity.DBForo dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var foro = new ForoResponse
        {
            Id = dbRec.ID,
            EMail = dbRec.FEMail ?? string.Empty,
            Nome = dbRec.FNome ?? string.Empty,
            Unico = dbRec.FUnico,
            Cidade = dbRec.FCidade,
            Site = dbRec.FSite ?? string.Empty,
            Endereco = dbRec.FEndereco ?? string.Empty,
            Bairro = dbRec.FBairro ?? string.Empty,
            Fone = dbRec.FFone ?? string.Empty,
            Fax = dbRec.FFax ?? string.Empty,
            CEP = dbRec.FCEP ?? string.Empty,
            OBS = dbRec.FOBS ?? string.Empty,
            UnicoConfirmado = dbRec.FUnicoConfirmado,
            Web = dbRec.FWeb ?? string.Empty,
            Etiqueta = dbRec.FEtiqueta,
            Bold = dbRec.FBold,
        };
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
        foro.Auditor = auditor;
        return foro;
    }

    public ForoResponse? Read(DBForo dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var foro = new ForoResponse
        {
            Id = dbRec.ID,
            EMail = dbRec.FEMail ?? string.Empty,
            Nome = dbRec.FNome ?? string.Empty,
            Unico = dbRec.FUnico,
            Cidade = dbRec.FCidade,
            Site = dbRec.FSite ?? string.Empty,
            Endereco = dbRec.FEndereco ?? string.Empty,
            Bairro = dbRec.FBairro ?? string.Empty,
            Fone = dbRec.FFone ?? string.Empty,
            Fax = dbRec.FFax ?? string.Empty,
            CEP = dbRec.FCEP ?? string.Empty,
            OBS = dbRec.FOBS ?? string.Empty,
            UnicoConfirmado = dbRec.FUnicoConfirmado,
            Web = dbRec.FWeb ?? string.Empty,
            Etiqueta = dbRec.FEtiqueta,
            Bold = dbRec.FBold,
        };
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
        foro.Auditor = auditor;
        return foro;
    }
}