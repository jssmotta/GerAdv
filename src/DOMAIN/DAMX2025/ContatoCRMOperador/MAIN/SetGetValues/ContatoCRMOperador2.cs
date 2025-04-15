namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBContatoCRMOperador
{
    public void SetValueByNameField(string nomeCampo, object value)
    {
        switch (nomeCampo)
        {
            case DBContatoCRMOperadorDicInfo.ContatoCRM:
                FContatoCRM = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBContatoCRMOperadorDicInfo.CargoEsc:
                FCargoEsc = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBContatoCRMOperadorDicInfo.Operador:
                FOperador = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBContatoCRMOperadorDicInfo.QuemCad:
                FQuemCad = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBContatoCRMOperadorDicInfo.DtCad:
                FDtCad = $"{value}"; // rgo J3: DateTime
                return;
            case DBContatoCRMOperadorDicInfo.QuemAtu:
                FQuemAtu = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBContatoCRMOperadorDicInfo.DtAtu:
                FDtAtu = $"{value}"; // rgo J3: DateTime
                return;
            case DBContatoCRMOperadorDicInfo.Visto:
                FVisto = $"{value}".Equals("True"); // rgo J3: bool
                return;
        }
    }

    public object GetValueByNameField(string nomeCampo) => nomeCampo switch
    {
        DBContatoCRMOperadorDicInfo.ContatoCRM => NFContatoCRM(),
        DBContatoCRMOperadorDicInfo.CargoEsc => NFCargoEsc(),
        DBContatoCRMOperadorDicInfo.Operador => NFOperador(),
        DBContatoCRMOperadorDicInfo.QuemCad => NFQuemCad(),
        DBContatoCRMOperadorDicInfo.DtCad => MDtCad,
        DBContatoCRMOperadorDicInfo.QuemAtu => NFQuemAtu(),
        DBContatoCRMOperadorDicInfo.DtAtu => MDtAtu,
        DBContatoCRMOperadorDicInfo.Visto => FVisto.ToString(),
        _ => nameof(GetValueByNameField)};
}