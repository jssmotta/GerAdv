namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBOperador
{
    public void SetValueByNameField(string nomeCampo, object value)
    {
        switch (nomeCampo)
        {
            case DBOperadorDicInfo.EMail:
                FEMail = $"{value}"; // rgo J3: string
                return;
            case DBOperadorDicInfo.Pasta:
                FPasta = $"{value}"; // rgo J3: string
                return;
            case DBOperadorDicInfo.Telefonista:
                FTelefonista = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBOperadorDicInfo.Master:
                FMaster = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBOperadorDicInfo.Nome:
                FNome = $"{value}"; // rgo J3: string
                return;
            case DBOperadorDicInfo.Nick:
                FNick = $"{value}"; // rgo J3: string
                return;
            case DBOperadorDicInfo.Ramal:
                FRamal = $"{value}"; // rgo J3: string
                return;
            case DBOperadorDicInfo.CadID:
                FCadID = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBOperadorDicInfo.CadCod:
                FCadCod = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBOperadorDicInfo.Excluido:
                FExcluido = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBOperadorDicInfo.Situacao:
                FSituacao = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBOperadorDicInfo.Computador:
                FComputador = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBOperadorDicInfo.MinhaDescricao:
                FMinhaDescricao = $"{value}"; // rgo J3: string
                return;
            case DBOperadorDicInfo.UltimoLogoff:
                FUltimoLogoff = $"{value}"; // rgo J3: DateTime
                return;
            case DBOperadorDicInfo.EMailNet:
                FEMailNet = $"{value}"; // rgo J3: string
                return;
            case DBOperadorDicInfo.OnlineIP:
                FOnlineIP = $"{value}"; // rgo J3: string
                return;
            case DBOperadorDicInfo.OnLine:
                FOnLine = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBOperadorDicInfo.SysOp:
                FSysOp = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBOperadorDicInfo.StatusId:
                FStatusId = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBOperadorDicInfo.StatusMessage:
                FStatusMessage = $"{value}"; // rgo J3: string
                return;
            case DBOperadorDicInfo.IsFinanceiro:
                FIsFinanceiro = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBOperadorDicInfo.Top:
                FTop = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBOperadorDicInfo.Sexo:
                FSexo = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBOperadorDicInfo.Basico:
                FBasico = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBOperadorDicInfo.Externo:
                FExterno = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBOperadorDicInfo.Senha256:
                FSenha256 = $"{value}"; // rgo J3: string
                return;
            case DBOperadorDicInfo.EMailConfirmado:
                FEMailConfirmado = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBOperadorDicInfo.DataLimiteReset:
                FDataLimiteReset = $"{value}"; // rgo J3: DateTime
                return;
            case DBOperadorDicInfo.SuporteSenha256:
                FSuporteSenha256 = $"{value}"; // rgo J3: string
                return;
            case DBOperadorDicInfo.SuporteMaxAge:
                FSuporteMaxAge = $"{value}"; // rgo J3: DateTime
                return;
            case DBOperadorDicInfo.SuporteNomeSolicitante:
                FSuporteNomeSolicitante = $"{value}"; // rgo J3: string
                return;
            case DBOperadorDicInfo.SuporteUltimoAcesso:
                FSuporteUltimoAcesso = $"{value}"; // rgo J3: DateTime
                return;
            case DBOperadorDicInfo.SuporteIpUltimoAcesso:
                FSuporteIpUltimoAcesso = $"{value}"; // rgo J3: string
                return;
            case DBOperadorDicInfo.GUID:
                FGUID = $"{value}"; // rgo J3: string
                return;
            case DBOperadorDicInfo.QuemCad:
                FQuemCad = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBOperadorDicInfo.DtCad:
                FDtCad = $"{value}"; // rgo J3: DateTime
                return;
            case DBOperadorDicInfo.QuemAtu:
                FQuemAtu = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBOperadorDicInfo.DtAtu:
                FDtAtu = $"{value}"; // rgo J3: DateTime
                return;
            case DBOperadorDicInfo.Visto:
                FVisto = $"{value}".Equals("True"); // rgo J3: bool
                return;
        }
    }

    public object GetValueByNameField(string nomeCampo) => nomeCampo switch
    {
        DBOperadorDicInfo.EMail => NFEMail(),
        DBOperadorDicInfo.Pasta => NFPasta(),
        DBOperadorDicInfo.Telefonista => FTelefonista.ToString(),
        DBOperadorDicInfo.Master => FMaster.ToString(),
        DBOperadorDicInfo.Nome => NFNome(),
        DBOperadorDicInfo.Nick => NFNick(),
        DBOperadorDicInfo.Ramal => NFRamal(),
        DBOperadorDicInfo.CadID => NFCadID(),
        DBOperadorDicInfo.CadCod => NFCadCod(),
        DBOperadorDicInfo.Excluido => FExcluido.ToString(),
        DBOperadorDicInfo.Situacao => FSituacao.ToString(),
        DBOperadorDicInfo.Computador => NFComputador(),
        DBOperadorDicInfo.MinhaDescricao => NFMinhaDescricao(),
        DBOperadorDicInfo.UltimoLogoff => NFUltimoLogoff(),
        DBOperadorDicInfo.EMailNet => NFEMailNet(),
        DBOperadorDicInfo.OnlineIP => NFOnlineIP(),
        DBOperadorDicInfo.OnLine => FOnLine.ToString(),
        DBOperadorDicInfo.SysOp => FSysOp.ToString(),
        DBOperadorDicInfo.StatusId => NFStatusId(),
        DBOperadorDicInfo.StatusMessage => NFStatusMessage(),
        DBOperadorDicInfo.IsFinanceiro => FIsFinanceiro.ToString(),
        DBOperadorDicInfo.Top => FTop.ToString(),
        DBOperadorDicInfo.Sexo => FSexo.ToString(),
        DBOperadorDicInfo.Basico => FBasico.ToString(),
        DBOperadorDicInfo.Externo => FExterno.ToString(),
        DBOperadorDicInfo.Senha256 => NFSenha256(),
        DBOperadorDicInfo.EMailConfirmado => FEMailConfirmado.ToString(),
        DBOperadorDicInfo.DataLimiteReset => NFDataLimiteReset(),
        DBOperadorDicInfo.SuporteSenha256 => NFSuporteSenha256(),
        DBOperadorDicInfo.SuporteMaxAge => NFSuporteMaxAge(),
        DBOperadorDicInfo.SuporteNomeSolicitante => NFSuporteNomeSolicitante(),
        DBOperadorDicInfo.SuporteUltimoAcesso => NFSuporteUltimoAcesso(),
        DBOperadorDicInfo.SuporteIpUltimoAcesso => NFSuporteIpUltimoAcesso(),
        DBOperadorDicInfo.GUID => NFGUID(),
        DBOperadorDicInfo.QuemCad => NFQuemCad(),
        DBOperadorDicInfo.DtCad => MDtCad,
        DBOperadorDicInfo.QuemAtu => NFQuemAtu(),
        DBOperadorDicInfo.DtAtu => MDtAtu,
        DBOperadorDicInfo.Visto => FVisto.ToString(),
        _ => nameof(GetValueByNameField)};
}