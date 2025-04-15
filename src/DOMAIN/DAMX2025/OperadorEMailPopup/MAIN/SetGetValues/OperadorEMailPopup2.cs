namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBOperadorEMailPopup
{
    public void SetValueByNameField(string nomeCampo, object value)
    {
        switch (nomeCampo)
        {
            case DBOperadorEMailPopupDicInfo.Operador:
                FOperador = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBOperadorEMailPopupDicInfo.Nome:
                FNome = $"{value}"; // rgo J3: string
                return;
            case DBOperadorEMailPopupDicInfo.Senha:
                FSenha = $"{value}"; // rgo J3: string
                return;
            case DBOperadorEMailPopupDicInfo.SMTP:
                FSMTP = $"{value}"; // rgo J3: string
                return;
            case DBOperadorEMailPopupDicInfo.POP3:
                FPOP3 = $"{value}"; // rgo J3: string
                return;
            case DBOperadorEMailPopupDicInfo.Autenticacao:
                FAutenticacao = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBOperadorEMailPopupDicInfo.Descricao:
                FDescricao = $"{value}"; // rgo J3: string
                return;
            case DBOperadorEMailPopupDicInfo.Usuario:
                FUsuario = $"{value}"; // rgo J3: string
                return;
            case DBOperadorEMailPopupDicInfo.PortaSmtp:
                FPortaSmtp = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBOperadorEMailPopupDicInfo.PortaPop3:
                FPortaPop3 = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBOperadorEMailPopupDicInfo.Assinatura:
                FAssinatura = $"{value}"; // rgo J3: string
                return;
            case DBOperadorEMailPopupDicInfo.Senha256:
                FSenha256 = $"{value}"; // rgo J3: string
                return;
            case DBOperadorEMailPopupDicInfo.GUID:
                FGUID = $"{value}"; // rgo J3: string
                return;
            case DBOperadorEMailPopupDicInfo.QuemCad:
                FQuemCad = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBOperadorEMailPopupDicInfo.DtCad:
                FDtCad = $"{value}"; // rgo J3: DateTime
                return;
            case DBOperadorEMailPopupDicInfo.QuemAtu:
                FQuemAtu = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBOperadorEMailPopupDicInfo.DtAtu:
                FDtAtu = $"{value}"; // rgo J3: DateTime
                return;
            case DBOperadorEMailPopupDicInfo.Visto:
                FVisto = $"{value}".Equals("True"); // rgo J3: bool
                return;
        }
    }

    public object GetValueByNameField(string nomeCampo) => nomeCampo switch
    {
        DBOperadorEMailPopupDicInfo.Operador => NFOperador(),
        DBOperadorEMailPopupDicInfo.Nome => NFNome(),
        DBOperadorEMailPopupDicInfo.Senha => NFSenha(),
        DBOperadorEMailPopupDicInfo.SMTP => NFSMTP(),
        DBOperadorEMailPopupDicInfo.POP3 => NFPOP3(),
        DBOperadorEMailPopupDicInfo.Autenticacao => FAutenticacao.ToString(),
        DBOperadorEMailPopupDicInfo.Descricao => NFDescricao(),
        DBOperadorEMailPopupDicInfo.Usuario => NFUsuario(),
        DBOperadorEMailPopupDicInfo.PortaSmtp => NFPortaSmtp(),
        DBOperadorEMailPopupDicInfo.PortaPop3 => NFPortaPop3(),
        DBOperadorEMailPopupDicInfo.Assinatura => NFAssinatura(),
        DBOperadorEMailPopupDicInfo.Senha256 => NFSenha256(),
        DBOperadorEMailPopupDicInfo.GUID => NFGUID(),
        DBOperadorEMailPopupDicInfo.QuemCad => NFQuemCad(),
        DBOperadorEMailPopupDicInfo.DtCad => MDtCad,
        DBOperadorEMailPopupDicInfo.QuemAtu => NFQuemAtu(),
        DBOperadorEMailPopupDicInfo.DtAtu => MDtAtu,
        DBOperadorEMailPopupDicInfo.Visto => FVisto.ToString(),
        _ => nameof(GetValueByNameField)};
}