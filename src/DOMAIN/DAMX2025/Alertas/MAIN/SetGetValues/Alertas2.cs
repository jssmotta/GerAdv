namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBAlertas
{
    public void SetValueByNameField(string nomeCampo, object value)
    {
        switch (nomeCampo)
        {
            case DBAlertasDicInfo.Nome:
                FNome = $"{value}"; // rgo J3: string
                return;
            case DBAlertasDicInfo.Data:
                FData = $"{value}"; // rgo J3: DateTime
                return;
            case DBAlertasDicInfo.Operador:
                FOperador = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBAlertasDicInfo.DataAte:
                FDataAte = $"{value}"; // rgo J3: DateTime
                return;
            case DBAlertasDicInfo.QuemCad:
                FQuemCad = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBAlertasDicInfo.DtCad:
                FDtCad = $"{value}"; // rgo J3: DateTime
                return;
            case DBAlertasDicInfo.QuemAtu:
                FQuemAtu = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBAlertasDicInfo.DtAtu:
                FDtAtu = $"{value}"; // rgo J3: DateTime
                return;
            case DBAlertasDicInfo.Visto:
                FVisto = $"{value}".Equals("True"); // rgo J3: bool
                return;
        }
    }

    public object GetValueByNameField(string nomeCampo) => nomeCampo switch
    {
        DBAlertasDicInfo.Nome => NFNome(),
        DBAlertasDicInfo.Data => NFData(),
        DBAlertasDicInfo.Operador => NFOperador(),
        DBAlertasDicInfo.DataAte => NFDataAte(),
        DBAlertasDicInfo.QuemCad => NFQuemCad(),
        DBAlertasDicInfo.DtCad => MDtCad,
        DBAlertasDicInfo.QuemAtu => NFQuemAtu(),
        DBAlertasDicInfo.DtAtu => MDtAtu,
        DBAlertasDicInfo.Visto => FVisto.ToString(),
        _ => nameof(GetValueByNameField)};
}