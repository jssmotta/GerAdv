namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBGUTMatriz
{
    public void SetValueByNameField(string nomeCampo, object value)
    {
        switch (nomeCampo)
        {
            case DBGUTMatrizDicInfo.Descricao:
                FDescricao = $"{value}"; // rgo J3: string
                return;
            case DBGUTMatrizDicInfo.GUTTipo:
                FGUTTipo = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBGUTMatrizDicInfo.Valor:
                FValor = Convert.ToInt32(value); // rgo J3: int
                return;
        }
    }

    public object GetValueByNameField(string nomeCampo) => nomeCampo switch
    {
        DBGUTMatrizDicInfo.Descricao => NFDescricao(),
        DBGUTMatrizDicInfo.GUTTipo => NFGUTTipo(),
        DBGUTMatrizDicInfo.Valor => NFValor(),
        _ => nameof(GetValueByNameField)};
}