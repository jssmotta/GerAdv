namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBPontoVirtual
{
    public void SetValueByNameField(string nomeCampo, object value)
    {
        switch (nomeCampo)
        {
            case DBPontoVirtualDicInfo.HoraEntrada:
                FHoraEntrada = $"{value}"; // rgo J3: DateTime
                return;
            case DBPontoVirtualDicInfo.HoraSaida:
                FHoraSaida = $"{value}"; // rgo J3: DateTime
                return;
            case DBPontoVirtualDicInfo.Operador:
                FOperador = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBPontoVirtualDicInfo.Key:
                FKey = $"{value}"; // rgo J3: string
                return;
        }
    }

    public object GetValueByNameField(string nomeCampo) => nomeCampo switch
    {
        DBPontoVirtualDicInfo.HoraEntrada => NFHoraEntrada(),
        DBPontoVirtualDicInfo.HoraSaida => NFHoraSaida(),
        DBPontoVirtualDicInfo.Operador => NFOperador(),
        DBPontoVirtualDicInfo.Key => NFKey(),
        _ => nameof(GetValueByNameField)};
}