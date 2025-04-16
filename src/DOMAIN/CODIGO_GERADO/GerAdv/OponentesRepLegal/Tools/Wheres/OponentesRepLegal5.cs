#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Wheres;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IOponentesRepLegalWhere
{
    OponentesRepLegalResponse Read(string where, SqlConnection oCnn);
}

public partial class OponentesRepLegal : IOponentesRepLegalWhere
{
    public OponentesRepLegalResponse Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBOponentesRepLegal(sqlWhere: where, oCnn: oCnn);
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