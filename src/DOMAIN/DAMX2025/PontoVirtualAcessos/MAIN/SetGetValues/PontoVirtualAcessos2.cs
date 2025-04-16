namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBPontoVirtualAcessos
{
    public void SetValueByNameField(string nomeCampo, object value)
    {
        switch (nomeCampo)
        {
            case DBPontoVirtualAcessosDicInfo.Operador:
                FOperador = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBPontoVirtualAcessosDicInfo.DataHora:
                FDataHora = $"{value}"; // rgo J3: DateTime
                return;
            case DBPontoVirtualAcessosDicInfo.Tipo:
                FTipo = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBPontoVirtualAcessosDicInfo.Origem:
                FOrigem = $"{value}"; // rgo J3: string
                return;
        }
    }

    public object GetValueByNameField(string nomeCampo) => nomeCampo switch
    {
        DBPontoVirtualAcessosDicInfo.Operador => NFOperador(),
        DBPontoVirtualAcessosDicInfo.DataHora => NFDataHora(),
        DBPontoVirtualAcessosDicInfo.Tipo => FTipo.ToString(),
        DBPontoVirtualAcessosDicInfo.Origem => NFOrigem(),
        _ => nameof(GetValueByNameField)};
}