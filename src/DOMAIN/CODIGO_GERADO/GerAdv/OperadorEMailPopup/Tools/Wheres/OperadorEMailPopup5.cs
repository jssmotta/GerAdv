#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Wheres;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IOperadorEMailPopupWhere
{
    OperadorEMailPopupResponse Read(string where, SqlConnection oCnn);
}

public partial class OperadorEMailPopup : IOperadorEMailPopupWhere
{
    public OperadorEMailPopupResponse Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBOperadorEMailPopup(sqlWhere: where, oCnn: oCnn);
        var operadoremailpopup = new OperadorEMailPopupResponse
        {
            Id = dbRec.ID,
            Operador = dbRec.FOperador,
            Nome = dbRec.FNome ?? string.Empty,
            SMTP = dbRec.FSMTP ?? string.Empty,
            POP3 = dbRec.FPOP3 ?? string.Empty,
            Autenticacao = dbRec.FAutenticacao,
            Descricao = dbRec.FDescricao ?? string.Empty,
            Usuario = dbRec.FUsuario ?? string.Empty,
            PortaSmtp = dbRec.FPortaSmtp,
            PortaPop3 = dbRec.FPortaPop3,
            Assinatura = dbRec.FAssinatura ?? string.Empty,
            GUID = dbRec.FGUID ?? string.Empty,
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
        operadoremailpopup.Auditor = auditor;
        return operadoremailpopup;
    }
}