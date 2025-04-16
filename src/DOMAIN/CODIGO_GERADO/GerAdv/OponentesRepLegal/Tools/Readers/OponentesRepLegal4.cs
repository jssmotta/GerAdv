#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IOponentesRepLegalReader
{
    OponentesRepLegalResponse? Read(int id, SqlConnection oCnn);
    OponentesRepLegalResponse? Read(string where, SqlConnection oCnn);
    OponentesRepLegalResponse? Read(Entity.DBOponentesRepLegal dbRec);
    OponentesRepLegalResponse? Read(DBOponentesRepLegal dbRec);
}

public partial class OponentesRepLegal : IOponentesRepLegalReader
{
    public OponentesRepLegalResponse? Read(int id, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBOponentesRepLegal(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public OponentesRepLegalResponse? Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBOponentesRepLegal(sqlWhere: where, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public OponentesRepLegalResponse? Read(Entity.DBOponentesRepLegal dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var oponentesreplegal = new OponentesRepLegalResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            Fone = dbRec.FFone ?? string.Empty,
            Oponente = dbRec.FOponente,
            Sexo = dbRec.FSexo,
            CPF = dbRec.FCPF ?? string.Empty,
            RG = dbRec.FRG ?? string.Empty,
            Endereco = dbRec.FEndereco ?? string.Empty,
            Bairro = dbRec.FBairro ?? string.Empty,
            CEP = dbRec.FCEP ?? string.Empty,
            Cidade = dbRec.FCidade,
            Fax = dbRec.FFax ?? string.Empty,
            EMail = dbRec.FEMail ?? string.Empty,
            Site = dbRec.FSite ?? string.Empty,
            Observacao = dbRec.FObservacao ?? string.Empty,
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
        oponentesreplegal.Auditor = auditor;
        return oponentesreplegal;
    }

    public OponentesRepLegalResponse? Read(DBOponentesRepLegal dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var oponentesreplegal = new OponentesRepLegalResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            Fone = dbRec.FFone ?? string.Empty,
            Oponente = dbRec.FOponente,
            Sexo = dbRec.FSexo,
            CPF = dbRec.FCPF ?? string.Empty,
            RG = dbRec.FRG ?? string.Empty,
            Endereco = dbRec.FEndereco ?? string.Empty,
            Bairro = dbRec.FBairro ?? string.Empty,
            CEP = dbRec.FCEP ?? string.Empty,
            Cidade = dbRec.FCidade,
            Fax = dbRec.FFax ?? string.Empty,
            EMail = dbRec.FEMail ?? string.Empty,
            Site = dbRec.FSite ?? string.Empty,
            Observacao = dbRec.FObservacao ?? string.Empty,
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
        oponentesreplegal.Auditor = auditor;
        return oponentesreplegal;
    }
}