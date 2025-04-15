namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBTipoValorProcesso
{
    public void SetValueByNameField(string nomeCampo, object value)
    {
        switch (nomeCampo)
        {
            case DBTipoValorProcessoDicInfo.Descricao:
                FDescricao = $"{value}"; // rgo J3: string
                return;
            case DBTipoValorProcessoDicInfo.GUID:
                FGUID = $"{value}"; // rgo J3: string
                return;
        }
    }

    public object GetValueByNameField(string nomeCampo) => nomeCampo switch
    {
        DBTipoValorProcessoDicInfo.Descricao => NFDescricao(),
        DBTipoValorProcessoDicInfo.GUID => NFGUID(),
        _ => nameof(GetValueByNameField)};
}