namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBTipoCompromisso
{
    public void SetValueByNameField(string nomeCampo, object value)
    {
        switch (nomeCampo)
        {
            case DBTipoCompromissoDicInfo.Icone:
                FIcone = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBTipoCompromissoDicInfo.Descricao:
                FDescricao = $"{value}"; // rgo J3: string
                return;
            case DBTipoCompromissoDicInfo.Financeiro:
                FFinanceiro = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBTipoCompromissoDicInfo.Bold:
                FBold = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBTipoCompromissoDicInfo.GUID:
                FGUID = $"{value}"; // rgo J3: string
                return;
            case DBTipoCompromissoDicInfo.QuemCad:
                FQuemCad = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBTipoCompromissoDicInfo.DtCad:
                FDtCad = $"{value}"; // rgo J3: DateTime
                return;
            case DBTipoCompromissoDicInfo.QuemAtu:
                FQuemAtu = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBTipoCompromissoDicInfo.DtAtu:
                FDtAtu = $"{value}"; // rgo J3: DateTime
                return;
            case DBTipoCompromissoDicInfo.Visto:
                FVisto = $"{value}".Equals("True"); // rgo J3: bool
                return;
        }
    }

    public object GetValueByNameField(string nomeCampo) => nomeCampo switch
    {
        DBTipoCompromissoDicInfo.Icone => NFIcone(),
        DBTipoCompromissoDicInfo.Descricao => NFDescricao(),
        DBTipoCompromissoDicInfo.Financeiro => FFinanceiro.ToString(),
        DBTipoCompromissoDicInfo.Bold => FBold.ToString(),
        DBTipoCompromissoDicInfo.GUID => NFGUID(),
        DBTipoCompromissoDicInfo.QuemCad => NFQuemCad(),
        DBTipoCompromissoDicInfo.DtCad => MDtCad,
        DBTipoCompromissoDicInfo.QuemAtu => NFQuemAtu(),
        DBTipoCompromissoDicInfo.DtAtu => MDtAtu,
        DBTipoCompromissoDicInfo.Visto => FVisto.ToString(),
        _ => nameof(GetValueByNameField)};
}