namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBEnderecos
{
    public void SetValueByNameField(string nomeCampo, object value)
    {
        switch (nomeCampo)
        {
            case DBEnderecosDicInfo.TopIndex:
                FTopIndex = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBEnderecosDicInfo.Descricao:
                FDescricao = $"{value}"; // rgo J3: string
                return;
            case DBEnderecosDicInfo.Contato:
                FContato = $"{value}"; // rgo J3: string
                return;
            case DBEnderecosDicInfo.DtNasc:
                FDtNasc = $"{value}"; // rgo J3: DateTime
                return;
            case DBEnderecosDicInfo.Endereco:
                FEndereco = $"{value}"; // rgo J3: string
                return;
            case DBEnderecosDicInfo.Bairro:
                FBairro = $"{value}"; // rgo J3: string
                return;
            case DBEnderecosDicInfo.Privativo:
                FPrivativo = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBEnderecosDicInfo.AddContato:
                FAddContato = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBEnderecosDicInfo.CEP:
                FCEP = $"{value}"; // rgo J3: string
                return;
            case DBEnderecosDicInfo.OAB:
                FOAB = $"{value}"; // rgo J3: string
                return;
            case DBEnderecosDicInfo.OBS:
                FOBS = $"{value}"; // rgo J3: string
                return;
            case DBEnderecosDicInfo.Fone:
                FFone = $"{value}"; // rgo J3: string
                return;
            case DBEnderecosDicInfo.Fax:
                FFax = $"{value}"; // rgo J3: string
                return;
            case DBEnderecosDicInfo.Tratamento:
                FTratamento = $"{value}"; // rgo J3: string
                return;
            case DBEnderecosDicInfo.Cidade:
                FCidade = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBEnderecosDicInfo.Site:
                FSite = $"{value}"; // rgo J3: string
                return;
            case DBEnderecosDicInfo.EMail:
                FEMail = $"{value}"; // rgo J3: string
                return;
            case DBEnderecosDicInfo.Quem:
                FQuem = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBEnderecosDicInfo.QuemIndicou:
                FQuemIndicou = $"{value}"; // rgo J3: string
                return;
            case DBEnderecosDicInfo.ReportECBOnly:
                FReportECBOnly = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBEnderecosDicInfo.Etiqueta:
                FEtiqueta = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBEnderecosDicInfo.Ani:
                FAni = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBEnderecosDicInfo.Bold:
                FBold = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBEnderecosDicInfo.GUID:
                FGUID = $"{value}"; // rgo J3: string
                return;
            case DBEnderecosDicInfo.QuemCad:
                FQuemCad = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBEnderecosDicInfo.DtCad:
                FDtCad = $"{value}"; // rgo J3: DateTime
                return;
            case DBEnderecosDicInfo.QuemAtu:
                FQuemAtu = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBEnderecosDicInfo.DtAtu:
                FDtAtu = $"{value}"; // rgo J3: DateTime
                return;
            case DBEnderecosDicInfo.Visto:
                FVisto = $"{value}".Equals("True"); // rgo J3: bool
                return;
        }
    }

    public object GetValueByNameField(string nomeCampo) => nomeCampo switch
    {
        DBEnderecosDicInfo.TopIndex => FTopIndex.ToString(),
        DBEnderecosDicInfo.Descricao => NFDescricao(),
        DBEnderecosDicInfo.Contato => NFContato(),
        DBEnderecosDicInfo.DtNasc => NFDtNasc(),
        DBEnderecosDicInfo.Endereco => NFEndereco(),
        DBEnderecosDicInfo.Bairro => NFBairro(),
        DBEnderecosDicInfo.Privativo => FPrivativo.ToString(),
        DBEnderecosDicInfo.AddContato => FAddContato.ToString(),
        DBEnderecosDicInfo.CEP => NFCEP(),
        DBEnderecosDicInfo.OAB => NFOAB(),
        DBEnderecosDicInfo.OBS => NFOBS(),
        DBEnderecosDicInfo.Fone => NFFone(),
        DBEnderecosDicInfo.Fax => NFFax(),
        DBEnderecosDicInfo.Tratamento => NFTratamento(),
        DBEnderecosDicInfo.Cidade => NFCidade(),
        DBEnderecosDicInfo.Site => NFSite(),
        DBEnderecosDicInfo.EMail => NFEMail(),
        DBEnderecosDicInfo.Quem => NFQuem(),
        DBEnderecosDicInfo.QuemIndicou => NFQuemIndicou(),
        DBEnderecosDicInfo.ReportECBOnly => FReportECBOnly.ToString(),
        DBEnderecosDicInfo.Etiqueta => FEtiqueta.ToString(),
        DBEnderecosDicInfo.Ani => FAni.ToString(),
        DBEnderecosDicInfo.Bold => FBold.ToString(),
        DBEnderecosDicInfo.GUID => NFGUID(),
        DBEnderecosDicInfo.QuemCad => NFQuemCad(),
        DBEnderecosDicInfo.DtCad => MDtCad,
        DBEnderecosDicInfo.QuemAtu => NFQuemAtu(),
        DBEnderecosDicInfo.DtAtu => MDtAtu,
        DBEnderecosDicInfo.Visto => FVisto.ToString(),
        _ => nameof(GetValueByNameField)};
}