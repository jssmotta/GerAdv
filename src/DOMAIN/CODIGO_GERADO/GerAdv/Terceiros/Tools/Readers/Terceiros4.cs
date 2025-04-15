#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface ITerceirosReader
{
    TerceirosResponse? Read(int id, SqlConnection oCnn);
    TerceirosResponse? Read(string where, SqlConnection oCnn);
    TerceirosResponse? Read(Entity.DBTerceiros dbRec);
    TerceirosResponse? Read(DBTerceiros dbRec);
}

public partial class Terceiros : ITerceirosReader
{
    public TerceirosResponse? Read(int id, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBTerceiros(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public TerceirosResponse? Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBTerceiros(sqlWhere: where, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public TerceirosResponse? Read(Entity.DBTerceiros dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var terceiros = new TerceirosResponse
        {
            Id = dbRec.ID,
            Processo = dbRec.FProcesso,
            Nome = dbRec.FNome ?? string.Empty,
            Situacao = dbRec.FSituacao,
            Cidade = dbRec.FCidade,
            Endereco = dbRec.FEndereco ?? string.Empty,
            Bairro = dbRec.FBairro ?? string.Empty,
            CEP = dbRec.FCEP ?? string.Empty,
            Fone = dbRec.FFone ?? string.Empty,
            Fax = dbRec.FFax ?? string.Empty,
            OBS = dbRec.FOBS ?? string.Empty,
            EMail = dbRec.FEMail ?? string.Empty,
            Class = dbRec.FClass ?? string.Empty,
            VaraForoComarca = dbRec.FVaraForoComarca ?? string.Empty,
            Sexo = dbRec.FSexo,
            Bold = dbRec.FBold,
            Guid = dbRec.FGUID ?? string.Empty,
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
        terceiros.Auditor = auditor;
        return terceiros;
    }

    public TerceirosResponse? Read(DBTerceiros dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var terceiros = new TerceirosResponse
        {
            Id = dbRec.ID,
            Processo = dbRec.FProcesso,
            Nome = dbRec.FNome ?? string.Empty,
            Situacao = dbRec.FSituacao,
            Cidade = dbRec.FCidade,
            Endereco = dbRec.FEndereco ?? string.Empty,
            Bairro = dbRec.FBairro ?? string.Empty,
            CEP = dbRec.FCEP ?? string.Empty,
            Fone = dbRec.FFone ?? string.Empty,
            Fax = dbRec.FFax ?? string.Empty,
            OBS = dbRec.FOBS ?? string.Empty,
            EMail = dbRec.FEMail ?? string.Empty,
            Class = dbRec.FClass ?? string.Empty,
            VaraForoComarca = dbRec.FVaraForoComarca ?? string.Empty,
            Sexo = dbRec.FSexo,
            Bold = dbRec.FBold,
            Guid = dbRec.FGUID ?? string.Empty,
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
        terceiros.Auditor = auditor;
        return terceiros;
    }
}