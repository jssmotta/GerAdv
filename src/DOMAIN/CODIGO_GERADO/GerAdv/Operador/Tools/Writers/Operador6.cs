#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IOperadorWriter
{
    Entity.DBOperador Write(Models.Operador operador, int auditorQuem, SqlConnection oCnn);
}

public class Operador : IOperadorWriter
{
    public Entity.DBOperador Write(Models.Operador operador, int auditorQuem, SqlConnection oCnn)
    {
        var dbRec = operador.Id.IsEmptyIDNumber() ? new Entity.DBOperador() : new Entity.DBOperador(operador.Id, oCnn);
        dbRec.FEMail = operador.EMail;
        dbRec.FPasta = operador.Pasta;
        dbRec.FTelefonista = operador.Telefonista;
        dbRec.FMaster = operador.Master;
        dbRec.FNome = operador.Nome;
        dbRec.FNick = operador.Nick;
        dbRec.FRamal = operador.Ramal;
        dbRec.FCadID = operador.CadID;
        dbRec.FCadCod = operador.CadCod;
        dbRec.FExcluido = operador.Excluido;
        dbRec.FSituacao = operador.Situacao;
        dbRec.FComputador = operador.Computador;
        dbRec.FMinhaDescricao = operador.MinhaDescricao;
        if (operador.UltimoLogoff != null)
            dbRec.FUltimoLogoff = operador.UltimoLogoff.ToString();
        dbRec.FEMailNet = operador.EMailNet;
        dbRec.FOnlineIP = operador.OnlineIP;
        dbRec.FOnLine = operador.OnLine;
        dbRec.FSysOp = operador.SysOp;
        dbRec.FStatusId = operador.StatusId;
        dbRec.FStatusMessage = operador.StatusMessage;
        dbRec.FIsFinanceiro = operador.IsFinanceiro;
        dbRec.FTop = operador.Top;
        dbRec.FSexo = operador.Sexo;
        dbRec.FBasico = operador.Basico;
        dbRec.FExterno = operador.Externo;
        if (operador.Senha256.Length > 0)
            dbRec.FSenha256 = operador.Senha256.GetHashCode2();
        dbRec.FEMailConfirmado = operador.EMailConfirmado;
        if (operador.DataLimiteReset != null)
            dbRec.FDataLimiteReset = operador.DataLimiteReset.ToString();
        if (operador.SuporteSenha256.Length > 0)
            dbRec.FSuporteSenha256 = operador.SuporteSenha256.Encrypt();
        if (operador.SuporteMaxAge != null)
            dbRec.FSuporteMaxAge = operador.SuporteMaxAge.ToString();
        dbRec.FSuporteNomeSolicitante = operador.SuporteNomeSolicitante;
        if (operador.SuporteUltimoAcesso != null)
            dbRec.FSuporteUltimoAcesso = operador.SuporteUltimoAcesso.ToString();
        dbRec.FSuporteIpUltimoAcesso = operador.SuporteIpUltimoAcesso;
        dbRec.AuditorQuem = auditorQuem;
        dbRec.Update(oCnn);
        return dbRec;
    }
}