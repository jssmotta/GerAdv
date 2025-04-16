namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBSMSAlice
{
    public void SetValueByNameField(string nomeCampo, object value)
    {
        switch (nomeCampo)
        {
            case DBSMSAliceDicInfo.Operador:
                FOperador = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBSMSAliceDicInfo.Nome:
                FNome = $"{value}"; // rgo J3: string
                return;
            case DBSMSAliceDicInfo.TipoEMail:
                FTipoEMail = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBSMSAliceDicInfo.GUID:
                FGUID = $"{value}"; // rgo J3: string
                return;
            case DBSMSAliceDicInfo.QuemCad:
                FQuemCad = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBSMSAliceDicInfo.DtCad:
                FDtCad = $"{value}"; // rgo J3: DateTime
                return;
            case DBSMSAliceDicInfo.QuemAtu:
                FQuemAtu = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBSMSAliceDicInfo.DtAtu:
                FDtAtu = $"{value}"; // rgo J3: DateTime
                return;
            case DBSMSAliceDicInfo.Visto:
                FVisto = $"{value}".Equals("True"); // rgo J3: bool
                return;
        }
    }

    public object GetValueByNameField(string nomeCampo) => nomeCampo switch
    {
        DBSMSAliceDicInfo.Operador => NFOperador(),
        DBSMSAliceDicInfo.Nome => NFNome(),
        DBSMSAliceDicInfo.TipoEMail => NFTipoEMail(),
        DBSMSAliceDicInfo.GUID => NFGUID(),
        DBSMSAliceDicInfo.QuemCad => NFQuemCad(),
        DBSMSAliceDicInfo.DtCad => MDtCad,
        DBSMSAliceDicInfo.QuemAtu => NFQuemAtu(),
        DBSMSAliceDicInfo.DtAtu => MDtAtu,
        DBSMSAliceDicInfo.Visto => FVisto.ToString(),
        _ => nameof(GetValueByNameField)};
}