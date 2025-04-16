namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBFuncao
{
    public void SetValueByNameField(string nomeCampo, object value)
    {
        switch (nomeCampo)
        {
            case DBFuncaoDicInfo.Descricao:
                FDescricao = $"{value}"; // rgo J3: string
                return;
            case DBFuncaoDicInfo.QuemCad:
                FQuemCad = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBFuncaoDicInfo.DtCad:
                FDtCad = $"{value}"; // rgo J3: DateTime
                return;
            case DBFuncaoDicInfo.QuemAtu:
                FQuemAtu = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBFuncaoDicInfo.DtAtu:
                FDtAtu = $"{value}"; // rgo J3: DateTime
                return;
            case DBFuncaoDicInfo.Visto:
                FVisto = $"{value}".Equals("True"); // rgo J3: bool
                return;
        }
    }

    public object GetValueByNameField(string nomeCampo) => nomeCampo switch
    {
        DBFuncaoDicInfo.Descricao => NFDescricao(),
        DBFuncaoDicInfo.QuemCad => NFQuemCad(),
        DBFuncaoDicInfo.DtCad => MDtCad,
        DBFuncaoDicInfo.QuemAtu => NFQuemAtu(),
        DBFuncaoDicInfo.DtAtu => MDtAtu,
        DBFuncaoDicInfo.Visto => FVisto.ToString(),
        _ => nameof(GetValueByNameField)};
}