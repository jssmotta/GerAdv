namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBOperadorGrupo
{
    public void SetValueByNameField(string nomeCampo, object value)
    {
        switch (nomeCampo)
        {
            case DBOperadorGrupoDicInfo.Operador:
                FOperador = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBOperadorGrupoDicInfo.Grupo:
                FGrupo = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBOperadorGrupoDicInfo.Inativo:
                FInativo = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBOperadorGrupoDicInfo.QuemCad:
                FQuemCad = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBOperadorGrupoDicInfo.DtCad:
                FDtCad = $"{value}"; // rgo J3: DateTime
                return;
            case DBOperadorGrupoDicInfo.QuemAtu:
                FQuemAtu = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBOperadorGrupoDicInfo.DtAtu:
                FDtAtu = $"{value}"; // rgo J3: DateTime
                return;
            case DBOperadorGrupoDicInfo.Visto:
                FVisto = $"{value}".Equals("True"); // rgo J3: bool
                return;
        }
    }

    public object GetValueByNameField(string nomeCampo) => nomeCampo switch
    {
        DBOperadorGrupoDicInfo.Operador => NFOperador(),
        DBOperadorGrupoDicInfo.Grupo => NFGrupo(),
        DBOperadorGrupoDicInfo.Inativo => FInativo.ToString(),
        DBOperadorGrupoDicInfo.QuemCad => NFQuemCad(),
        DBOperadorGrupoDicInfo.DtCad => MDtCad,
        DBOperadorGrupoDicInfo.QuemAtu => NFQuemAtu(),
        DBOperadorGrupoDicInfo.DtAtu => MDtAtu,
        DBOperadorGrupoDicInfo.Visto => FVisto.ToString(),
        _ => nameof(GetValueByNameField)};
}