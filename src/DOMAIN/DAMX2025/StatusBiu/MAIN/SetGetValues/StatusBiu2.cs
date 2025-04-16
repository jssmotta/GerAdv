namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBStatusBiu
{
    public void SetValueByNameField(string nomeCampo, object value)
    {
        switch (nomeCampo)
        {
            case DBStatusBiuDicInfo.Nome:
                FNome = $"{value}"; // rgo J3: string
                return;
            case DBStatusBiuDicInfo.TipoStatusBiu:
                FTipoStatusBiu = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBStatusBiuDicInfo.Operador:
                FOperador = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBStatusBiuDicInfo.Icone:
                FIcone = Convert.ToInt32(value); // rgo J3: int
                return;
        }
    }

    public object GetValueByNameField(string nomeCampo) => nomeCampo switch
    {
        DBStatusBiuDicInfo.Nome => NFNome(),
        DBStatusBiuDicInfo.TipoStatusBiu => NFTipoStatusBiu(),
        DBStatusBiuDicInfo.Operador => NFOperador(),
        DBStatusBiuDicInfo.Icone => NFIcone(),
        _ => nameof(GetValueByNameField)};
}