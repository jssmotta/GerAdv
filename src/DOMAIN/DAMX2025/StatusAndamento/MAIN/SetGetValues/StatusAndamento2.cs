namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBStatusAndamento
{
    public void SetValueByNameField(string nomeCampo, object value)
    {
        switch (nomeCampo)
        {
            case DBStatusAndamentoDicInfo.Nome:
                FNome = $"{value}"; // rgo J3: string
                return;
            case DBStatusAndamentoDicInfo.Icone:
                FIcone = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBStatusAndamentoDicInfo.Bold:
                FBold = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBStatusAndamentoDicInfo.GUID:
                FGUID = $"{value}"; // rgo J3: string
                return;
            case DBStatusAndamentoDicInfo.QuemCad:
                FQuemCad = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBStatusAndamentoDicInfo.DtCad:
                FDtCad = $"{value}"; // rgo J3: DateTime
                return;
            case DBStatusAndamentoDicInfo.QuemAtu:
                FQuemAtu = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBStatusAndamentoDicInfo.DtAtu:
                FDtAtu = $"{value}"; // rgo J3: DateTime
                return;
            case DBStatusAndamentoDicInfo.Visto:
                FVisto = $"{value}".Equals("True"); // rgo J3: bool
                return;
        }
    }

    public object GetValueByNameField(string nomeCampo) => nomeCampo switch
    {
        DBStatusAndamentoDicInfo.Nome => NFNome(),
        DBStatusAndamentoDicInfo.Icone => NFIcone(),
        DBStatusAndamentoDicInfo.Bold => FBold.ToString(),
        DBStatusAndamentoDicInfo.GUID => NFGUID(),
        DBStatusAndamentoDicInfo.QuemCad => NFQuemCad(),
        DBStatusAndamentoDicInfo.DtCad => MDtCad,
        DBStatusAndamentoDicInfo.QuemAtu => NFQuemAtu(),
        DBStatusAndamentoDicInfo.DtAtu => MDtAtu,
        DBStatusAndamentoDicInfo.Visto => FVisto.ToString(),
        _ => nameof(GetValueByNameField)};
}