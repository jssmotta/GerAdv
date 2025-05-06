#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IOperadorEMailPopupWriter
{
    Entity.DBOperadorEMailPopup Write(Models.OperadorEMailPopup operadoremailpopup, int auditorQuem, SqlConnection oCnn);
}

public class OperadorEMailPopup : IOperadorEMailPopupWriter
{
    public Entity.DBOperadorEMailPopup Write(Models.OperadorEMailPopup operadoremailpopup, int auditorQuem, SqlConnection oCnn)
    {
        var dbRec = operadoremailpopup.Id.IsEmptyIDNumber() ? new Entity.DBOperadorEMailPopup() : new Entity.DBOperadorEMailPopup(operadoremailpopup.Id, oCnn);
        dbRec.FOperador = operadoremailpopup.Operador;
        dbRec.FNome = operadoremailpopup.Nome;
        if (operadoremailpopup.Senha.Length > 0)
            dbRec.FSenha = operadoremailpopup.Senha.Encrypt();
        dbRec.FSMTP = operadoremailpopup.SMTP;
        dbRec.FPOP3 = operadoremailpopup.POP3;
        dbRec.FAutenticacao = operadoremailpopup.Autenticacao;
        dbRec.FDescricao = operadoremailpopup.Descricao;
        dbRec.FUsuario = operadoremailpopup.Usuario;
        dbRec.FPortaSmtp = operadoremailpopup.PortaSmtp;
        dbRec.FPortaPop3 = operadoremailpopup.PortaPop3;
        dbRec.FAssinatura = operadoremailpopup.Assinatura;
        if (operadoremailpopup.Senha256.Length > 0)
            dbRec.FSenha256 = operadoremailpopup.Senha256.Encrypt();
        dbRec.FGUID = operadoremailpopup.GUID;
        dbRec.AuditorQuem = auditorQuem;
        dbRec.Update(oCnn);
        return dbRec;
    }
}