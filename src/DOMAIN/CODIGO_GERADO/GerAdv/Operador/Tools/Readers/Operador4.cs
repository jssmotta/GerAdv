#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IOperadorReader
{
    OperadorResponse? Read(int id, SqlConnection oCnn);
    OperadorResponse? Read(string where, SqlConnection oCnn);
    OperadorResponse? Read(Entity.DBOperador dbRec);
    Task<string> ReadStringAuditor(int id, string uri, SqlConnection oCnn);
    OperadorResponse? Read(DBOperador dbRec);
}

public partial class Operador : IOperadorReader
{
    public OperadorResponse? Read(int id, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBOperador(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public OperadorResponse? Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBOperador(sqlWhere: where, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public OperadorResponse? Read(Entity.DBOperador dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var operador = new OperadorResponse
        {
            Id = dbRec.ID,
            EMail = dbRec.FEMail ?? string.Empty,
            Pasta = dbRec.FPasta ?? string.Empty,
            Telefonista = dbRec.FTelefonista,
            Master = dbRec.FMaster,
            Nome = dbRec.FNome ?? string.Empty,
            Nick = dbRec.FNick ?? string.Empty,
            Ramal = dbRec.FRamal ?? string.Empty,
            CadID = dbRec.FCadID,
            CadCod = dbRec.FCadCod,
            Excluido = dbRec.FExcluido,
            Situacao = dbRec.FSituacao,
            Computador = dbRec.FComputador,
            MinhaDescricao = dbRec.FMinhaDescricao ?? string.Empty,
            EMailNet = dbRec.FEMailNet ?? string.Empty,
            OnlineIP = dbRec.FOnlineIP ?? string.Empty,
            OnLine = dbRec.FOnLine,
            SysOp = dbRec.FSysOp,
            StatusId = dbRec.FStatusId,
            StatusMessage = dbRec.FStatusMessage ?? string.Empty,
            IsFinanceiro = dbRec.FIsFinanceiro,
            Top = dbRec.FTop,
            Sexo = dbRec.FSexo,
            Basico = dbRec.FBasico,
            Externo = dbRec.FExterno,
            EMailConfirmado = dbRec.FEMailConfirmado,
            SuporteNomeSolicitante = dbRec.FSuporteNomeSolicitante ?? string.Empty,
            SuporteIpUltimoAcesso = dbRec.FSuporteIpUltimoAcesso ?? string.Empty,
            Guid = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FUltimoLogoff, out _))
            operador.UltimoLogoff = dbRec.FUltimoLogoff;
        if (DateTime.TryParse(dbRec.FDataLimiteReset, out _))
            operador.DataLimiteReset = dbRec.FDataLimiteReset;
        if (DateTime.TryParse(dbRec.FSuporteMaxAge, out _))
            operador.SuporteMaxAge = dbRec.FSuporteMaxAge;
        if (DateTime.TryParse(dbRec.FSuporteUltimoAcesso, out _))
            operador.SuporteUltimoAcesso = dbRec.FSuporteUltimoAcesso;
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
        operador.Auditor = auditor;
        if (dbRec.FSenha256.Equals("111111".GetHashCode2()))
        {
            operador.StatusMessage = "Senha Resetada";
        }

        return operador;
    }

    public OperadorResponse? Read(DBOperador dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var operador = new OperadorResponse
        {
            Id = dbRec.ID,
            EMail = dbRec.FEMail ?? string.Empty,
            Pasta = dbRec.FPasta ?? string.Empty,
            Telefonista = dbRec.FTelefonista,
            Master = dbRec.FMaster,
            Nome = dbRec.FNome ?? string.Empty,
            Nick = dbRec.FNick ?? string.Empty,
            Ramal = dbRec.FRamal ?? string.Empty,
            CadID = dbRec.FCadID,
            CadCod = dbRec.FCadCod,
            Excluido = dbRec.FExcluido,
            Situacao = dbRec.FSituacao,
            Computador = dbRec.FComputador,
            MinhaDescricao = dbRec.FMinhaDescricao ?? string.Empty,
            EMailNet = dbRec.FEMailNet ?? string.Empty,
            OnlineIP = dbRec.FOnlineIP ?? string.Empty,
            OnLine = dbRec.FOnLine,
            SysOp = dbRec.FSysOp,
            StatusId = dbRec.FStatusId,
            StatusMessage = dbRec.FStatusMessage ?? string.Empty,
            IsFinanceiro = dbRec.FIsFinanceiro,
            Top = dbRec.FTop,
            Sexo = dbRec.FSexo,
            Basico = dbRec.FBasico,
            Externo = dbRec.FExterno,
            EMailConfirmado = dbRec.FEMailConfirmado,
            SuporteNomeSolicitante = dbRec.FSuporteNomeSolicitante ?? string.Empty,
            SuporteIpUltimoAcesso = dbRec.FSuporteIpUltimoAcesso ?? string.Empty,
            Guid = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FUltimoLogoff, out _))
            operador.UltimoLogoff = dbRec.FUltimoLogoff;
        if (DateTime.TryParse(dbRec.FDataLimiteReset, out _))
            operador.DataLimiteReset = dbRec.FDataLimiteReset;
        if (DateTime.TryParse(dbRec.FSuporteMaxAge, out _))
            operador.SuporteMaxAge = dbRec.FSuporteMaxAge;
        if (DateTime.TryParse(dbRec.FSuporteUltimoAcesso, out _))
            operador.SuporteUltimoAcesso = dbRec.FSuporteUltimoAcesso;
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
        operador.Auditor = auditor;
        if (dbRec.FSenha256.Equals("111111".GetHashCode2()))
        {
            operador.StatusMessage = "Senha Resetada";
        }

        return operador;
    }
}