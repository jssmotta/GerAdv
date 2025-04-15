namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBTerceiros
{
    public void SetValueByNameField(string nomeCampo, object value)
    {
        switch (nomeCampo)
        {
            case DBTerceirosDicInfo.Processo:
                FProcesso = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBTerceirosDicInfo.Nome:
                FNome = $"{value}"; // rgo J3: string
                return;
            case DBTerceirosDicInfo.Situacao:
                FSituacao = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBTerceirosDicInfo.Cidade:
                FCidade = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBTerceirosDicInfo.Endereco:
                FEndereco = $"{value}"; // rgo J3: string
                return;
            case DBTerceirosDicInfo.Bairro:
                FBairro = $"{value}"; // rgo J3: string
                return;
            case DBTerceirosDicInfo.CEP:
                FCEP = $"{value}"; // rgo J3: string
                return;
            case DBTerceirosDicInfo.Fone:
                FFone = $"{value}"; // rgo J3: string
                return;
            case DBTerceirosDicInfo.Fax:
                FFax = $"{value}"; // rgo J3: string
                return;
            case DBTerceirosDicInfo.OBS:
                FOBS = $"{value}"; // rgo J3: string
                return;
            case DBTerceirosDicInfo.EMail:
                FEMail = $"{value}"; // rgo J3: string
                return;
            case DBTerceirosDicInfo.Class:
                FClass = $"{value}"; // rgo J3: string
                return;
            case DBTerceirosDicInfo.VaraForoComarca:
                FVaraForoComarca = $"{value}"; // rgo J3: string
                return;
            case DBTerceirosDicInfo.Sexo:
                FSexo = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBTerceirosDicInfo.Bold:
                FBold = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBTerceirosDicInfo.GUID:
                FGUID = $"{value}"; // rgo J3: string
                return;
            case DBTerceirosDicInfo.QuemCad:
                FQuemCad = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBTerceirosDicInfo.DtCad:
                FDtCad = $"{value}"; // rgo J3: DateTime
                return;
            case DBTerceirosDicInfo.QuemAtu:
                FQuemAtu = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBTerceirosDicInfo.DtAtu:
                FDtAtu = $"{value}"; // rgo J3: DateTime
                return;
            case DBTerceirosDicInfo.Visto:
                FVisto = $"{value}".Equals("True"); // rgo J3: bool
                return;
        }
    }

    public object GetValueByNameField(string nomeCampo) => nomeCampo switch
    {
        DBTerceirosDicInfo.Processo => NFProcesso(),
        DBTerceirosDicInfo.Nome => NFNome(),
        DBTerceirosDicInfo.Situacao => NFSituacao(),
        DBTerceirosDicInfo.Cidade => NFCidade(),
        DBTerceirosDicInfo.Endereco => NFEndereco(),
        DBTerceirosDicInfo.Bairro => NFBairro(),
        DBTerceirosDicInfo.CEP => NFCEP(),
        DBTerceirosDicInfo.Fone => NFFone(),
        DBTerceirosDicInfo.Fax => NFFax(),
        DBTerceirosDicInfo.OBS => NFOBS(),
        DBTerceirosDicInfo.EMail => NFEMail(),
        DBTerceirosDicInfo.Class => NFClass(),
        DBTerceirosDicInfo.VaraForoComarca => NFVaraForoComarca(),
        DBTerceirosDicInfo.Sexo => FSexo.ToString(),
        DBTerceirosDicInfo.Bold => FBold.ToString(),
        DBTerceirosDicInfo.GUID => NFGUID(),
        DBTerceirosDicInfo.QuemCad => NFQuemCad(),
        DBTerceirosDicInfo.DtCad => MDtCad,
        DBTerceirosDicInfo.QuemAtu => NFQuemAtu(),
        DBTerceirosDicInfo.DtAtu => MDtAtu,
        DBTerceirosDicInfo.Visto => FVisto.ToString(),
        _ => nameof(GetValueByNameField)};
}