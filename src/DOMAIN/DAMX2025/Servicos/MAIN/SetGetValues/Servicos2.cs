namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBServicos
{
    public void SetValueByNameField(string nomeCampo, object value)
    {
        switch (nomeCampo)
        {
            case DBServicosDicInfo.Cobrar:
                FCobrar = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBServicosDicInfo.Descricao:
                FDescricao = $"{value}"; // rgo J3: string
                return;
            case DBServicosDicInfo.Basico:
                FBasico = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBServicosDicInfo.GUID:
                FGUID = $"{value}"; // rgo J3: string
                return;
            case DBServicosDicInfo.QuemCad:
                FQuemCad = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBServicosDicInfo.DtCad:
                FDtCad = $"{value}"; // rgo J3: DateTime
                return;
            case DBServicosDicInfo.QuemAtu:
                FQuemAtu = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBServicosDicInfo.DtAtu:
                FDtAtu = $"{value}"; // rgo J3: DateTime
                return;
            case DBServicosDicInfo.Visto:
                FVisto = $"{value}".Equals("True"); // rgo J3: bool
                return;
        }
    }

    public object GetValueByNameField(string nomeCampo) => nomeCampo switch
    {
        DBServicosDicInfo.Cobrar => FCobrar.ToString(),
        DBServicosDicInfo.Descricao => NFDescricao(),
        DBServicosDicInfo.Basico => FBasico.ToString(),
        DBServicosDicInfo.GUID => NFGUID(),
        DBServicosDicInfo.QuemCad => NFQuemCad(),
        DBServicosDicInfo.DtCad => MDtCad,
        DBServicosDicInfo.QuemAtu => NFQuemAtu(),
        DBServicosDicInfo.DtAtu => MDtAtu,
        DBServicosDicInfo.Visto => FVisto.ToString(),
        _ => nameof(GetValueByNameField)};
}