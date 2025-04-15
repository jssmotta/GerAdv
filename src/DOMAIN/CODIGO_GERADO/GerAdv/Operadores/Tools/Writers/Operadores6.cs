#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IOperadoresWriter
{
    Entity.DBOperadores Write(Models.Operadores operadores, int auditorQuem, SqlConnection oCnn);
}

public class Operadores : IOperadoresWriter
{
    public Entity.DBOperadores Write(Models.Operadores operadores, int auditorQuem, SqlConnection oCnn)
    {
        var dbRec = operadores.Id.IsEmptyIDNumber() ? new Entity.DBOperadores() : new Entity.DBOperadores(operadores.Id, oCnn);
        dbRec.FEnviado = operadores.Enviado;
        dbRec.FCasa = operadores.Casa;
        dbRec.FCasaID = operadores.CasaID;
        dbRec.FCasaCodigo = operadores.CasaCodigo;
        dbRec.FIsNovo = operadores.IsNovo;
        dbRec.FCliente = operadores.Cliente;
        dbRec.FGrupo = operadores.Grupo;
        dbRec.FNome = operadores.Nome;
        dbRec.FEMail = operadores.EMail;
        if (operadores.Senha.Length > 0)
            dbRec.FSenha = operadores.Senha.Encrypt();
        dbRec.FAtivado = operadores.Ativado;
        if (operadores.AtualizarSenha.Length > 0)
            dbRec.FAtualizarSenha = operadores.AtualizarSenha.Encrypt();
        if (operadores.Senha256.Length > 0)
            dbRec.FSenha256 = operadores.Senha256.Encrypt();
        if (operadores.SuporteSenha256.Length > 0)
            dbRec.FSuporteSenha256 = operadores.SuporteSenha256.Encrypt();
        if (operadores.SuporteMaxAge != null)
            dbRec.FSuporteMaxAge = operadores.SuporteMaxAge.ToString();
        dbRec.AuditorQuem = auditorQuem;
        dbRec.Update(oCnn);
        return dbRec;
    }
}