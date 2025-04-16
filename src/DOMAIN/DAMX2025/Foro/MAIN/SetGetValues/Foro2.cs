namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBForo
{
    public void SetValueByNameField(string nomeCampo, object value)
    {
        switch (nomeCampo)
        {
            case DBForoDicInfo.EMail:
                FEMail = $"{value}"; // rgo J3: string
                return;
            case DBForoDicInfo.Nome:
                FNome = $"{value}"; // rgo J3: string
                return;
            case DBForoDicInfo.Unico:
                FUnico = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBForoDicInfo.Cidade:
                FCidade = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBForoDicInfo.Site:
                FSite = $"{value}"; // rgo J3: string
                return;
            case DBForoDicInfo.Endereco:
                FEndereco = $"{value}"; // rgo J3: string
                return;
            case DBForoDicInfo.Bairro:
                FBairro = $"{value}"; // rgo J3: string
                return;
            case DBForoDicInfo.Fone:
                FFone = $"{value}"; // rgo J3: string
                return;
            case DBForoDicInfo.Fax:
                FFax = $"{value}"; // rgo J3: string
                return;
            case DBForoDicInfo.CEP:
                FCEP = $"{value}"; // rgo J3: string
                return;
            case DBForoDicInfo.OBS:
                FOBS = $"{value}"; // rgo J3: string
                return;
            case DBForoDicInfo.UnicoConfirmado:
                FUnicoConfirmado = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBForoDicInfo.Web:
                FWeb = $"{value}"; // rgo J3: string
                return;
            case DBForoDicInfo.Etiqueta:
                FEtiqueta = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBForoDicInfo.Bold:
                FBold = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBForoDicInfo.QuemCad:
                FQuemCad = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBForoDicInfo.DtCad:
                FDtCad = $"{value}"; // rgo J3: DateTime
                return;
            case DBForoDicInfo.QuemAtu:
                FQuemAtu = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBForoDicInfo.DtAtu:
                FDtAtu = $"{value}"; // rgo J3: DateTime
                return;
            case DBForoDicInfo.Visto:
                FVisto = $"{value}".Equals("True"); // rgo J3: bool
                return;
        }
    }

    public object GetValueByNameField(string nomeCampo) => nomeCampo switch
    {
        DBForoDicInfo.EMail => NFEMail(),
        DBForoDicInfo.Nome => NFNome(),
        DBForoDicInfo.Unico => FUnico.ToString(),
        DBForoDicInfo.Cidade => NFCidade(),
        DBForoDicInfo.Site => NFSite(),
        DBForoDicInfo.Endereco => NFEndereco(),
        DBForoDicInfo.Bairro => NFBairro(),
        DBForoDicInfo.Fone => NFFone(),
        DBForoDicInfo.Fax => NFFax(),
        DBForoDicInfo.CEP => NFCEP(),
        DBForoDicInfo.OBS => NFOBS(),
        DBForoDicInfo.UnicoConfirmado => FUnicoConfirmado.ToString(),
        DBForoDicInfo.Web => NFWeb(),
        DBForoDicInfo.Etiqueta => FEtiqueta.ToString(),
        DBForoDicInfo.Bold => FBold.ToString(),
        DBForoDicInfo.QuemCad => NFQuemCad(),
        DBForoDicInfo.DtCad => MDtCad,
        DBForoDicInfo.QuemAtu => NFQuemAtu(),
        DBForoDicInfo.DtAtu => MDtAtu,
        DBForoDicInfo.Visto => FVisto.ToString(),
        _ => nameof(GetValueByNameField)};
}